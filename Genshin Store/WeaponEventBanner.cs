using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class WeaponEventBanner : Banner
    {
        public override string Name { get; }
        public override int Cost => 160;

        private List<Weapon> event5StarWeapons;
        private List<Weapon> event4StarWeapon;

        public WeaponEventBanner(string name, List<Weapon> event5Star, List<Weapon> event4Star = null) : base()
        {
            Name = name;
            event5StarWeapons = event5Star ?? new List<Weapon>();
            event4StarWeapon = event4Star ?? new List<Weapon>();
        }

        protected override void InitializeItems()
        {
            base.InitializeItems();

            Characters.Clear();

            if (event5StarWeapons != null)
            {
                foreach (var weapon in event5StarWeapons)
                {
                    Weapons.Add(weapon);
                }
            }

            if (event4StarWeapon != null)
            {
                foreach (var weapon in event4StarWeapon)
                {
                    Weapons.Add(weapon);
                }
            }
        }

        protected override object GetRandomItem(int rarity)
        {
            var weapons = Weapons.Where(w => w.Rarity == rarity).ToList();

            if (weapons.Count == 0)
                return new Weapon("No sword for you", 3, "Sword");

            return weapons[Random.Next(weapons.Count)];
        }

        public new List<string> Make10Wishes(Player player)
        {
            if (player.GetPrimogems() < Cost * 10)
                return new List<string>
                {
                    $"Not enough Primogems! You need {Cost * 10}, you have {player.GetPrimogems()}" 
                };

            player.SetPrimogems(player.GetPrimogems() - Cost * 10);

            List<string> results = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                string result = MakeWish(player);
                results.Add($"{i + 1}. {result}");
            }

            results.Add($"\n5* Pity: {pityCounter}/{MaxPity}");

            return results;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} (Weapon Event Banner)");
            Console.WriteLine($"Cost: {Cost} Primogems per wish");

            if (event5StarWeapons != null && event5StarWeapons.Count > 0)
            {
                Console.WriteLine("\n- Event 5* Weapons: ");
                foreach (var weapon in event5StarWeapons)
                {
                    Console.WriteLine($"   - {weapon.Name} ({weapon.Type})");
                }
            }

            if (event4StarWeapon != null && event4StarWeapon.Count > 0)
            {
                Console.WriteLine("\n- Event 4 star Weapons: ");
                foreach (var weapon in event4StarWeapon)
                {
                    Console.WriteLine($"   - {weapon.Name} ({weapon.Type})");
                }
            }

            Console.WriteLine("Drop Rates: ");
            Console.WriteLine(" 5* Weapon: 0.7% (75% chance to get event weapon)");
            Console.WriteLine(" 4* Weapon: 6.0% (75% chance to get event weapon)");
            Console.WriteLine(" 3* Weapon: 93.3%");
            Console.WriteLine("\nNote: This banner contains weapons only, no characters");
        }
    }
}
