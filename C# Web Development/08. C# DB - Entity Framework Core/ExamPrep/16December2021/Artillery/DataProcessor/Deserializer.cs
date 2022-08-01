namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private static IMapper mapper;

        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CountryImportDto[]), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                CountryImportDto[] countryDtos = (CountryImportDto[])xmlSerializer.Deserialize(sr);

                ICollection<Country> countries = new HashSet<Country>();

                foreach (CountryImportDto dtoCountry in countryDtos)
                {
                    if (!IsValid(dtoCountry))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Country currCountry = new Country
                    {
                        CountryName = dtoCountry.CountryName,
                        ArmySize = dtoCountry.ArmySize
                    };

                    countries.Add(currCountry);
                    sb.AppendLine(string.Format(SuccessfulImportCountry, currCountry.CountryName, currCountry.ArmySize));
                }

                context.Countries.AddRange(countries);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<ManufacturerImportDto>), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                ICollection<ManufacturerImportDto> manufacturerDtos = (HashSet<ManufacturerImportDto>)xmlSerializer.Deserialize(sr);

                ICollection<Manufacturer> manufacturers = new HashSet<Manufacturer>();

                foreach (ManufacturerImportDto dtoManufacturer in manufacturerDtos)
                {
                    if (!IsValid(dtoManufacturer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (manufacturers.Any(m => m.ManufacturerName == dtoManufacturer.ManufacturerName))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    string[] foundedData = dtoManufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (foundedData.Length < 2)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    string countryName = foundedData[foundedData.Length - 1];
                    string townName = foundedData[foundedData.Length - 2];

                    Manufacturer currManufacturer = new Manufacturer
                    {
                        ManufacturerName = dtoManufacturer.ManufacturerName,
                        Founded = dtoManufacturer.Founded
                    };

                    manufacturers.Add(currManufacturer);
                    sb.AppendLine(string.Format(SuccessfulImportManufacturer, currManufacturer.ManufacturerName, $"{townName}, {countryName}"));
                }

                context.Manufacturers.AddRange(manufacturers);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<ShellImportDto>), xmlRootAttribute);

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                ICollection<ShellImportDto> shellDtos = (HashSet<ShellImportDto>)xmlSerializer.Deserialize(sr);

                ICollection<Shell> shells = new HashSet<Shell>();

                foreach (ShellImportDto dtoShell in shellDtos)
                {
                    if (!IsValid(dtoShell))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Shell currShell = new Shell
                    {
                        ShellWeight = dtoShell.ShellWeight,
                        Caliber = dtoShell.Caliber
                    };

                    shells.Add(currShell);
                    sb.AppendLine(string.Format(SuccessfulImportShell, currShell.Caliber, currShell.ShellWeight));
                }

                context.Shells.AddRange(shells);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            InitializeAutoMapper();

            GunImportDto[] gunDtos = JsonConvert.DeserializeObject<GunImportDto[]>(jsonString);

            GunImportDto[] mappedGuns = mapper.Map<GunImportDto[]>(gunDtos);

            ICollection<Gun> guns = new HashSet<Gun>();

            StringBuilder sb = new StringBuilder();

            foreach (GunImportDto dtoGun in gunDtos)
            {
                if (!IsValid(dtoGun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGunType = Enum.TryParse<GunType>(dtoGun.GunType, true, out GunType gunType);

                if (!isValidGunType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun currGun = new Gun
                {
                    ManufacturerId = dtoGun.ManufacturerId,
                    GunWeight = dtoGun.GunWeight,
                    BarrelLength = dtoGun.BarrelLength,
                    NumberBuild = dtoGun.NumberBuild,
                    Range = dtoGun.Range,
                    GunType = gunType,
                    ShellId = dtoGun.ShellId
                };

                ICollection<CountryGun> countryGuns = new HashSet<CountryGun>();

                foreach (var countryId in dtoGun.Countries)
                {
                    Country country = context.Countries.FirstOrDefault(c => c.Id == countryId.Id);

                    CountryGun countryGun = new CountryGun()
                    {
                        Gun = currGun,
                        Country = country
                    };

                    countryGuns.Add(countryGun);
                }

                currGun.CountriesGuns = countryGuns;

                guns.Add(currGun);
                sb.AppendLine(string.Format(SuccessfulImportGun, currGun.GunType, currGun.GunWeight, currGun.BarrelLength));
            }

            context.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<ArtilleryProfile>());

            mapper = config.CreateMapper();
        }
    }
}
