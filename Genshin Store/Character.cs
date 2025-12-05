using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin_Store
{
    public class Character : InventoryItem, IWishable, IPurchasable
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

        public int Price => Rarity == 4 ? 25 : 15;
        public string CurrencyType => "Starglitter";

        public bool CanPurchase(Player player)
        {
            return player.GetStarglitter() >= Price;
        }

        public void Purchase(Player player)
        {
            if (!CanPurchase(player))
                throw new ArgumentException("Can't buy character");

            player.SetStarglitter(player.GetStarglitter() - Price);
            player.AddCharacter(this);
            Console.WriteLine($"You bought {this} for {Price} Starglitter");
        }

        public override string ToString()
        {
            return $"{Name} ({Rarity}* {Element})";
        }
    }
}
