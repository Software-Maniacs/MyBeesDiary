using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace My_Bees_Diary.Models.Entities
{
    [Table("Apiary")]
    public class Apiary
    { 
        public Apiary()
        {
            this.Beehives = new HashSet<Beehive>();
            this.PlantsInArea = new List<AreaPlants>();
        }
        
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }

        public int Production { get; set; }
        public string Location { get; set; }
        [OneToMany]
        public virtual ICollection<Beehive> Beehives { get; set; }
        public virtual ICollection<AreaPlants> PlantsInArea { get; set; }


    }
}