using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Player
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

        private List<Character> Characters = new List<Character>();
        private List<Weapon> Weapons = new List<Weapon>();
        private List<Skin> Skins = new List<Skin>();

        public void AddCharacter(Character c)
        {
            Characters.Add(c);
        }

        public int GetCharactersCount()
        {
            return Characters.Count;
        }
        public void AddWeapon(Weapon w)
        {
            Weapons.Add(w);
        }

        public int GetWeaponsCount()
        {
            return Weapons.Count;
        }
        public void AddSkin(Skin s)
        {
            Skins.Add(s);
        }

        public int GetSkinsCount()
        {
            return Skins.Count;
        }
    }
}
