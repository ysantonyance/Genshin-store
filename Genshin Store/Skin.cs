using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class Skin : InventoryItem, IPurchasable
    {
        private string ForCharacter;
        public void SetForCharacter(string forCharacter)
        {
            this.ForCharacter = forCharacter;
        }
        public string GetForCharacter()
        {
            return ForCharacter;
        }
        public Skin(string name, int rarity, string forCharacter)
        {
            Name = name;
            Rarity = rarity;
            ForCharacter = forCharacter;

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("The name of the skin must not be empty");

            if (Rarity != 4 && Rarity != 5)
                throw new ArgumentException("Skins must only be 4* or 5*");

            if (string.IsNullOrWhiteSpace(ForCharacter))
                throw new ArgumentException("Character wasn't specified for the skin");
        }
        public int Price
        {
            get
            {
                return Rarity == 5 ? 2000 : 1680;
            }
        }

        public string CurrencyType => "GenesisCrystals";

        public bool CanPurchase(Player player)
        {
            return player.GetGenesisCrystals() >= Price;
        }

        public void Purchase(Player player)
        {
            if (!CanPurchase(player))
                throw new InvalidOperationException("Not enought Genesis Crystals to buy a skin");

            player.SetGenesisCrystals(player.GetGenesisCrystals() - Price);
            player.AddSkin(this);
            Console.WriteLine($"you bought {Name} for {Price} Genesis Crystals");
        }
    }
}
