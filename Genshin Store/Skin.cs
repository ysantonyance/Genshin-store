using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class Skin
    {
        private string Name;
        private string ForCharacter;
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetForCharacter(string forCharacter)
        {
            this.ForCharacter = forCharacter;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetForCharacter()
        {
            return ForCharacter;
        }
    }
}
