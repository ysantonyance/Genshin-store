using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class Controller
    {
        private Player player;
        private Banner currentBanner;
        private Shop shop;
        private List<Banner> availableBanners;

        public Controller()
        {
            player = new Player("Traveler", 1600, 100, 10, 100);
            availableBanners = new List<Banner>
            {
                new StandardBanner(),
                new EventBanner("Azure Wind", new Character("Jean", 5, "Anemo")),
                new EventBanner("Flamin Thunder", new Character("Diluc", 5, "Pyro"))
            };
            currentBanner = availableBanners[0];

            shop = new Shop();
        }

        public void Run()
        {
            Console.Title = "Genshin Impact Store";
            Console.ForegroundColor = ConsoleColor.Cyan;

            while (true)
            {
                Console.Clear();
                DisplayPlayerInfo();
                DisplayMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                }
            }

        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine("Genshin Impact Store");
            Console.WriteLine($"Player: {player.GetName()}");
            Console.WriteLine($"Primogems: {player.GetPrimogems()}");
            Console.WriteLine($"Genesis Crystals: {player.GetGenesisCrystals()}");
            Console.WriteLine($"Starglitter: {player.GetStarglitter()}");
            Console.WriteLine($"Stardust: {player.GetStardust()}");
            Console.WriteLine($"Current Banner: {currentBanner.Name}");
            Console.WriteLine(new string('-', 40));
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Make a wish (160 Primogems)");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Select Banner");
            Console.WriteLine("5. Save game");
            Console.WriteLine("6. Load game");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Choose action: ");
        }

        private void MakeWish()
        {
            Console.Clear();
            Console.WriteLine($"{currentBanner.Name}");
            currentBanner.PrintInfo();

            Console.WriteLine($"Your Primogems: {player.GetPrimogems()}");
            Console.WriteLine("Make a wish? (y/n): ");

            if (Console.ReadLine().ToLower() == "y")
            {
                try
                {
                    string result = currentBanner.MakeWish(player);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Press any key to conitnue...");
            Console.ReadKey();
        }

        private void OpenShop()
        {
            Console.Clear();
            Console.WriteLine("Shop");
            Console.WriteLine("1. Recommende items");
            Console.WriteLine("2. Skins");
            Console.WriteLine("3. Purchase with Starglitter");
            Console.WriteLine("4. Purchase with Primogems");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    shop.PrintRecommended();
                    break;
                case "2":
                    var skin = new Skin("Red Dead of Night", 5, "Diluc");

                    if (skin.CanPurchase(player))
                    {
                        Console.WriteLine($"Buy {skin.Name} for {skin.Price} GC (y/n): ");

                        if (Console.ReadLine().ToLower() == "y")
                            skin.Purchase(player);
                    }
                    else
                        Console.WriteLine("Not enough Genesis Crystals");
                    break;
                case "3":
                    Console.WriteLine("Available for Starglitter");
                    Console.WriteLine("1. Interwined Fate - 5 Starglitter");
                    Console.WriteLine("2. Acquiant Fate - 5 Staglitter");
                    Console.WriteLine("Choose: ");

                    string itemChoice = Console.ReadLine();

                    if (itemChoice == "1" || itemChoice == "2")
                    {
                        if (player.GetStarglitter() >= 5)
                        {
                            player.SetStarglitter(player.GetStarglitter() - 5);
                            player.SetPrimogems(player.GetPrimogems() + 160);
                            Console.WriteLine("Purchased! +160 Primogems");
                        }
                        else
                        {
                            Console.WriteLine("Not enough Starglitter");
                        }
                    }
                    break;


            }

            Console.WriteLine("Press any key to conitnue...");
            Console.ReadKey();
        }

        private void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("Inventory");

            Console.WriteLine("\nCharacters:");
            if (player.GetCharactersCount() > 0)
            {
                foreach (Character character in player.GetCharacters())
                {
                    Console.WriteLine($"  {character}");
                }
            }
            else
            {
                Console.WriteLine(" No characters");
            }

            Console.WriteLine("\nWeapons: ");
            if (player.GetWeaponsCount() > 0)
            {
                foreach (Weapon weapon in player.GetWeapons())
                {
                    Console.WriteLine($"  {weapon}");
                }
            }
            else
            {
                Console.WriteLine(" No weapons");
            }

            Console.WriteLine("\nSkins");
            if (player.GetSkinsCount() > 0)
            {
                foreach (Skin skin in player.GetSkins())
                {
                    Console.WriteLine($"  {skin}");
                }
            }
            else
            {
                Console.WriteLine($" No skins");
            }
        }
    }
}
