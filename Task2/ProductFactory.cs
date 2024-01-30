using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class ProductFactory
    {
        public Product CreateProduct(int number)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = $"Product{number}",
                Cost = number * 10.0,
                Description = $"Description{number}",
                Quintity = number
            };
        }


    }
}
