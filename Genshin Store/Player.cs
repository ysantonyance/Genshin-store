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
        public string Name {  get; set; }
        public int Primogems { get; set; }
        public int Starglitter { get; set; }
        public int Stardust { get; set; }
        public int GenesisCrystals { get; set; }
        public List<string> Characters { get; } = new List<string>();
        public List<string> Weapons { get; } = new List<string>();
        public List<string> Outfits { get; } = new List<string>();
    }
}
