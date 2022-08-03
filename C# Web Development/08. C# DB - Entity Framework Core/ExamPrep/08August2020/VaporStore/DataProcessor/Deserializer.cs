namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";

		private const string SuccessfullGameImport = "Added {0} ({1}) with {2} tags";

		private const string SuccessfullUserImport = "Imported {0} with {1} cards";

		private const string SuccessfullPurchaseImport = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            GameImportDto[] gameDtos = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

			ICollection<Game> games = new HashSet<Game>();

			StringBuilder sb = new StringBuilder();

            foreach (GameImportDto dtoGame in gameDtos)
            {
                if (!IsValid(dtoGame) || !dtoGame.Tags.Any())
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Developer developer =  context.Developers.FirstOrDefault(g => g.Name == dtoGame.Developer) ?? new Developer { Name = dtoGame.Developer };

				Genre genre = context.Genres.FirstOrDefault(g => g.Name == dtoGame.Genre) ?? new Genre { Name = dtoGame.Genre };

				Game currGame = new Game
				{
					Name = dtoGame.Name,
					Price = dtoGame.Price,
					ReleaseDate = dtoGame.ReleaseDate,
					Developer = developer,
					Genre = genre
				};

                foreach (var currTag in dtoGame.Tags)
                {
					Tag tag = context.Tags.FirstOrDefault(t => t.Name == currTag) ?? new Tag { Name = currTag };

					currGame.GameTags.Add(new GameTag { Tag = tag });
                }

				games.Add(currGame);
				sb.AppendLine(string.Format(SuccessfullGameImport, currGame.Name, currGame.Genre.Name, currGame.GameTags.Count));
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			UserImportDto[] userDtos = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

			ICollection<User> users = new HashSet<User>();

			StringBuilder sb = new StringBuilder();

			foreach (UserImportDto dtoUser in userDtos)
			{
				if (!IsValid(dtoUser))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				User currUser = new User
				{
					FullName = dtoUser.FullName,
					Username = dtoUser.Username,
					Email = dtoUser.Email,
					Age = dtoUser.Age,
					Cards = dtoUser.Cards.Select(c => new Card
                    {
						Number = c.Number,
						Cvc = c.Cvc,
						Type = c.Type
                    })
					.ToList()
				};

				users.Add(currUser);
				sb.AppendLine(string.Format(SuccessfullUserImport, currUser.Username, currUser.Cards.Count));
			}

			context.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Purchases");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseImportDto[]), xmlRootAttribute);

			StringBuilder sb = new StringBuilder();

			using (StringReader sr = new StringReader(xmlString))
			{
				PurchaseImportDto[] purchaseDtos = (PurchaseImportDto[])xmlSerializer.Deserialize(sr);

				ICollection<Purchase> purchases = new HashSet<Purchase>();

				foreach (PurchaseImportDto dtoPurchase in purchaseDtos)
				{
					if (!IsValid(dtoPurchase))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					DateTime date;
					bool isDateValid = DateTime.TryParseExact(dtoPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

					if (!isDateValid)
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					Purchase currPurchase = new Purchase
					{
						Game = context.Games.FirstOrDefault(g => g.Name == dtoPurchase.GameName),
						Type = dtoPurchase.Type,
						ProductKey = dtoPurchase.ProductKey,
						Card = context.Cards.FirstOrDefault(c => c.Number == dtoPurchase.CardNumber),
						Date = date
					};

					string username = context.Users
						.Where(u => u.Id == currPurchase.Card.UserId)
						.Select(u => u.Username)
						.FirstOrDefault();

					purchases.Add(currPurchase);
					sb.AppendLine(string.Format(SuccessfullPurchaseImport, currPurchase.Game.Name, username));
				}
				context.AddRange(purchases);
				context.SaveChanges();

				return sb.ToString().TrimEnd();
			}
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}