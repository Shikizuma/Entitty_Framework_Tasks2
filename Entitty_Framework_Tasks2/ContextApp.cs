using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_HomeTasks2
{
    /*   
    Завдання 1
       Відкрити рішення завданя 2 (1 урок)
       Потрібно:
       * Обмежити всі строкові властивості (обмеження підбирати, виходячи з призначення поля) через DataAnnotations.
       * Змінити назву Id на – (НазваКласу)Id.
       * Для полів з типом DateTime вказати тип Date через DataAnnotations Внести всі зміни у базу.
*/
    public class ContextApp : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=HomeTaskFirst; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
