using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Shop
    {
        private List<StoreItem> items = new List<StoreItem>();
        public void AddItem(StoreItem item) => items.Add(item);

        public void ShowItems()
        {
            Console.WriteLine("SHOP");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} ({item.Type}) — {item.Price} primogems");
            }
        }
        
        public void PrintRecommended()
        {
            Console.WriteLine("Recommended:");
            Console.WriteLine("1. Blessing of the Welkin Moon - $5");
            Console.WriteLine("\t(300 Genesis Cystals + 90 Primogems daily for 30 days)");
        }

        public void PrintSkins()
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
            player.SetGenesisCrystals(player.GetGenesisCrystals() + 300);
            return true;
        }

        public bool BuyOutfit(Player player, Skin skinName, int price)
        {
            if (player.GetGenesisCrystals() >= price)
            {
                player.SetGenesisCrystals(player.GetGenesisCrystals() - price);
                player.AddSkin(skinName);
                Console.WriteLine($"Bought {skinName}");
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

            if (player.GetStarglitter() >= price)
            {
                player.SetStarglitter(player.GetStarglitter() - price);

                if (item.Contains("Fate") || item.Contains("fate"))
                {
                    player.SetPrimogems(player.GetPrimogems() + 160);
                    Console.WriteLine($"Bought {item}! +160 Primogems");
                }
                return true;
            }

            Console.WriteLine("Not enough Starglitter");
            return false;
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

            if (player.GetStardust() >= price)
            {
                player.SetStardust(player.GetStardust() - price);

                if (item.Contains("Fate") || item.Contains("fate"))
                {
                    player.SetPrimogems(player.GetPrimogems() + 160);
                    Console.WriteLine($"Bought {item}! +160 Primogems");
                }
                else
                {
                    Console.WriteLine($"Bought {item}!");
                }
                return true;
            }

            Console.WriteLine("Not enough Stardust");
            return false;
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

            if (player.GetPrimogems() >= price)
            {
                player.SetPrimogems(player.GetPrimogems() - price);

                if (item.Contains("Fate") || item.Contains("fate"))
                {
                    player.SetPrimogems(player.GetPrimogems() + 160);
                    Console.WriteLine($"Bought {item}! +160 Primogems");
                }
                else
                {
                    Console.WriteLine($"Bought {item}!");
                }
                return true;
            }

            Console.WriteLine("Not enough Primogems");
            return false;
        }
        
        public void BuyItem(Player player, string itemName)
        {
            StoreItem item = items.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                Console.WriteLine("Такого товара нет!");
                return;
            }

            if (player.GetPrimogems() < item.Price)
            {
                Console.WriteLine("Not enough Primogems!");
                return;
            }

            player.SpendPrimogems(item.Price);

            switch (item.Type)
            {
                case "Character":
                    player.AddCharacter(new Character() { Name = item.Name });
                    Console.WriteLine($"Bought character {item.Name}!");
                    break;

                case "Weapon":
                    player.AddWeapon(new Weapon() { Name = item.Name });
                    Console.WriteLine($"Bought weapon {item.Name}!");
                    break;

                case "Skin":
                    player.AddSkin(new Skin() { Name = item.Name });
                    Console.WriteLine($"Bought skin {item.Name}!");
                    break;

                default:
                    Console.WriteLine("Unknown item type!");
                    break;
            }
        }
    }
}


