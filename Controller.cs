using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
            player = new Player("Traveler", 160000, 100, 10, 100);

            var event5StarWeapons = new List<Weapon>
            {
                new Weapon("Athame Artis", 5, "Sword"),
                new Weapon("The Daybreak Chronicles", 5, "Bow")
            };

            var event4StarWeapons = new List<Weapon>
            {
                new Weapon("The Alley Flash", 4, "Sword"),
                new Weapon("Prospector's Drill", 4, "Polearm"),
                new Weapon("Wine and Song", 4, "Catalyst"),
                new Weapon("Rainslaher", 4, "Claymore"),
                new Weapon("The Stringless", 4, "Bow")
            };

            availableBanners = new List<Banner>
            {
                new StandardBanner(),
                new CharacterEventBanner("Rubedo, of White Stone Born (Durin)", new Character("Durin", 5, "Pyro")),
                new CharacterEventBanner("Ballad in Goblets (Venti)", new Character("Venti", 5, "Anemo")),
                new WeaponEventBanner("Epitome Invocation (Weapons)", event5StarWeapons, event4StarWeapons)
            };
            currentBanner = availableBanners[0];

            shop = new Shop();
        }

        public void Run()
        {
            Console.Title = "Genshin Impact Store";
            //Console.ForegroundColor = ConsoleColor.Cyan;

            while (true)
            {
                Console.Clear();
                DisplayPlayerInfo();
                DisplayMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Make1Wish();
                        break;
                    case "2":
                        Make10Wishes();
                        break;
                    case "3":
                        OpenShop();
                        break;
                    case "4":
                        ShowInventory();
                        break;
                    case "5":
                        SelectBanner();
                        break;
                    case "6":
                        SaveGame();
                        break;
                    case "7":
                        LoadGame();
                        break;
                    case "8":
                        Console.WriteLine("Thank you for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key...");
                        Console.ReadKey();
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
            /*Console.WriteLine("Main Menu");
            Console.WriteLine("1. Make a wish (160 Primogems)");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Select Banner");
            Console.WriteLine("5. Save game");
            Console.WriteLine("6. Load game");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Choose action: ");*/
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Make 1 wish (160 Primogems)");
            Console.WriteLine("2. Make 10 wishes (1600 Primogems)");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Inventory");
            Console.WriteLine("5. Select Banner");
            Console.WriteLine("6. Save game");
            Console.WriteLine("7. Load game");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Choose action: ");
        }

        private void MakeWish()
        {
            Console.Clear();
            Console.WriteLine($"{currentBanner.Name}");
            currentBanner.PrintInfo();

            Console.WriteLine($"Your Primogems: {player.GetPrimogems()}");
            Console.WriteLine("1. 1 Wish (160 Primogems)");
            Console.WriteLine("2. 10 Wishes (1600 Primogems)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose action: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Make1Wish();
                    break;
                case "2":
                    Make10Wishes();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private void Make1Wish()
        {
            try
            {
                string result = currentBanner.MakeWish(player);
                Console.WriteLine($"\nResult: {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void Make10Wishes()
        {
            try
            {
                var results = currentBanner.Make10Wishes(player);

                Console.WriteLine("10 wishes results");
                Console.WriteLine($"Spent: {currentBanner.Cost * 10} Primogems\n");

                foreach (var result in results)
                {
                    if (result.Contains("5*") || result.Contains("+25"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(result);
                        Console.ResetColor();
                    }
                    else if (result.Contains("4*") || result.Contains("+5"))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(result);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(result);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine($"\nLeft Primogems: {player.GetPrimogems()}");
            }
            catch(Exception ex )
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
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
            if (player.GetCharacterCount() > 0)
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
            if (player.GetWeaponCount() > 0)
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

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SelectBanner()
        {
            Console.Clear();
            Console.WriteLine("Select Banner");

            for (int i = 0; i < availableBanners.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableBanners[i].Name}");
            }

            Console.WriteLine($"Select banner (1 - {availableBanners.Count})");

            if (int.TryParse(Console.ReadLine(), out int choice)
                && choice >= 1 && choice <= availableBanners.Count)
            {
                currentBanner = availableBanners[choice - 1];
                Console.WriteLine($"Selected: {currentBanner.Name}");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        private void SaveGame()
        {
            try
            {
                var saveData = new
                {
                    PlayerName = player.GetName(),
                    Primogems = player.GetPrimogems(),
                    GenesisCrystals = player.GetGenesisCrystals(),
                    Starglitter = player.GetStarglitter(),
                    Stardust = player.GetStardust(),
                    SaveTime = DateTime.Now
                };

                string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                File.WriteAllText("save.json", json);
                Console.WriteLine("Game saved succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        private void LoadGame()

        {
            try
            {
                if (File.Exists("save.json"))
                {
                    string json = File.ReadAllText("save.json");
                    var saveData = JsonSerializer.Deserialize<SaveData>(json);

                    player.SetName(saveData.PlayerName);
                    player.SetPrimogems(saveData.Primogems);
                    player.SetGenesisCrystals(saveData.GenesisCrystals);
                    player.SetStarglitter(saveData.Starglitter);
                    player.SetStardust(saveData.Stardust);

                    Console.WriteLine($"Game loaded! Last save: {saveData.SaveTime}");
                }
                else
                {
                    Console.WriteLine("No save file found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private class SaveData
        {
            public string PlayerName { get; set; }
            public int Primogems { get; set; }
            public int GenesisCrystals { get; set; }
            public int Starglitter { get; set; }
            public int Stardust { get; set; }
            public DateTime SaveTime { get; set; }
        }
    }
}
