using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // 01
            //string usersXmlAsString = File.ReadAllText("./Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXmlAsString));

            // 02
            //string productsXmlAsString = File.ReadAllText("./Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsXmlAsString));

            // 03
            //string categoriesXmlAsString = File.ReadAllText("./Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXmlAsString));

            // 04
            //string categoriesProductsXmlAsString = File.ReadAllText("./Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXmlAsString));

            // 05
            //Console.WriteLine(GetProductsInRange(context));

            // 06
            //Console.WriteLine(GetSoldProducts(context));

            // 07
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            // 08
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<UserInputDto> dtoUsers = (List<UserInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();
            List<User> users = mapper.Map<List<User>>(dtoUsers);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<ProductInputDto> dtoProducts = (List<ProductInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();
            List<Product> products = mapper.Map<List<Product>>(dtoProducts);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CategoryInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<CategoryInputDto> dtoCategories = (List<CategoryInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();
            List<Category> categories = mapper.Map<List<Category>>(dtoCategories);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CategoryProductInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<CategoryProductInputDto> allDtoCategoryProducts = (List<CategoryProductInputDto>)xmlSerializer.Deserialize(stringReader);

            List<int> validCategoriesIds = context.Categories.Select(x => x.Id).ToList();
            List<int> validProductsIds = context.Products.Select(x => x.Id).ToList();

            List<CategoryProductInputDto> dtoCategoryProducts = allDtoCategoryProducts
                .Where(x => validCategoriesIds.Contains(x.CategoryId))
                .Where(x => validProductsIds.Contains(x.ProductId))
                .ToList();

            InitializeAutoMapper();
            List<CategoryProduct> categoryProducts = mapper.Map<List<CategoryProduct>>(dtoCategoryProducts);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // 05. Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            List<ProductInRangeOutputDto> dtoProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductInRangeOutputDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductInRangeOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoProducts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            List<UserSoldProductOutputDto> dtoUsers = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UserSoldProductOutputDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(x => new SoldProductOutputDto
                    {
                        Name = x.Name,
                        Price = x.Price,
                    })
                    .ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserSoldProductOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoUsers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            List<CategoryOutputDto> dtoCategories = context.Categories
                .Select(x => new CategoryOutputDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CategoryOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoCategories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            List<UserSoldProductCountOutputDto> dtoUsers = context.Users
                .Include(x => x.ProductsSold)
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .ToList()
                .Select(x => new UserSoldProductCountOutputDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductCountOutputDto
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(x => new ProductOutputDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToList()
                    }
                })
                .Take(10)
                .ToList();

            UserProductFinalOutputDto dtoUsersFinal = new UserProductFinalOutputDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = dtoUsers,
            };

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserProductFinalOutputDto), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoUsersFinal, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static void InitializeAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = mapperConfiguration.CreateMapper();
        }
    }
}