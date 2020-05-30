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
    /// <summary>
    /// Entity Beehive.
    /// </summary>
    [Table("Beehive")]

    public class Beehive
    {
        /// <summary>
        /// Class constructor.
        /// </summary>

        public Beehive()
        {

        }

        [PrimaryKey, AutoIncrement]
        /// <summary>
        /// ID of the beehive in the database.
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// Name of the beehive.
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// Number of the beehive.
        /// </summary>

        public string Number { get; set; }
        /// <summary>
        /// Type of beehive.
        /// </summary>

        public string TypeBeehive { get; set; }
        /// <summary>
        /// Type of bees in the beehive.
        /// </summary>

        public string TypeBees { get; set; }
        /// <summary>
        /// Stores in the beehive.
        /// </summary>

        public int Stores { get; set; }

        /// <summary>
        /// Power of the beehive.
        /// </summary>
        /// <remarks>
        /// This can be found in the apiary entity code also. The beekeeper can use
        /// this to get the general idea of how the beehive is doing compared to the other
        /// beehives in the apiary. 

        public decimal Power { get; set; }
        /// <summary>
        /// The amount of feedings the beehive has received.
        /// </summary>

     
        public int Feedings { get; set; }
   
        /// <summary>
        /// The amount of reviews the beehive has received.
        /// </summary>

        public int Reviews { get; set; }
        /// <summary>
        /// The amount of treatments the beehive has received.
        /// </summary>
        public int Treatments { get; set; }

        //public decimal Production { get; set; }
        /// <summary>
        /// The total amount of what the beehive has produced.
        /// </summary>

        public decimal Production
        {
            get
            {
                return Honey + Wax + Propolis + Pollen + RoyalJelly + Poison;
            }
            private set
            {

            }
        }
        /// <summary>
        /// The honey that the beehive has produced.
        /// </summary>
        public decimal Honey { get; set; }
        /// <summary>
        /// The wax that the beehive has produced.
        /// </summary>
        public decimal Wax { get; set; }
        /// <summary>
        /// The propolis that the beehive has produced.
        /// </summary>
        public decimal Propolis { get; set; }
        /// <summary>
        /// The pollen that the beehive has produced.
        /// </summary>
        public decimal Pollen { get; set; }
        /// <summary>
        /// The Royal Jelly that the beehive has produced.
        /// </summary>
        public decimal RoyalJelly { get; set; }
        /// <summary>
        /// The poison that the beehive has produced.
        /// </summary>
        public decimal Poison { get; set; }
        /// <summary>
        /// ID of the apiary where the beehive is in.
        /// </summary>

        [ForeignKey(typeof(Apiary))]
        public int ApiaryID { get; set; }
        /// <summary>
        /// The apiary where the beehive is in.
        /// </summary>

        [ManyToOne]
        public virtual Apiary Apiary { get; set; }
        /// <summary>
        /// Method that prints the beehive's info.
        /// </summary>
        /// <returns>The beehive's info in a string format.</returns>


        public override string ToString()
        {
            return $"{ID} {Name} ({Number})";
        }
        /// <summary>
        /// This is used for the NUnit tests.
        /// </summary>
        /// <param name="obj">The other beehive.</param>
        /// <returns>A bool that indicates whether they are equal or not.</returns>

        public override bool Equals(object obj)
        {
            if (obj is Beehive)
            {
                var that = obj as Beehive;
                return this.ID == that.ID && this.Name == that.Name
                    && this.Number == that.Number && this.Power == that.Power
                /*&& this.Production == that.Production*/ && this.Reviews == that.Reviews
                && this.Treatments == that.Treatments && this.TypeBeehive == that.TypeBeehive
                && this.TypeBees == that.TypeBees && this.Feedings == that.Feedings &&
                this.Apiary == that.Apiary && this.ApiaryID == that.ApiaryID;
            }
            return false;
        }

    }
}
