using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class WishBanner
    {
        private List<Character> AllCharacters = new List<Character>()
        {
            new Character("Diluc", 5, "Pyro"),
            new Character("Jean", 5, "Anemo"),
            new Character("Qiqi", 5, "Cryo"),
            new Character("Keqing", 5, "Electro"),
            new Character("Mona", 5, "Hydro"),
            new Character("Tighnari", 5, "Dendro"),

            new Character("Xinqiu", 4, "Hydro"),
            new Character("Xianling", 4, "Pyro"),
            new Character("Fischl", 4, "Electro"),
            new Character("Barbara", 4, "Hydro"),
            new Character("Bennet", 4, "Pyro"),
            new Character("Collei", 4, "Dendro")
        };

        private List<Weapon> AllWeapons = new List<Weapon>
        {
            new Weapon("Absolution", 5, "Sword"),
            new Weapon("A Thousand Blazing Suns", 5, "Claymore"),
            new Weapon("Bloodsoaked Ruins", 5, "Polearm"),
            new Weapon("Amo's Bow", 5, "Bow"),
            new Weapon("A Thousand Floating Dreams", 5, "Catalyst"),

            new Weapon("Amenoma Kageuchi", 4, "Sword"),
            new Weapon("Akuomaru", 4, "Claymore"),
            new Weapon("Ballad of the Fjords", 4, "Polearm"),
            new Weapon("Alley Hunter", 4, "Bow"),
            new Weapon("Ash-Given Drinking Horn", 4, "Catalyst"),

            new Weapon("Cool Steel", 3, "Sword"),
            new Weapon("Bloodstained Greatsword", 3, "Claymore"),
            new Weapon("Black Tassel", 3, "Polearm"),
            new Weapon("Messenger", 3, "Bow"),
            new Weapon("Emerald Orb", 3, "Catalyst")
        };

        public string MakeWish(Player player)
        {
            if (player.GetPrimogems() < 160)
                return "You don't have enough Primogems";

            player.SetPrimogems(player.GetPrimogems() - 160);
            var random = new Random();

            int chance = random.Next(100);
            object result;

            if (chance < 1)
            {
                if (random.Next(2) == 0)
                {
                    var fiveStarChars = AllCharacters.Where(c => c.Rarity == 5).ToList();
                    if (fiveStarChars.Count > 0)
                        result = fiveStarChars[random.Next(fiveStarChars.Count)];
                    else
                        result = GetRandomWeapon(5, random);
                }
                else
                {
                    var fiveStarWeapons = AllWeapons.Where(w => w.Rarity == 5).ToList();
                    if (fiveStarWeapons.Count > 0)
                        result = fiveStarWeapons[random.Next(fiveStarWeapons.Count)];
                    else
                        result = GetRandomCharacter(5, random);
                }
            }
            else if (chance < 11)
            {
                if (random.Next(2) == 0)
                {
                    var fourStarChars = AllCharacters.Where(c => c.Rarity == 4).ToList();
                    if (fourStarChars.Count > 0)
                        result = fourStarChars[random.Next(fourStarChars.Count)];
                    else
                        result = GetRandomWeapon(4, random);
                }
                else
                {
                    var fourStarWeapons = AllWeapons.Where(w => w.Rarity == 4).ToList();
                    if (fourStarWeapons.Count > 0)
                        result = fourStarWeapons[random.Next(fourStarWeapons.Count)];
                    else
                        result = GetRandomCharacter(4, random);
                }      
            }
            else
            {
                var threeStars = AllWeapons.Where(w => w.Rarity == 3).ToList();
                if (threeStars.Count > 0)
                    result = threeStars[random.Next(threeStars.Count)];
                else
                    return "No 3* items available";
            }

            if (result is Character character)
            {
                if (player.HasCharacter(character))
                {
                    int starglitter = character.Rarity == 5 ? 25 : 5;
                    player.SetStarglitter(player.GetStarglitter() + starglitter);
                    return $"{character.Rarity}* Character Duplicate! +{starglitter}";
                    /*player.SetStarglitter(player.GetStarglitter() + 25);
                    Console.WriteLine("5* Duplicate +25 Starglitter");*/
                }
                else
                {
                    player.AddCharacter(character);
                    return $"New character: {character}";
                }
            }
            else if (result is Weapon weapon)
            {
                if (player.HasWeapon(weapon))
                {
                    int starglitter = weapon.Rarity == 5 ? 25 : weapon.Rarity == 4 ? 5 : 0;
                    int stardust = weapon.Rarity == 3 ? 15 : 0;

                    if (starglitter > 0)
                        player.SetStarglitter(player.GetStarglitter() + starglitter);

                    if (stardust > 0)
                        player.SetStardust(player.GetStardust() + stardust);

                    return $"{weapon.Rarity}* Weapon Duplicate! +{(starglitter > 0 ? starglitter + " Starglitter"
                        : stardust + " Stardust")}";
                }
                else
                {
                    player.AddWeapon(weapon);
                    return $"New weapon: {weapon}";
                }
            }

            return "Wish completed";
        }

        private Character GetRandomCharacter(int rarity, Random random)
        {
            var characters = AllCharacters.Where(c => c.Rarity == rarity).ToList();
            return characters.Count > 0 ? characters[random.Next(characters.Count)] : null;
        }

        private Weapon GetRandomWeapon(int rarity, Random random)
        {
            var weapons = AllWeapons.Where(w => w.Rarity == rarity).ToList();
            return weapons.Count > 0 ? weapons[random.Next(weapons.Count)] : null;
        }

        public void PrintBannerInfo()
        {
            Console.WriteLine("Character & Weapon Banner");
            Console.WriteLine("Cost: 160 Primogems per wish");
            Console.WriteLine("Chances: 1% 5★ | 10% 4★ | 89% 3★");
            Console.WriteLine("5★: 50% character, 50% weapon");
            Console.WriteLine("4★: 50% character, 50% weapon");
            Console.WriteLine("3★: 100% weapons only");
        }
    }
}
