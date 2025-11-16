using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Program
    {
        static void Main()
        {
            var player = new Player()
            {
                Name = "Traveller",
                Primogems = 1000,
                GenesisCrystals = 300,
                Starglitter = 5,
                Stardust = 150
            };
            var shop = new Shop();
            var banner = new WishBanner();

            Console.WriteLine($"Rn you, {player.Name}, have:\n");
            Console.WriteLine($"{player.Primogems} Primogems");
            Console.WriteLine($"{player.GenesisCrystals} Genesis Crystals");
            Console.WriteLine($"{player.Starglitter} Starglitter");
            Console.WriteLine($"{player.Stardust} Stardust");
            Console.WriteLine();

            shop.PrintRecommended();
            shop.BuyWelkinMoon(player);
            Console.WriteLine($"Current Genesis Crystals: {player.GenesisCrystals}");

            Console.WriteLine();

            var wishResult = banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            Console.WriteLine($"Wish result:\n {wishResult}\n");
            Console.WriteLine($"Current Primogems: {player.Primogems}");
            Console.WriteLine($"Current Starglitter: {player.Starglitter}");
            Console.WriteLine($"Current Stardust: {player.Stardust}");

            Console.WriteLine();

            Console.WriteLine($"Characters: {player.Characters.Count}");
            Console.WriteLine($"Weapons: {player.Weapons.Count}");
            Console.WriteLine($"Outfits: {player.Outfits.Count}");

            Console.WriteLine();

            shop.PrintOutfits();
            Console.WriteLine();
            bool bought = shop.BuyOutfit(player, "Red Dead of Night (Diluc)", 1680);
            Console.WriteLine($"Purchase: {bought}");
            Console.WriteLine($"Current GC: {player.GenesisCrystals}");
        }
    }
}
