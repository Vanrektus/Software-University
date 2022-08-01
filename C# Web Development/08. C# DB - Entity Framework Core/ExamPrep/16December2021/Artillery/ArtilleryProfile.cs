namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using System.Linq;

    class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            CreateMap<CountryImportDto, Country>();
            CreateMap<GunImportDto, Gun>();
            CreateMap<ManufacturerImportDto, Manufacturer>();
            CreateMap<ShellImportDto, Shell>();

            CreateMap<Country, GunCountryExportDto>();
            CreateMap<Gun, GunExportDto>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.ManufacturerName))
                .ForMember(dest => dest.GunType, opt => opt.MapFrom(src => src.GunType.ToString()))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.CountriesGuns.Select(cg => cg.Country)));
        }
    }
}