using System;
using System.Collections.Generic;

namespace Database.Entities
{
    public class Apiary
    {
        private string id;
        private string name;
        private string type;
        private string location;
        private decimal power;
        private decimal production;
        private ICollection<Beehive> beehives;
        private ICollection<string> plantsInArea;

        public Apiary()
        {
            this.Beehives = new HashSet<Beehive>();
            this.PlantsInArea = new List<string>();
        }

        public Apiary(string name, string type, string location, DateTime creationTime)
        {
            this.Name = name;
            this.Type = type;
            this.Location = location;
            this.CreationTime = creationTime;
        }

        public Apiary(string name, string type, string location, DateTime creationTime, ICollection<Beehive> beehives)
            :this(name, type, location, creationTime)
        {
            this.Beehives = beehives;
        }

        public Apiary(string name, string type, string location, DateTime creationTime, decimal production)
            :this(name, type, location, creationTime)
        {
            this.Production = production;
        }

        public Apiary(string name, string type, string location, DateTime creationTime, decimal production, ICollection<Beehive> beehives)
            : this(name, type, location, creationTime, production)
        {
            this.beehives = beehives;
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
                return name;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The name cannot contain a whitespace or to be empty");
                }
                else if(value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The name's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.name = value;
                }
            } 
        }
        public string Type 
        {
            get
            {
                return this.type;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The type cannot contain a whitespace or to be empty");
                }
                else if (value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The type's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.type = value;
                }
            }
        }
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The location cannot contain a whitespace or to be empty");
                }
                else if (value.Length < 5 || value.Length > 45)
                {
                    throw new Exception("The location's length cannot be less than 5 symbols and more than 45 symbols");
                }
                else
                {
                    this.location = value;
                }
            } 
        }
        public decimal Power 
        {
            get
            {
                return this.power;
            }
            private set
            {
                //We have to think about a formula
            }
        }
        public decimal Production 
        {
            get
            {
                return this.production;
            }
            set
            {
                if(value < 0)
                {
                    throw new Exception("The production cannot be less than zero");
                }
                else
                {
                    this.production = value;
                }
            }
        }
        public DateTime CreationTime { get; set; }
        public virtual ICollection<Beehive> Beehives 
        {
            get
            {
                return this.beehives;
            }
            set
            {
                this.beehives = value;
            }
        }
        public ICollection<string> PlantsInArea 
        {
            get
            {
                return this.plantsInArea;
            }
            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                    {
                        throw new Exception("The name cannot contain a whitespace or to be empty");
                    }
                    else if (item.Length < 5 || item.Length > 45)
                    {
                        throw new Exception("The name's length cannot be less than 5 symbols and more than 45 symbols");
                    }
                }

                this.plantsInArea = value;
            }
        }
    }
}