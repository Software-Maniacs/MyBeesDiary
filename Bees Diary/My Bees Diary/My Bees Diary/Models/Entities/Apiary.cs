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
        private int power;
        public Apiary()
        {
            this.Beehives = new List<Beehive>();
            this.PlantsInArea = new AreaPlants();
            this.power = 0;
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
        public virtual ICollection<Beehive> Beehives { get; set; }
        [OneToOne]
        public AreaPlants PlantsInArea { get; set; }

        /*public override string ToString()
        {
            return $" {Name} {Number} ({Type}) {Production} {power} {Location}";
        }*/

        public override string ToString()
        {
            return $"{ID} {Name} ({Number})";
        }
    }
}