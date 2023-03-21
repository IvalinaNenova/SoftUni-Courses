using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputJson);

            //string result = GetProductsInRange(context);
            //string result = GetSoldProducts(context);

            //string result = GetCategoriesByProductsCount(context);

            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportUserDto[] userDTOs = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto userDto in userDTOs)
            {
                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productDTOs = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productDTOs);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoriesDto[] categoriesDtos = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (ImportCategoriesDto categoriesDto in categoriesDtos)
            {
                if (String.IsNullOrEmpty(categoriesDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoriesDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            CategoryProduct[] categoryProduct = mapper.Map<CategoryProduct[]>(categoryProductDtos);

            context.CategoriesProducts.AddRange(categoryProduct);
            context.SaveChanges();

            return $"Successfully imported {categoryProduct.Length}";
        }
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName,
                    })
                        .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToArray()
                    })
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                usersCount = users.Length,
                users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}