namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
using System.Globalization;
    using System.IO;
using System.Linq;
using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Include(t => t.Tickets)
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToList()
                .Select(t => new TheatreExportDto
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Sum(ti => ti.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new TicketExportDto
                        {
                            Price = decimal.Parse(ti.Price.ToString("f2")),
                            RowNumber = ti.RowNumber
                        })
                        .OrderByDescending(ti=> ti.Price)
                        .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            string theatresAsJson = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return theatresAsJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Include(p => p.Casts)
                .Where(p => p.Rating <= rating)
                .ToList()
                .Select(p => new PlayExportDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre,
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter == true)
                        .Select(c => new ActorExportDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{c.Play.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayExportDto[]), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sr = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sr, plays, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
