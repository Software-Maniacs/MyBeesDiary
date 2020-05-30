using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace My_Bees_Diary.Models.Entities
{
    /// <summary>
    /// Entity Apiary.
    /// </summary>
    /// <remarks>
    /// Each apiary has a collection of beehives.
    /// </remarks>

    [Table("Apiary")]

    public class Apiary
    {
        private decimal production;
        private int power;

        /// <summary>
        /// Class constructor.
        /// </summary>

        public Apiary()
        {
        }

        ///<summary>
        ///ID of the apiary in the database.
        ///</summary>
        ///<remarks>
        ///The ID of the Apiary is automatically generated and cannot be set by the user.

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        /// <summary>
        ///  Name of the apiary.
        /// </summary>
        /// <remarks>
        /// With a name the user can easily differentiate between apiaries. 
        /// </remarks>

        public string Name { get; set; }
        /// <summary>
        /// Number of the apiary.
        /// </summary>
        /// <remarks>
        /// Every apiary has an unique number.
        /// </remarks>

        public string Number { get; set; }
        /// <summary>
        /// Type of the apiary.
        /// </summary>

        public string Type { get; set; }
        /// <summary>
        /// Time when the apiary has been added to the database.
        /// </summary>

        public DateTime Date { get; set; }
        /// <summary>
        /// This is the total amount that the apiary has produced.
        /// </summary>
        /// <remarks>
        /// It's calculated by adding the amount of each product that the apiary has produced.
        /// </remarks>
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
        /// The honey that the apiary has produced.
        /// </summary>
        public decimal Honey { get; set; }
        /// <summary>
        /// The wax that the apiary has produced.
        /// </summary>
        public decimal Wax { get; set; }
        /// <summary>
        /// The propolis that the apiary has produced.
        /// </summary>
        public decimal Propolis { get; set; }
        /// <summary>
        /// The pollen that the apiary has produced.
        /// </summary>
        public decimal Pollen { get; set; }
        /// <summary>
        /// The Royal Jelly that the apiary has produced.
        /// </summary>
        public decimal RoyalJelly { get; set; }
        /// <summary>
        /// The poison that the apiary has produced.
        /// </summary>
        public decimal Poison { get; set; }
        //public decimal Production { get; set; }
        /// <summary>
        /// Location of the apiary.
        /// </summary>

        public string Location { get; set; }
        /// <summary>
        /// Beehives that are in the apiary.
        /// </summary>

        [OneToMany]
        public virtual ICollection<Beehive> Beehives { get; set; }


        /// <summary>
        /// This is used for the NUnit tests.
        /// </summary>
        /// <param name="obj">The other beehive that this beehive has to be compared to</param>
        /// <returns>Bool that indicates whether they are equal or not.</returns>

        public override bool Equals(object obj)
        {
            if (obj is Apiary)
            {
                var that = obj as Apiary;
                return this.ID == that.ID && this.Name == that.Name
                    && this.Number == that.Number && this.Beehives == that.Beehives
                    && this.Date == that.Date && this.Location == that.Location
                    && this.Production == that.Production && this.Type == that.Type;
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