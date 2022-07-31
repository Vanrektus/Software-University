using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                // 01
                //string usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
                //Console.WriteLine(ImportUsers(context, usersJsonAsString));

                // 02
                //string productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
                //Console.WriteLine(ImportProducts(context, productsJsonAsString));

                // 03
                //string categoriesJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
                //Console.WriteLine(ImportCategories(context, categoriesJsonAsString));

                // 04
                //string categoriesProductsJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");
                //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJsonAsString));

                // 05
                //Console.WriteLine(GetProductsInRange(context));

                // 06
                //Console.WriteLine(GetSoldProducts(context));

                // 07
                //Console.WriteLine(GetCategoriesByProductsCount(context));

                // 08
                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<UserInputDto> dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<ProductInputDto> dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<CategoryInputDto> dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(x => x.Name != null);

            IEnumerable<Category> mappedCategories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<CategoryProductInputDto> dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputDto>>(inputJson);

            IEnumerable<CategoryProduct> mappedCategoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoriesProducts.Count()}";
        }

        // 05. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializerAutoMapper();

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductOutputDto>(mapper.ConfigurationProvider)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            };

            string productsAsJson = JsonConvert.SerializeObject(products, settings);

            return productsAsJson;
        }

        // 06. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializerAutoMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserOutputDto>(mapper.ConfigurationProvider)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            };

            string usersAsJson = JsonConvert.SerializeObject(users, settings);

            return usersAsJson;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializerAutoMapper();

            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .ProjectTo<CategoryOutputDto>(mapper.ConfigurationProvider)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            };

            string categoriesAsJson = JsonConvert.SerializeObject(categories, settings);

            return categoriesAsJson;
        }

        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializerAutoMapper();

            //var users = context.Users
            //    .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Count(p => p.BuyerId != null) > 0)
            //    .ProjectTo<UserInfoDto>(mapper.ConfigurationProvider)
            //    .OrderByDescending(x => x.SoldProducts.Products.Count())
            //    .ToList();

            var users = context.Users
                .Include(u => u.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Count(p => p.BuyerId != null) > 0)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId != null),
                        Products = u.ProductsSold
                                     .Where(p => p.BuyerId != null)
                                    .Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .ToList()
                    }

                })
                .OrderByDescending(u => u.SoldProducts.Products.Count)
                .ToList();

            var usersOutput = new
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            string usersAsJson = JsonConvert.SerializeObject(usersOutput, settings);

            return usersAsJson;
        }

        private static void InitializerAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = config.CreateMapper();
        }
    }
}