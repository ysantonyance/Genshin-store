using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin_Store
{
    internal class Weapon
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 40)
                    throw new ArgumentException("The name is too long");
                name = value;
            }
        }

        private int rarity;

        public int Rarity
        {
            get
            {
                return rarity;
            }
            set
            {
                if (value != 3 && value != 4 && value != 5)
                    throw new ArgumentException($"Weapons can't be {value} star/s");
                rarity = value;
            }
        }

        private string type;

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != "Sword" && value != "Claymore" && value != "Polearm" &&
                    value != "Bow" && value != "Catalyst")
                    throw new ArgumentException($"Weapons can't be {value} type");
                type = value;
            }
        }

        public Weapon(string name, int rarity, string type)
        {
            Name = name;
            Rarity = rarity;
            Type = type;
        }

        /*public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetRarity(int rarity)
        {
            this.Rarity = rarity;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetRarity()
        {
            return Rarity;
        }*/

        public override string ToString()
        {
            return $"{Name} ({Rarity}* {Type})";
        }
    }
}
