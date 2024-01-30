using Microsoft.IdentityModel.Tokens;

namespace Entity_Framework_HomeTasks2
{
    internal class Program
    {
        /*   
    Завдання 1
       Відкрити рішення завданя 2 (1 урок)
       Потрібно:
       * Обмежити всі строкові властивості (обмеження підбирати, виходячи з призначення поля) через DataAnnotations.
       * Змінити назву Id на – (НазваКласу)Id.
       * Для полів з типом DateTime вказати тип Date через DataAnnotations Внести всі зміни у базу.
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
        }
    }
}