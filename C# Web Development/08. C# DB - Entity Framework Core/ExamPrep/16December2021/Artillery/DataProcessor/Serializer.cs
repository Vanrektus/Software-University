
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        private static IMapper mapper;

        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Include(x => x.Guns)
                .Where(s => s.ShellWeight > shellWeight)
                .ToList()
                .Select(s => new ShellExportDto
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns.Select(g => new ShellGunExportDto
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .Where(g => g.GunType == GunType.AntiAircraftGun.ToString())
                    .OrderByDescending(g => g.GunWeight)
                    .ToList()
                })
                .ToList()
                .OrderBy(s => s.ShellWeight);

            string shellsAsJson = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return shellsAsJson;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            InitializeAutoMapper();

            GunExportDto[] guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .ProjectTo<GunExportDto>(mapper.ConfigurationProvider)
                .ToArray()
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            foreach (var currGun in guns)
            {
                currGun.Countries = currGun.Countries
                    .Where(c => c.ArmySize > 4500000)
                    .ToArray()
                    .OrderBy(c => c.ArmySize)
                    .ToArray();
            }

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Guns");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunExportDto[]), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sr = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sr, guns, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<ArtilleryProfile>());

            mapper = config.CreateMapper();
        }
    }
}
