using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace My_Bees_Diary.Models.Entities
{
    [Table("AreaPlants")]
    public class AreaPlants
{
        public AreaPlants()
        {

        }


        [Key, AutoIncrement]
        public int PlantsID { get; set; }
        [NotMapped]
        public virtual ICollection<Plant> PlantsList { get; set; }
        /* private List<string> plants = new List<string> { "Маргарит", "Бяла акация", "Бяла комуна", "Липа", "Рапица",
             "Слънчоглед", "Магарешки бодил", "Овощни дръвчета", "Билки" };*/

        [ForeignKey(typeof(Apiary))]
        public int ApiaryID { get; set; }
        [OneToOne]
        public virtual Apiary Apiary { get; set; }

        public bool Contain(string plant)
        {
            bool isContain = false;

            foreach (var plantInList in this.PlantsList)
            {
                if (plantInList.Equals(plant))
                {
                    isContain = true;
                    break;
                }
            }

            return isContain;
        }
    }
}
