using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace My_Bees_Diary.Models.Entities
{
    [Table("AreaPlants")]
    public class AreaPlants
    {
        [PrimaryKey, AutoIncrement]
        public int PlantsID { get; set; }
        public List<string> PlantsList { get; set; }
        /* private List<string> plants = new List<string> { "Маргарит", "Бяла акация", "Бяла комуна", "Липа", "Рапица",
             "Слънчоглед", "Магарешки бодил", "Овощни дръвчета", "Билки" };*/

    }
}
