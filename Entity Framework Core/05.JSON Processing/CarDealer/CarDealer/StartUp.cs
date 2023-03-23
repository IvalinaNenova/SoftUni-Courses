using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, inputJson);

            //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
            //string result = ImportParts(context, inputJson);

            //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
            //string result = ImportCars(context, inputJson);

            //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
            //string result = ImportCustomers(context, inputJson);

            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(context, inputJson);

            //string result = GetOrderedCustomers(context);
            //string result = GetCarsFromMakeToyota(context);
            //string result = GetLocalSuppliers(context);
            //string result = GetCarsWithTheirListOfParts(context);
            //string result = GetTotalSalesByCustomer(context);
            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        //Problem 09
        //public static string ImportSuppliers(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();

        //    ImportSupplierDto[] supliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
        //    Supplier[] suppliers = mapper.Map<Supplier[]>(supliersDtos);

        //    context.Suppliers.AddRange(suppliers);
        //    context.SaveChanges();

        //    return $"Successfully imported {suppliers.Length}.";
        //}

        //Problem 10
        //public static string ImportParts(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();

        //    ImportPartDtos[] partDtos = JsonConvert.DeserializeObject<ImportPartDtos[]>(inputJson);
        //    ICollection<Part> validParts = new HashSet<Part>();

        //    foreach (var partDto in partDtos)
        //    {
        //        if (context.Suppliers.Any(s => s.Id == partDto.SupplierId))
        //        {
        //            validParts.Add(mapper.Map<Part>(partDto));
        //        }
        //    }

        //    context.Parts.AddRange(validParts);
        //    context.SaveChanges();

        //    return $"Successfully imported {validParts.Count}.";
        //}

        //Problem 11
        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{
        //    var mapper = CreateMapper();
        //    ImportCarDtos[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDtos[]>(inputJson);
        //    ICollection<Car> validCars = new HashSet<Car>();
        //    ICollection<PartCar> validParts = new HashSet<PartCar>();

        //    foreach (var importCarDto in importCarDtos)
        //    {
        //        Car car = mapper.Map<Car>(importCarDto);
        //        validCars.Add(car);

        //        foreach (var partId in importCarDto.PartsId.Distinct())
        //        {
        //            PartCar partCar = new PartCar()
        //            {
        //                Car = car,
        //                PartId = partId,
        //            };
        //            validParts.Add(partCar);
        //        }
        //    }
        //    context.Cars.AddRange(validCars);
        //    context.PartsCars.AddRange(validParts);
        //    context.SaveChanges();
        //    return $"Successfully imported {validCars.Count}.";
        //}

        //Problem 12
        //public static string ImportCustomers(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();

        //    ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
        //    Customer[] customers = mapper.Map<Customer[]>(customerDtos);

        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();

        //    return $"Successfully imported {customers.Length}.";
        //}

        //Problem 13

        //public static string ImportSales(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();

        //    ImportSaleDtos[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDtos[]>(inputJson);
        //    Sale[] sales = mapper.Map<Sale[]>(saleDtos);

        //    context.Sales.AddRange(sales);
        //    context.SaveChanges();

        //    return $"Successfully imported {sales.Length}.";
        //}
        //private static IMapper CreateMapper()
        //{
        //    return new Mapper(new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<CarDealerProfile>();
        //    }));
        //}

        //Problem 14

        //public static string GetOrderedCustomers(CarDealerContext context)
        //{
        //    var customers = context
        //        .Customers
        //        .OrderBy(c => c.BirthDate)
        //        .ThenBy(c => c.IsYoungDriver)
        //        .Select(c => new
        //        {
        //            Name = c.Name,
        //            BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
        //            IsYoungDriver = c.IsYoungDriver
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return JsonConvert.SerializeObject(customers, Formatting.Indented);
        //}

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var orderedCarsToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();
            return JsonConvert.SerializeObject(orderedCarsToyota, Formatting.Indented);
        }

        //Problem 16
        //public static string GetLocalSuppliers(CarDealerContext context)
        //{
        //    var localSuppliers = context
        //        .Suppliers
        //        .Where(s => s.IsImporter == false)
        //        .Select(s => new
        //        {
        //            Id = s.Id,
        //            Name = s.Name,
        //            PartsCount = s.Parts.Count()
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        //}

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(cp => cp.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(cp => cp.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(cp => cp.Part.Price) * (1 - s.Discount/100)).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}