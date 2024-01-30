using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public class Product
    {
        [Column("Product_Id")]
        public Guid Id { get; set; }
        [MaxLength(80), MinLength(3)]
        public string Name { get; set; }
        public double Cost { get; set; }
        [MaxLength(500), MinLength(15)]
        public string? Description { get; set; }
        public int Quintity { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Created { get; set; }
     
        public Error Error { get; set; }
    }
}
