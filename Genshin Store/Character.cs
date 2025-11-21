using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin_Store
{
    internal class Character
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
                if (value.Length > 25)
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
                if (value != 4 && value != 5)
                    throw new ArgumentException($"Characters can't be {value} star/s");
                rarity = value;
            }
        }

        private string element;

        public string Element
        {
            get
            {
                return element;
            }
            set
            {
                if (value != "Pyro" && value != "Cryo" && value != "Dendro" &&
                    value != "Geo" && value != "Hydro" && value != "Electro" &&
                    value != "Anemo")
                    throw new ArgumentException($"There's no such element as {value}");
                element = value;
            }
        }

        public Character(string name, int rarity, string element)
        {
            Name = name;
            Rarity = rarity;
            Element = element;
        }
        /*public void SetName(string name)
        {
            this.Name = name;
        }
        public string GetName()
        {
            return Name;
        }

        public void SetRarity(int rarity)
        {
            this.Rarity = rarity;
        }
        public int GetRarity()
        {
            return Rarity;
        }

        public void SetElement(string element)
        {
            this.Element = element;
        }

        public string GetElement()
        {
            return Element;
        }*/

        public override string ToString()
        {
            return $"{Name} ({Rarity}* {Element})";
        }
    }
}
