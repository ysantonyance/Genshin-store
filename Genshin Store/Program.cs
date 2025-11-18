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
            /*Name = "Traveller",
            Primogems = 1000,
            GenesisCrystals = 300,
            Starglitter = 5,
            Stardust = 150*/
            Player player = new Player("Traveller", 1000, 300, 5, 150);
            var shop = new Shop();
            var banner = new WishBanner();

            Console.WriteLine($"Rn you, {player.GetName()}, have:\n");
            Console.WriteLine($"{player.GetPrimogems()} Primogems");
            Console.WriteLine($"{player.GetGenesisCrystals} Genesis Crystals");
            Console.WriteLine($"{player.GetStarglitter} Starglitter");
            Console.WriteLine($"{player.GetStardust} Stardust");
            Console.WriteLine();

            shop.PrintRecommended();
            shop.BuyWelkinMoon(player);
            Console.WriteLine($"Current Genesis Crystals: {player.GetGenesisCrystals}");

            Console.WriteLine();

            var wishResult = banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            wishResult += banner.MakeWish(player);
            Console.WriteLine($"Wish result:\n {wishResult}\n");
            Console.WriteLine($"Current Primogems: {player.GetPrimogems}");
            Console.WriteLine($"Current Starglitter: {player.GetStarglitter}");
            Console.WriteLine($"Current Stardust: {player.GetStardust}");

            Console.WriteLine();

            Console.WriteLine($"Characters: {player.GetCharactersCount}");
            Console.WriteLine($"Weapons: {player.GetWeaponsCount}");
            Console.WriteLine($"Outfits: {player.GetSkinsCount}");

            Console.WriteLine();

            shop.PrintOutfits();
            Console.WriteLine();
            bool bought = shop.BuyOutfit(player, "Red Dead of Night (Diluc)", 1680);
            Console.WriteLine($"Purchase: {bought}");
            Console.WriteLine($"Current GC: {player.GetGenesisCrystals}");
        }
    }
}
