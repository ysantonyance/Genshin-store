using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public interface IWishable
    {
        int Rarity {  get; }

        string Name { get; }

        /*bool IsCharacter
        {
            get;
        }*/
    }
}
