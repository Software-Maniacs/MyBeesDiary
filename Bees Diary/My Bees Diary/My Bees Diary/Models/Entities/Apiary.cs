using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace My_Bees_Diary.Models.Entities
{
    [Table("Apiary")]
    public class Apiary
    {
        private decimal production;
        private int power = 0;
        public Apiary()
        {
            //this.Beehives = new HashSet<Beehive>();
            this.PlantsInArea = new List<AreaPlants>();
        }
        
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public decimal Production
        {
            get
            {
                return production;
            }
            set
            {
                production += value;
                this.power++;
            }
        }
        public string Location { get; set; }
        [OneToMany]
       // public virtual ICollection<Beehive> Beehives { get; set; }
        public virtual ICollection<AreaPlants> PlantsInArea { get; set; }

        public override string ToString()
        {
            return $" {Name} {Number} ({Type}) {Production} {power} {Location}";
        }
        

    }
}