using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public abstract class InventoryItem : IComparable<InventoryItem>
    {
        private string name;
        public string Name 
        {
            get {  return name; }
            set { name = value; }
        }

        private int rarity;
        public int Rarity
        {
            get { return rarity;}
            set { rarity = value; }
        }

        public static InventoryItem operator +(InventoryItem a, InventoryItem b)
        {
            return a + b;
        }

        public static bool operator ==(InventoryItem a, InventoryItem b)
        {
            return a?.Name == b?.Name && a?.Rarity == b?.Rarity;
        }

        public static bool operator !=(InventoryItem a, InventoryItem b)
        {
            return !(a == b);
        }

        public static bool operator >(InventoryItem a, InventoryItem b)
        {
            return a.Rarity > b.Rarity;
        }

        public static bool operator <(InventoryItem a, InventoryItem b)
        {
            return a.Rarity < b.Rarity;
        }

        public int CompareTo(InventoryItem other)
        {
            return Rarity.CompareTo(other.Rarity);
        }
    }
}
