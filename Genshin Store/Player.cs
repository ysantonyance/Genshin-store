using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class Player : IInventory
    {
        private string Name;
        private int Primogems;
        private int GenesisCrystals;
        private int Starglitter;
        private int Stardust;

        public Player(string name, int primogems, int gc, int starglitter, int stardust)
        {
            SetName(name);
            SetPrimogems(primogems);
            SetGenesisCrystals(gc);
            SetStarglitter(starglitter);
            SetStardust(stardust);
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetPrimogems(int primogems)
        {
            this.Primogems = primogems;
        }
        public void SetGenesisCrystals(int genesisCrystals)
        {
            this.GenesisCrystals = genesisCrystals;
        }
        public void SetStarglitter(int starglitter)
        {
            this.Starglitter = starglitter;
        }
        public void SetStardust(int stardust)
        {
            this.Stardust = stardust;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetPrimogems()
        {
            return Primogems;
        }
        public int GetGenesisCrystals()
        {
            return GenesisCrystals;
        }
        public int GetStarglitter()
        {
            return Starglitter;
        }
        public int GetStardust()
        {
            return Stardust;
        }
        
        public void AddPrimogems(int amount) => Primogems += amount;
        public void SpendPrimogems(int amount)
        {
            if (Primogems >= amount)
                Primogems -= amount;
            else
                Console.WriteLine("Not enough primogems!");
        }

        public void AddGenesisCrystals(int amount) => GenesisCrystals += amount;
        public void SpendGenesisCrystals(int amount)
        {
            if (GenesisCrystals >= amount)
                GenesisCrystals -= amount;
            else
                Console.WriteLine("Not enough crystals!");
        }

        public void AddStarglitter(int amount) => Starglitter += amount;
        public void SpendStarglitter(int amount)
        {
            if (Starglitter >= amount)
                Starglitter -= amount;
            else
                Console.WriteLine("Not enough star glitter!");
        }

        public void AddStardust(int amount) => Stardust += amount;
        public void SpendStardust(int amount)
        {
            if (Stardust >= amount)
                Stardust -= amount;
            else
                Console.WriteLine("Not enough stardust!");
        }

        private List<Character> Characters = new List<Character>();
        private List<Weapon> Weapons = new List<Weapon>();
        private List<Skin> Skins = new List<Skin>();

        public List<Character> GetCharacters() => Characters;
        public int GetCharacterCount() => Characters.Count;
        public void AddCharacter(Character c) => Characters.Add(c);
        public bool HasCharacter(Character name) => Characters.Contains(name);

        public List<Weapon> GetWeapons() => Weapons;
        public int GetWeaponCount() => Weapons.Count;
        public void AddWeapon(Weapon w) => Weapons.Add(w);
        public bool HasWeapon(Weapon name) => Weapons.Contains(name);

        public List<Skin> GetSkins() => Skins;
        public int GetSkinsCount() => Skins.Count;
        public void AddSkin(Skin s) => Skins.Add(s);
        public bool HasSkin(Skin s) => Skins.Contains(s);
        
        public IEnumerable<Character> Get5Characters()
        {
            return Characters.Where(c => c.Rarity == 5);
        }
        public IEnumerable<Character> Get4Characters()
        {
            return Characters.Where(c => c.Rarity == 4);
        }

        public static Player operator +(Player player, int primogems)
        {
            player.Primogems += primogems;
            return player;
        }

        public List<Character> GetCharactersByElement(string element)
        {
            return GetCharacters().Where(c => c.Element == element).ToList();
        }

        public Character this[int index]
        {
            get => GetCharacters()[index];
        }
    }
}


