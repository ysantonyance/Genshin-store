using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public interface IPurchasable
    {
        string Name { get; }
        int Price { get; }
        string CurrencyType { get; }
        bool CanPurchase(Player player);
        void Purchase(Player player);
    }
}
