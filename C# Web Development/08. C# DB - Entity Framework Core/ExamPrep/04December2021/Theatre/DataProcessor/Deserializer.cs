namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayImportDto[]), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                PlayImportDto[] playDtos = (PlayImportDto[])xmlSerializer.Deserialize(sr);

                ICollection<Play> plays = new HashSet<Play>();

                foreach (PlayImportDto dtoPlay in playDtos)
                {
                    if (!IsValid(dtoPlay))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TimeSpan duration;
                    bool isDurationValid = TimeSpan.TryParseExact(dtoPlay.Duration, "c", CultureInfo.InvariantCulture, out duration);

                    if (!isDurationValid || duration.Hours < 1)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Genre genre;
                    bool isValidGenre = Enum.TryParse<Genre>(dtoPlay.Genre, true, out genre);

                    if (!isValidGenre)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Play currPlay = new Play
                    {
                        Title = dtoPlay.Title,
                        Duration = duration,
                        Rating = dtoPlay.Rating,
                        Genre = genre,
                        Description = dtoPlay.Description,
                        Screenwriter = dtoPlay.Screenwriter
                    };

                    plays.Add(currPlay);
                    sb.AppendLine(string.Format(SuccessfulImportPlay, currPlay.Title, currPlay.Genre, currPlay.Rating));
                }
                context.AddRange(plays);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CastImportDto[]), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                CastImportDto[] castDtos = (CastImportDto[])xmlSerializer.Deserialize(sr);

                ICollection<Cast> casts = new HashSet<Cast>();

                foreach (CastImportDto dtoCast in castDtos)
                {
                    if (!IsValid(dtoCast))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Cast currCast = new Cast
                    {
                        FullName = dtoCast.FullName,
                        IsMainCharacter = dtoCast.IsMainCharacter,
                        PhoneNumber = dtoCast.PhoneNumber,
                        PlayId = dtoCast.PlayId
                    };

                    casts.Add(currCast);
                    sb.AppendLine(string.Format(SuccessfulImportActor, currCast.FullName, currCast.IsMainCharacter ? "main" : "lesser"));
                }
                context.AddRange(casts);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            TheatreImportDto[] theatreDtos = JsonConvert.DeserializeObject<TheatreImportDto[]>(jsonString);

            ICollection<Theatre> theatres = new HashSet<Theatre>();

            StringBuilder sb = new StringBuilder();

            foreach (TheatreImportDto dtoTheatre in theatreDtos)
            {
                if (!IsValid(dtoTheatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre currTheatre = new Theatre
                {
                    Name = dtoTheatre.Name,
                    NumberOfHalls = dtoTheatre.NumberOfHalls,
                    Director = dtoTheatre.Director,
                    Tickets = new HashSet<Ticket>()
                };

                foreach (var dtoTicket in dtoTheatre.Tickets)
                {
                    if (!IsValid(dtoTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket currTicket = new Ticket
                    {
                        Price = dtoTicket.Price,
                        RowNumber = dtoTicket.RowNumber,
                        PlayId = dtoTicket.PlayId
                    };

                    currTheatre.Tickets.Add(currTicket);
                }

                theatres.Add(currTheatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, currTheatre.Name, currTheatre.Tickets.Count));
            }

            context.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
