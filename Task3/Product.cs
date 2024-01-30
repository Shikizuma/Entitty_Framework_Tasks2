using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /*
      Завдання 3*
      Продовжуйте завданя 2 (цього уроку).
      Спробуйте налаштувати все без застосування DataAnnotations.
      Частіше Ви будете зустрічати налаштування через Fluent API (Приклад), тому варто вміти реалізовувати двома способами.
*/

    public class Product
    {
        public Guid Id { get; set; }
        [MaxLength(80), MinLength(3)]
        public string Name { get; set; }
        public double Cost { get; set; }
        public string? Description { get; set; }
        public int Quintity { get; set; }
        public DateTime? Created { get; set; }

        public Error Error { get; set; }
    }
}
