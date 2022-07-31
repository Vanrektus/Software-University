using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();
            CreateMap<ProductInputDto, Product>();
            CreateMap<CategoryInputDto, Category>();
            CreateMap<CategoryProductInputDto, CategoryProduct>();

            CreateMap<Product, ProductOutputDto>()
                .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));
            
            CreateMap<User, UserOutputDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src.ProductsSold))
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src.ProductsSold.Where(x => x.BuyerId != null)));
            
            CreateMap<Category, CategoryOutputDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => $"{src.CategoryProducts.Average(x => x.Product.Price):f2}"))
                .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(src => $"{src.CategoryProducts.Sum(x => x.Product.Price):f2}"));

            CreateMap<User, UserInfoDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src));
            CreateMap<User, SoldProductDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.ProductsSold.Where(x => x.Buyer != null).Count()))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductsSold.Where(x => x.Buyer != null)));
            CreateMap<Product, ProductDto>();
        }
    }
}
