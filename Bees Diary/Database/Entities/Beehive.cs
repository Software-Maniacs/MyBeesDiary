using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Beehive
    {
        private string id;
        private string name;
        private string typeBeehive;
        private string typeBees;
        public Beehive()
        {

        }

        public Beehive(string name, string typeBeehive, string typeBees, int apiaryID)
        {
            this.Name = name;
            this.TypeBeehive = typeBeehive;
            this.TypeBees = typeBees;
            this.ApiaryID = apiaryID;
        }

        public string ID 
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = new Guid().ToString();
            }
        }
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The name cannot contain a whitespace or to be empty");
                }
                else if (value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The name's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public string TypeBeehive 
        {
            get
            {
                return this.typeBeehive;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The type of beehive cannot contain a whitespace or to be empty");
                }
                else if (value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The type's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.typeBeehive = value;
                }
            }
        }
        public string TypeBees 
        {
            get
            {
                return this.typeBees;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The type of bees cannot contain a whitespace or to be empty");
                }
                else if (value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The type's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.typeBees = value;
                }
            }
        }
        public int ApiaryID { get; set; }
        public virtual Apiary Apiary { get; set; }
    }
}
