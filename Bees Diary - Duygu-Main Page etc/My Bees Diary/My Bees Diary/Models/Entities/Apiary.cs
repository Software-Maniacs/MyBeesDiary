﻿using SQLite;
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
                return Honey + Wax + Propolis + Pollen + RoyalJelly + Poison;
            }
            private set
            {

            }
        }
        public decimal Honey { get; set; }
        public decimal Wax { get; set; }
        public decimal Propolis { get; set; }
        public decimal Pollen { get; set; }
        public decimal RoyalJelly { get; set; }
        public decimal Poison { get; set; }
        //public decimal Production { get; set; }
        public string Location { get; set; }
        [OneToMany]
        public virtual ICollection<Beehive> Beehives { get; set; }

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