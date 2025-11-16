using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class WishBanner
    {
        private List<string> FiveStarCharacters = new List<string>
        {
            "Diluc (5* Pyro)\n", 
            "Jean (5* Anemo)\n", 
            "Qiqi (5* Cryo)\n",
            "Keqing (5* Electro)\n",
            "Mona (5* Hydro)\n",
            "Tignari (5* Dendro)\n"
        };

        private List<string> FourStarChaarcters = new List<string>
        {
            "Xinqiu (4* Hydro)\n",
            "Xiangling (4* Pyro)\n",
            "Fischl (4* Electro)\n",
            "Barbara (4* Hydro)\n",
            "Bennet (4* Pyro)\n",
            "Collei (4* Dendro)\n"
        };

        private List<string> ThreeStarWeapon = new List<string>
        {
            "Slingshot (3* Bow)\n",
            "CoolSteel (3* Sword)\n",
            "Magic Guide (3* Catalyst)\n",
            "Raven Bow (3* Bow)\n",
            "Sharpshooter's Oath (3* Bow)\n"
        };

        public string MakeWish(Player player)
        {
            if (player.Primogems < 160)
                return "You don't have enough Primogems";

            player.Primogems -= 160;
            var random = new Random();

            int chance = random.Next(100);
            string result;

            if (chance < 1)
            {
                result = FiveStarCharacters[random.Next(FiveStarCharacters.Count)];
            }
            else if (chance < 11)
            {
                result = FourStarChaarcters[random.Next(FourStarChaarcters.Count)];
            }
            else
            {
                result = ThreeStarWeapon[random.Next(ThreeStarWeapon.Count)];
            }

            bool IsDuplicate = result.Contains("5*") || result.Contains("4*")
                ? player.Characters.Contains(result) : player.Weapons.Contains(result);

            if (IsDuplicate)
            {
                if (result.Contains("5*"))
                {
                    player.Starglitter += 25;
                    Console.WriteLine("5* Duplicate +25 Starglitter");
                }
                else if (result.Contains("4*"))
                {
                    player.Starglitter += 5;
                    Console.WriteLine("4* Duplicate +5 Starglitter");
                }
                else if (result.Contains("3*"))
                {
                    player.Stardust += 15;
                    Console.WriteLine("3* Duplicate +5 Stardust");
                }
            }
            else
            {
                if (result.Contains("5*") || result.Contains("4*"))
                    player.Characters.Add(result);
                else
                    player.Weapons.Add(result);

                Console.WriteLine($"New item: {result}");
            }

            return result;
        }
    }
}
