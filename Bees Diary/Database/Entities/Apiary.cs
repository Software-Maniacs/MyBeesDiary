using System.Collections.Generic;

namespace Database.Entities
{
    public class Apiary
    {
        public Apiary()
        {
            this.Beehives = new HashSet<Beehive>();
            this.PlantsInArea = new List<string>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }

        public int Production { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Beehive> Beehives { get; set; }
        public ICollection<string> PlantsInArea { get; set; }


    }
}