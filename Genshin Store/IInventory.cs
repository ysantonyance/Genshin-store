using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public interface IInventory
    {
        public List<Character> GetCharacters();
        public int GetCharacterCount();
        public void AddCharacter(Character character);
        public bool HasCharacter(Character character);

        public List<Weapon> GetWeapons();
        public int GetWeaponCount();
        public void AddWeapon(Weapon weapon);
        public bool HasWeapon(Weapon weapon);

        public List<Skin> GetSkins();
        public int GetSkinsCount();
        public void AddSkin(Skin skin);
        public bool HasSkin(Skin skin);
    }
}
