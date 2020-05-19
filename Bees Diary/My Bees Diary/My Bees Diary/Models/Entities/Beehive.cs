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
        public Beehive(string typeBeehive, string typeBees, decimal production, decimal power, int apiaryID, Apiary apiary)
        {
            this.TypeBeehive = typeBeehive;
            this.TypeBees = typeBees;
            this.Production = production;
            this.Power = power;
            this.ApiaryID = apiaryID;
            this.Apiary = apiary;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TypeBeehive { get; set; }
        public string TypeBees { get; set; }
        public decimal Production { get; set; }
        public decimal Power { get; set; }
        [ForeignKey(typeof(Apiary))]
        public int ApiaryID
        {
            get
            {
                return this.Apiary.ID;
            }
            private set
            {
            }
        }
        [ManyToOne]
        public virtual Apiary Apiary { get; set; }
    }
}
