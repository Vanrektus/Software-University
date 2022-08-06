namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
{
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoachImportDto[]), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                CoachImportDto[] coachDtos = (CoachImportDto[])xmlSerializer.Deserialize(sr);

                ICollection<Coach> coaches = new HashSet<Coach>();

                foreach (CoachImportDto dtoCoach in coachDtos)
                {
                    if (!IsValid(dtoCoach))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Coach currCoach = new Coach
                    {
                        Name = dtoCoach.Name,
                        Nationality = dtoCoach.Nationality,
                    };

                    foreach (FootballerImportDto currFootballer in dtoCoach.Footballers)
                    {
                        if (!IsValid(currFootballer))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime contractStartDate;
                        bool isValidStartDate = DateTime.TryParseExact(currFootballer.ContractStartDate, "dd/MM/yyyy", 
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out contractStartDate);

                        if (!isValidStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime contractEndDate;
                        bool isValidEndDate = DateTime.TryParseExact(currFootballer.ContractEndDate, "dd/MM/yyyy", 
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out contractEndDate);

                        if (!isValidEndDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (contractStartDate > contractEndDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        BestSkillType bestSkillType;
                        bool isValidBestSkillType = Enum.TryParse<BestSkillType>(currFootballer.BestSkillType, true, out bestSkillType);

                        if (!isValidBestSkillType)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        PositionType positionType;
                        bool isValidPositionType = Enum.TryParse<PositionType>(currFootballer.PositionType, true, out positionType);

                        if (!isValidPositionType)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Footballer footballer = new Footballer
                        {
                            Name = currFootballer.Name,
                            ContractStartDate = contractStartDate,
                            ContractEndDate = contractEndDate,
                            BestSkillType = bestSkillType,
                            PositionType = positionType
                        };

                        currCoach.Footballers.Add(footballer);
                    }

                    coaches.Add(currCoach);
                    sb.AppendLine(string.Format(SuccessfullyImportedCoach, currCoach.Name, currCoach.Footballers.Count));
                }

                context.Coaches.AddRange(coaches);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            TeamImportDto[] teamDtos = JsonConvert.DeserializeObject<TeamImportDto[]>(jsonString);

            ICollection<Team> teams = new HashSet<Team>();

            StringBuilder sb = new StringBuilder();

            foreach (TeamImportDto dtoTeam in teamDtos)
            {
                if (!IsValid(dtoTeam) || dtoTeam.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team currTeam = new Team
                {
                    Name = dtoTeam.Name,
                    Nationality = dtoTeam.Nationality,
                    Trophies = dtoTeam.Trophies
                };

                foreach (int dtoFootballerId in dtoTeam.Footballers.Distinct())
                {
                    Footballer currFootballer = context.Footballers.Find(dtoFootballerId);

                    if (currFootballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currTeam.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = currFootballer
                    });
                }

                teams.Add(currTeam);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, currTeam.Name, currTeam.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
