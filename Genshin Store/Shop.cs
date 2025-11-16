using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Shop
    {
        public void PrintRecommended()
        {
            Console.WriteLine("Recommended:");
            Console.WriteLine("1. Blessing og the Welkin Moon - $5");
            Console.WriteLine("\t(300 Genesis Cystals + 90 Primogems daily for 30 days)");
        }

        public void PrintOutfits()
        {
            Console.WriteLine("Characters' Outfits:");
            Console.WriteLine("1. Red Dead of Night (Diluc) - 1680 GC");
            Console.WriteLine("2. Blossoming Starlight (Klee) - 1350 GC");
            Console.WriteLine("3. Summertime Sparkle (Barbara) - 1350 GC");
        }

        public void PrintPrimogemShop()
        {
            Console.WriteLine("");
        }

        public bool BuyWelkinMoon(Player player)
        {
            Console.WriteLine("Purchased Welkin Moon!\n+300 GC, will receive 90 Primogems daily");
            player.GenesisCrystals += 300;
            return true;
        }

        public bool BuyOutfit(Player player, string outfitName, int price)
        {
            if (player.GenesisCrystals >= price)
            {
                player.GenesisCrystals -= price;
                player.Outfits.Add(outfitName);
                Console.WriteLine($"Bought {outfitName}");
                return true;
            }
            Console.WriteLine($"Not enough Genesis Crystals");
            return false;
        }

        public bool BuyWithStarglitter(Player player, string item, int price)
        {
            /*if Starglitter >= price
                st -= price
                if item contains fate Primogems += 160
                else weapon add item
                return true

            else
                not enough st
                return true*/
            return true;
        }

        public bool BuyWithStardust(Player player, string item, int price)
        {
            /*if Stardust >= price
                st -= price
                if item contains fate Primogems += 160
                return true

            else
                not enough st
                return true*/
            return true;
        }

        public bool BuyWithPrimogems(Player player, string item, int price)
        {
            /*if Primogems >= price
                st -= price
                 Primogems += 160
                return true

            else
                not enough Primogems
                return true*/
            return true;
        }

    }
}
