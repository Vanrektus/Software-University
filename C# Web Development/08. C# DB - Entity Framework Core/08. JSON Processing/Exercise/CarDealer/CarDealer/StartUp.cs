using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            using CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // 09
            //string suppliersJsonAsString = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersJsonAsString));

            // 10
            //string partsJsonAsString = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, partsJsonAsString));

            // 11
            //string carsJsonAsString = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, carsJsonAsString));

            // 12
            //string customersProductsJsonAsString = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, customersProductsJsonAsString));

            // 13
            //string salesProductsJsonAsString = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, salesProductsJsonAsString));

            // 14
            //Console.WriteLine(GetOrderedCustomers(context));

            // 15
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            // 16
            //Console.WriteLine(GetLocalSuppliers(context));

            // 17
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // 18
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            // 19
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<SupplierInputDto> dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputDto>>(inputJson);

            IEnumerable<Supplier> mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializerAutoMapper();

            List<int> suppliersIds = context.Suppliers.Select(x => x.Id).ToList();

            IEnumerable<PartInputDto> dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartInputDto>>(inputJson)
                .Where(x => suppliersIds.Contains(x.SupplierId));

            IEnumerable<Part> mappedParts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<CarInputDto> dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarInputDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (CarInputDto currDtoCar in dtoCars)
            {
                Car newCar = new Car
                {
                    Make = currDtoCar.Make,
                    Model = currDtoCar.Model,
                    TravelledDistance = currDtoCar.TravelledDistance,
                };
                foreach (int partId in currDtoCar.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<CustomerInputDto> dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            IEnumerable<Customer> mappedCustomers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializerAutoMapper();

            IEnumerable<SaleInputDto> dtoSales = JsonConvert.DeserializeObject<IEnumerable<SaleInputDto>>(inputJson);

            IEnumerable<Sale> mappedSales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        // 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
            .OrderBy(x => x.BirthDate)
            .ThenBy(x => x.IsYoungDriver == true)
            .Select(x => new
            {
                x.Name,
                BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                x.IsYoungDriver
            })
            .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // 15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                }).ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(x => new
            {
                car = new
                {
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                },
                parts = x.PartCars.Select(y => new
                {
                    y.Part.Name,
                    Price = y.Part.Price.ToString("F2")
                })
            })
           .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
            .Where(x => x.Sales.Count > 0)
            .Select(x => new
            {
                fullName = x.Name,
                boughtCars = x.Sales.Count,
                spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(p => p.Part.Price))
            })
           .OrderByDescending(x => x.spentMoney)
           .ThenByDescending(x => x.boughtCars)
           .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new
            {
                car = new
                {
                    x.Car.Make,
                    x.Car.Model,
                    x.Car.TravelledDistance
                },
                customerName = x.Customer.Name,
                Discount = x.Discount.ToString("F2"),
                price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("F2")
            })
            .Take(10)
            .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static void InitializerAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            mapper = config.CreateMapper();
        }
    }
}