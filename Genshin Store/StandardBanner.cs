using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class StandardBanner : Banner
    {
        public override string Name => "Standard Wish";
        public override int Cost => 160;

        protected override void InitializeItems()
        {
            base.InitializeItems();
        }

        protected override object GetRandomItem(int rarity)
        {
            var characters = Characters.Where(c => c.Rarity == rarity).ToList();
            var weapons = Weapons.Where(w => w.Rarity == rarity).ToList();

            if (characters.Count == 0 && weapons.Count == 0)
                return new Weapon("Trainin Sword", 3, "Sword");

            if (rarity == 3)
            {
                return weapons.Count > 0 ? weapons[Random.Next(weapons.Count)] : new Weapon("Training Sword", 3, "Sword");

            }

            bool isCharacter = Random.Next(2) == 0;

            if (isCharacter && characters.Count > 0)
                return characters[Random.Next(characters.Count)];
            else if (weapons.Count > 0)
                return weapons[Random.Next(weapons.Count)];
            else if (characters.Count > 0)
                return characters[Random.Next(characters.Count)];
            else
                return new Weapon("Training Sword", 3, "Sword");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("5* and 4*: 50% characters. 50% weapon");
            Console.WriteLine("3*: weapons only");
        }
    }
}
