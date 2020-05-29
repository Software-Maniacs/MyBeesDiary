using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace My_Bees_Diary.Models.Entities
{
    [Table("Apiary")]
    public class Apiary
    {
        private decimal production;
        private int power;
        public Apiary()
        {
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
        public List<AreaPlants> PlantsInArea { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Apiary)
            {
                var that = obj as Apiary;
                return this.ID == that.ID && this.Name == that.Name
                    && this.Number == that.Number && this.Beehives == that.Beehives
                    && this.Date == that.Date && this.Location == that.Location
                && this.PlantsInArea == that.PlantsInArea && this.Production == that.Production
                && this.Type == that.Type;
            }
            return false;
        }


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