using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin_Store
{
    public class Weapon : InventoryItem, IWishable, IPurchasable
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

        private int price;

        public int Price
        {
            get
            {
                return Rarity == 4 ? 25 : 
                    Rarity == 3 ? 15 : 10;
            }
        }

        public bool IsCharacter()
        {
            return false;
        }

        private string currencyType = "Starglitter";

        public string CurrencyType
        {
            get
            {
                return currencyType;
            }
        }

        public bool CanPurchase(Player player)
        {
            return player.GetStarglitter() >= Price;
        }

        public void Purchase (Player player)
        {
            if (!CanPurchase(player))
                throw new ArgumentException("Can't buy weapon");

            player.SetStarglitter(player.GetStarglitter() - Price);
            player.AddWeapon(this);
            Console.WriteLine($"You bought {this} for {Price} Starglitter");
        }


    }
}
