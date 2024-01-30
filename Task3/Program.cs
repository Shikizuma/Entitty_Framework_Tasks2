using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Task3
{
    internal class Program
    {
        /*
           Завдання 3*
           Продовжуйте завданя 2 (цього уроку).
           Спробуйте налаштувати все без застосування DataAnnotations.
           Частіше Ви будете зустрічати налаштування через Fluent API (Приклад), тому варто вміти реалізовувати двома способами.
    */

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            using (ContextApp context = new ContextApp())
            {
                products = context.Products.ToList();
            }

            if (products.IsNullOrEmpty())
            {
                ProductFactory factory = new ProductFactory();
                for (int i = 1; i <= 10; i++)
                {
                    products.Add(factory.CreateProduct(i));
                }

                using (ContextApp context = new ContextApp())
                {
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }
            }
            Console.WriteLine("DataBase is fulled!");

            try
            {
                using (var context = new ContextApp())
                {                  
                    var product = context.Products.Find(-1);

                    if (product == null)
                    {
                        var error = new Error
                        {
                            Message = "Product not found",
                            Time = DateTime.Now,
                            Request = "Invalid request",
                            Status = StatusCode.NotFound
                        };

                        context.Errors.Add(error);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException dbUpdateEx)
            {
                Console.WriteLine($"Database update error: {dbUpdateEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
    }
}