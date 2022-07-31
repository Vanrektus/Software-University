using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();
            CreateMap<PartInputDto, Part>();
            CreateMap<CustomerInputDto, Customer>();
            CreateMap<SaleInputDto, Sale>();

            CreateMap<Car, CarOutputDto>();
            CreateMap<Car, CarMakeBMWOutputDto>();
            CreateMap<Supplier, SupplierOutputDto>()
              .ForMember(x => x.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));
        }
    }
}
