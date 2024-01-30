using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
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
    public class ContextApp : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=HomeTaskFirst; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().HasAlternateKey(e => e.AlterId);
            modelBuilder.Entity<Error>().Property(p => p.AlterId).HasColumnName("Error_AlternativeId");     
            modelBuilder.Entity<Product>().Ignore(p => p.Error);
        }
    }
}
