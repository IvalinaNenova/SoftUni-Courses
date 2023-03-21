using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;

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

            string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            string result = ImportSales(context, inputJson);
            Console.WriteLine(result);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] supliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            Supplier[] suppliers = mapper.Map<Supplier[]>(supliersDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDtos[] partDtos = JsonConvert.DeserializeObject<ImportPartDtos[]>(inputJson);
            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var partDto in partDtos)
            {
                if (context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    validParts.Add(mapper.Map<Part>(partDto));
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();
            ImportCarDtos[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDtos[]>(inputJson);
            ICollection<Car> validCars = new HashSet<Car>();
            ICollection<PartCar> validParts = new HashSet<PartCar>();

            foreach (var importCarDto in importCarDtos)
            {
                Car car = mapper.Map<Car>(importCarDto);
                validCars.Add(car);

                foreach (var partId in importCarDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId,
                    };
                    validParts.Add(partCar);
                }
            }
            context.Cars.AddRange(validCars);
            context.PartsCars.AddRange(validParts);
            context.SaveChanges();
            return $"Successfully imported {validCars.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Problem 13

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDtos[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDtos[]>(inputJson);
            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}