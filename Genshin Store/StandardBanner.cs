using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class StandardBanner : Banner
    {
        public override string Name => "Standard Wish";
        public override int Cost => 160;

        public override void InitializeItems()
        {
            base.InitializeItems();
        }
    }
}
