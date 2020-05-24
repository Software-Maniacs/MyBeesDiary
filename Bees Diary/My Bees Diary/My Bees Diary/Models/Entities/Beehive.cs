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
    [Table("Beehive")]
    public class Beehive
    {
        public Beehive()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string TypeBeehive { get; set; }
        public string TypeBees { get; set; }
        public int Stores { get; set; }
        public decimal Production { get; set; }
        public decimal Power { get; set; }
        public int Feedings { get; set; }
        public int Reviews { get; set; }
        public int Treatments { get; set; }
        [ForeignKey(typeof(Apiary))]
        public int ApiaryID { get; set; }
        [ManyToOne]
        public virtual Apiary Apiary { get; set; }

        public override string ToString()
        {
            return $"{ID} {Name} ({Number})";
        }
    }
}
