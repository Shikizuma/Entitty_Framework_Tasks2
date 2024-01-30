using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Task2
{
    internal class Program
    {
        /*
         Завдання 2
            Відкрити рішення завданя 1 (цього уроку)
            Створити новий перелічуваний тип StatusCode зі значенями:
            1) Ok = 200
            2) NotFound = 404
            3) Server = 500
            Створити новий клас Error де є:
            1) + Message: string
            2) + Time: DateTime
            3) + Request: string
            4) + Status: StatusCode.
            Додати у клас контексту MyDatabaseContext нову колекцію DbSet з типом Error.
            Додати до існуючої колекції додаткове поле (НазваКласу)AlterId, налаштувати через Fluent API цю властивість таким чином, щоб у базі це був складовий ключ.
            Налаштувати через Fluent API ігнорування типу Error та внести зміни у базу Створити конструкцію обробки виключень і у блок catch при невдалому зчитуванні з бази у контексті заповнювати колекцію Error (для перевірки спробуйте отримати від’ємний індекс).
            Якщо все правильно, то Ви будете заповнювати колекцію з помилками при невірному запиті, але сама таблиця у базі буде відсутня.
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