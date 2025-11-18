using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Weapon
    {
        private string Name;
        private int Rarity;
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetRarity(int rarity)
        {
            this.Rarity = rarity;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetRarity()
        {
            return Rarity;
        }
    }
}
