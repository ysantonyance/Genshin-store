using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    internal class WishResult
    {
        private IWishable item;
        public IWishable Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        private bool isDuplicate;
        public bool IsDuplicate
        {
            get
            {
                return isDuplicate;
            }
            set
            {
                isDuplicate = value;
            }
        }

        private int starglitter;
        public int Starglitter
        {
            get
            {
                return starglitter;
            }
            set
            {
                starglitter = value;
            }
        }

        private int stardust;
        public int Stardust
        {
            get
            {
                return Stardust;
            }
            set
            {
                stardust = value;
            }
        }

        private bool isNew;
        public bool IsNew
        {
            get
            {
                return isNew;
            }
            set
            {
                isNew = value;
            }
        }

        public WishResult(IWishable item, bool isDuplicate, int starglitter = 0, int stardust = 0)
        {
            Item = item;
            IsDuplicate = isDuplicate;
            Starglitter = starglitter;
            Stardust = stardust;
            IsNew = !isDuplicate;
        }

        public override string ToString()
        {
            if (IsDuplicate)
            {
                string rewards = "";
                if (Starglitter > 0)
                    rewards = $"+{Starglitter} Starglitter";
                if (Stardust > 0)
                    rewards = $"+{Stardust} Stardust";
                return $"{Item.Name} Duplicate! {rewards}";
            }

            return $"New Item: {Item.Name} ({Item.Rarity})";
        }
    }
}
