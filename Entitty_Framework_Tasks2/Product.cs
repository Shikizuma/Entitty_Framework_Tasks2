using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
     
    }
}
