using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public abstract class Banner
    {
        public event Action<string> WishCompleted;

        protected List<Character> Characters {  get; set; }
        protected List<Weapon> Weapons { get; set; }
        protected Random Random { get; }

        public abstract string Name { get; }
        public abstract int Cost { get; }

        protected int pityCounter = 0;
        protected const int MaxPity = 90;
        protected bool guaranteed5Star = false;

        protected Banner()
        {
            Random = new Random();
            Characters = new List<Character>();
            Weapons = new List<Weapon>();
            InitializeItems();
        }

        protected virtual void InitializeItems()
        {
            /*new Character("Diluc", 5, "Pyro")
            new Character("Jean", 5, "Anemo"),
            new Character("Qiqi", 5, "Cryo"),
            new Character("Keqing", 5, "Electro"),
            new Character("Mona", 5, "Hydro"),
            new Character("Tighnari", 5, "Dendro"),*/
            Characters.Add(new Character("Diluc", 5, "Pyro"));
            Characters.Add(new Character("Jean", 5, "Anemo"));
            Characters.Add(new Character("Qiqi", 5, "Cryo"));
            Characters.Add(new Character("Keqing", 5, "Electro"));
            Characters.Add(new Character("Mona", 5, "Hydro"));
            Characters.Add(new Character("Tighnari", 5, "Dendro"));

            /*new Character("Xinqiu", 4, "Hydro"),
            new Character("Xianling", 4, "Pyro"),
            new Character("Fischl", 4, "Electro"),
            new Character("Barbara", 4, "Hydro"),
            new Character("Bennet", 4, "Pyro"),
            new Character("Collei", 4, "Dendro")*/
            Characters.Add(new Character("Xinqiu", 4, "Hydro"));
            Characters.Add(new Character("Xiangling", 4, "Pyro"));
            Characters.Add(new Character("Fishcl", 4, "Electro"));
            Characters.Add(new Character("Barbara", 4, "Hydro"));
            Characters.Add(new Character("Bennet", 4, "Pyro"));
            Characters.Add(new Character("Collei", 4, "Dendro"));

            /*new Weapon("Absolution", 5, "Sword"),
            new Weapon("A Thousand Blazing Suns", 5, "Claymore"),
            new Weapon("Bloodsoaked Ruins", 5, "Polearm"),
            new Weapon("Amo's Bow", 5, "Bow"),
            new Weapon("A Thousand Floating Dreams", 5, "Catalyst"),*/
            Weapons.Add(new Weapon("Absolution", 5, "Sword"));
            Weapons.Add(new Weapon("A Thousand Blazing Suns", 5, "Claymore"));
            Weapons.Add(new Weapon("Bloodsoaked Ruins", 5, "Polearm"));
            Weapons.Add(new Weapon("Amo's Bow", 5, "Bow"));
            Weapons.Add(new Weapon("A Thousand Floating Dreams", 5, "Catalyst"));

            /*new Weapon("Amenoma Kageuchi", 4, "Sword"),
            new Weapon("Akuomaru", 4, "Claymore"),
            new Weapon("Ballad of the Fjords", 4, "Polearm"),
            new Weapon("Alley Hunter", 4, "Bow"),
            new Weapon("Ash-Given Drinking Horn", 4, "Catalyst"),*/
            Weapons.Add(new Weapon("Amenonma Kageuchi", 4, "Sword"));
            Weapons.Add(new Weapon("Akuomaru", 4, "Claymore"));
            Weapons.Add(new Weapon("Ballad of the Fjords", 4, "Polearm"));
            Weapons.Add(new Weapon("Alley Hunter", 4, "Bow"));
            Weapons.Add(new Weapon("Ash-Given Drinking Horn", 4, "Catalyst"));

            /*new Weapon("Cool Steel", 3, "Sword"),
            new Weapon("Bloodstained Greatsword", 3, "Claymore"),
            new Weapon("Black Tassel", 3, "Polearm"),
            new Weapon("Messenger", 3, "Bow"),
            new Weapon("Emerald Orb", 3, "Catalyst")*/
            Weapons.Add(new Weapon("Cool Steel", 3, "Sword"));
            Weapons.Add(new Weapon("Bloodstained Greatsword", 3, "Claymore"));
            Weapons.Add(new Weapon("Black Tassel", 3, "Polearm"));
            Weapons.Add(new Weapon("Messenger", 3, "Bow"));
            Weapons.Add(new Weapon("Emerald Orb", 3, "Catalyst"));
        }

        public string MakeWish(Player player)
        {
            if (player.GetPrimogems() < Cost)
                return $"Not enough Primogems! You need {Cost}, you have {player.GetPrimogems()}";

            /*player.SetPrimogems(player.GetPrimogems() - Cost);

            int chance = Random.Next(100);
            int rarity = GetRarity(chance);*/
            int rarity;
            if (pityCounter >= MaxPity || (guaranteed5Star && Random.Next(100) < 1))
            {
                rarity = 5;
                pityCounter = 0;
                guaranteed5Star = false;
            }
            else
            {
                rarity = GetRarity(Random.Next(100));

                if (rarity == 5)
                {
                    pityCounter = 0;
                }
            }

            object item = GetRandomItem(rarity);
            return ProcessWishResult(player, item);
        }

        protected virtual int GetRarity(int chance)
        {
            if (chance < 1) 
                return 5;

            if (chance < 11)
                return 4;

            return 3;
        }

        protected virtual object GetRandomItem(int rarity)
        {
            var characters = Characters.Where(c => c.Rarity == rarity).ToList();
            var weapons = Weapons.Where(w => w.Rarity == rarity).ToList();

            if (characters.Count == 0 && weapons.Count == 0)
                return null;

            bool chooseCharacter = characters.Count > 0 && (rarity == 3 ? false : Random.Next(2) == 0);

            if (chooseCharacter)
                return characters[Random.Next(characters.Count)];
            else if (weapons.Count > 0)
                return weapons[Random.Next(weapons.Count)];
            else
                return characters[Random.Next(characters.Count)];
        }

        private string ProcessWishResult(Player player, object item)
        {
            if (item is Character character)
            {
                if (player.HasCharacter(character))
                {
                    int starglitter = character.Rarity == 5 ? 25 : 5;
                    player.SetStarglitter(player.GetStarglitter() + starglitter);
                    return $"{character.Name} duplicate! +{starglitter} Starglitter";
                }
                else
                {
                    player.AddCharacter(character);
                    return $"New character: {character}";
                }
            }
            else if (item is Weapon weapon)
            {
                if (player.HasWeapon(weapon))
                {
                    int reward = weapon.Rarity == 5 ? 25 : weapon.Rarity == 4 ? 5 : 0;

                    if (weapon.Rarity == 5 || weapon.Rarity == 4)
                    {
                        player.SetStarglitter(player.GetStarglitter() + reward);
                        return $"{weapon.Name} duplicate! +{reward} Starglitter";
                    }
                    else
                    {
                        player.SetStardust(player.GetStardust() + 15);
                        return $"{weapon.Name} duplicate! +15 Stardust";
                    }
                }
                else
                {
                    player.AddWeapon(weapon);
                    return $"New weapon: {weapon}";
                }
            }

            return "Nothing was found";
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Banner: {Name}");
            Console.WriteLine($"The cost of one wish: {Cost} Prrimogems");
            Console.WriteLine("Chances are: 5* - 1% | 4* - 10% | 3* - 89%");
        }

        public List<Character> GetCharactersByRarity(int rarity)
        {
            return Characters.Where(c => c.Rarity == rarity).ToList();
        }

        public List<string> Make10Wishes(Player player)
        {
            if (player.GetPrimogems() < Cost * 10)
                return new List<string>
                {
                    $"Not enough Primogems! You need {Cost * 10}, you have {player.GetPrimogems()}"
                };

            player.SetPrimogems(player.GetPrimogems() - Cost * 10);

            List<string> results = new List<string>();
            bool got4or5 = false;
            int fourStarPity = 0;

            for (int i = 0; i < 10; i++)
            {
                pityCounter++;
                fourStarPity++;

                int rarity;

                if (pityCounter >= MaxPity || (guaranteed5Star && Random.Next(100) < 1))
                {
                    rarity = 5;
                    pityCounter = 0;
                    guaranteed5Star = false;
                    fourStarPity = 0;
                }
                else if (fourStarPity >= 10)
                {
                    rarity = 4;
                    fourStarPity = 0;
                }
                else
                {
                    rarity = GetRarity(Random.Next(100));

                    if (rarity == 5)
                    {
                        pityCounter = 0;
                        fourStarPity = 0;
                    }
                    else if (rarity == 4)
                    {
                        fourStarPity = 0;
                    }
                }

                object item = GetRandomItem(rarity);
                string result = ProcessWishResult(player, item);

                results.Add($"{i + 1}. {result}");

                if (rarity >= 4)
                    got4or5 = true;
            }

            results.Add($"Pty| 5* Pity: {pityCounter}/{MaxPity}");

            return results;
        }
    }
}
