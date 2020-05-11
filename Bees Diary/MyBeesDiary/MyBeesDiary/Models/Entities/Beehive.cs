using System;
using System.Collections.Generic;
using System.Text;

namespace MyBeesDiary.Models.Entities
{
    public class Beehive
    {
        public Beehive()
        {

        }

        public int ID { get; set; }
        public string TypeBeehive { get; set; }
        public string TypeBees { get; set; }
        public int ApiaryID { get; set; }

        public virtual Apiary Apiary { get; set; }
    }
}
