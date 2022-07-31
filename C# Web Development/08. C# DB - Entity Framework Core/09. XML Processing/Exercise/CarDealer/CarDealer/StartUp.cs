using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // 09
            //string suppliersXmlAsString = File.ReadAllText("./Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXmlAsString));

            // 10
            //string partsXmlAsString = File.ReadAllText("./Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXmlAsString));

            // 11
            //string carsXmlAsString = File.ReadAllText("./Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXmlAsString));

            // 12
            //string customersProductsXmlAsString = File.ReadAllText("./Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersProductsXmlAsString));

            // 13
            //string salesProductsXmlAsString = File.ReadAllText("./Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesProductsXmlAsString));

            // 14
            //Console.WriteLine(GetCarsWithDistance(context));

            // 15
            //Console.WriteLine(GetCarsFromMakeBmw(context));

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
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SupplierInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<SupplierInputDto> dtoSuppliers = (List<SupplierInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();
            List<Supplier> suppliers = mapper.Map<List<Supplier>>(dtoSuppliers);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }


        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PartInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<PartInputDto> dtoParts = (List<PartInputDto>)xmlSerializer.Deserialize(stringReader);

            List<int> existingSuppliersIds = context.Suppliers.Select(x => x.Id).ToList();

            InitializeAutoMapper();

            List<Part> parts = mapper.Map<List<Part>>(dtoParts)
                .Where(x => existingSuppliersIds.Contains(x.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<CarInputDto> dtoCars = (List<CarInputDto>)xmlSerializer.Deserialize(stringReader);

            List<int> existingPartIds = context.Parts.Select(x => x.Id).ToList();

            List<Car> cars = dtoCars.Select(x => new Car
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance,
                PartCars = x.PartsIds.Select(x => x.Id).Intersect(existingPartIds).Distinct()
                .Select(y => new PartCar
                {
                    PartId = y
                })
                 .ToList(),
            })
            .ToList();

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CustomerInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<CustomerInputDto> dtoCustomers = (List<CustomerInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();
            List<Customer> customers = mapper.Map<List<Customer>>(dtoCustomers);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SaleInputDto>), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);

            List<SaleInputDto> dtoSales = (List<SaleInputDto>)xmlSerializer.Deserialize(stringReader);

            InitializeAutoMapper();

            List<int> existingCarsIds = context.Cars.Select(x => x.Id).ToList();

            List<Sale> sales = mapper.Map<List<Sale>>(dtoSales)
                .Where(x => existingCarsIds.Contains(x.CarId)).ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<CarOutputDto> dtoCars = mapper.Map<List<CarOutputDto>>(context.Cars);

            List<CarOutputDto> cars = dtoCars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<CarMakeBMWOutputDto> dtoBMWCars = mapper.Map<List<CarMakeBMWOutputDto>>(context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance))
                .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarMakeBMWOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoBMWCars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<Supplier> filteredSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Include(x => x.Parts)
                .ToList();

            List<SupplierOutputDto> dtoSuppliers = mapper.Map<List<SupplierOutputDto>>(filteredSuppliers);

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SupplierOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoSuppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            List<CarWithPartOutputDto> dtoCars = context.Cars.Select(x => new CarWithPartOutputDto
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance,
                CarParts = x.PartCars.Select(p => new CarPartOutputDto
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price

                })
                .OrderByDescending(x => x.Price)
                .ToList()
            })
            .OrderByDescending(x => x.TravelledDistance)
            .ThenBy(x => x.Model)
            .Take(5)
            .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarWithPartOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoCars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            List<CustomerOutputDto> dtoCustomers = context.Customers
                 .Where(x => x.Sales.Count > 0)
                 .Select(x => new CustomerOutputDto
                 {
                     Name = x.Name,
                     BoughtCars = x.Sales.Count,
                     SpentMoney = x.Sales.Select(s => s.Car).SelectMany(pc => pc.PartCars).Sum(p => p.Part.Price)
                 })
                 .OrderByDescending(x => x.SpentMoney)
                 .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CustomerOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoCustomers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            List<SaleOutputDto> dtoSales = context.Sales.Select(x => new SaleOutputDto
            {
                SoldCar = new SoldCarOutputDto
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance

                },
                Discount = x.Discount,
                CustomerName = x.Customer.Name,
                Price = x.Car.PartCars.Sum(p => p.Part.Price),
                PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100

            })
            .ToList();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SaleOutputDto>), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, dtoSales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static void InitializeAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            mapper = mapperConfiguration.CreateMapper();
        }
    }
}