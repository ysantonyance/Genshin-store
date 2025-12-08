using System; //подключаем базовые классы
using System.Collections.Generic; //это для доступа к коллекциям
using System.ComponentModel; //для функционала 
using System.Linq; //для Linq методов
using System.Text; //для работы со строками
using System.Threading.Tasks; //пространство имён, которое работает с асинхронными задачами

namespace Genshin_Store //обьявляем пространство имен
{
    public class Player : IInventory //класс плейер реализует интерфейс иинвентарь
    {
        private string Name; //приватное имя игрока 
        private int Primogems; //приватное кол-во примогемов(локальная валюта)
        private int GenesisCrystals; //приватное кол-во кристаллов(локальная валюта)
        private int Starglitter; //приватное кол-во блеска(локальная валюта)
        private int Stardust; //приватное кол-во пыли(локальная валюта)

        public Player(string name, int primogems, int gc, int starglitter, int stardust) //обьект плейера принимает значения валюты
        {
            SetName(name); //через сеттеры устанавливаем имя, кол-во примогемов, звездной пыли и блеска 
            SetPrimogems(primogems);
            SetGenesisCrystals(gc);
            SetStarglitter(starglitter);
            SetStardust(stardust);
        }
        public void SetName(string name) //обьявлем метод, который принимает строку и ничего не возвращает. такая же ситуация до 45 строки
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
        public string GetName() //геттеры возвращают все наши значения (валюту и имя). до 65 строки
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
        
        public void AddPrimogems(int amount) => Primogems += amount; //добавляем примогемы
        public void SpendPrimogems(int amount) //и тратим, если у плейера достаточно денег, тогда денюжка уменьшиться, если нет, то на консоли появиться сообщение что не достаточно денег(73 строка)
        {
            if (Primogems >= amount)
                Primogems -= amount;
            else
                Console.WriteLine("Not enough primogems!");
        }

        public void AddGenesisCrystals(int amount) => GenesisCrystals += amount; //такая же ситуация как и с примогемами, мы их добавляем 
        public void SpendGenesisCrystals(int amount) //и тратим, если мало денег, то будет сообщение, что не достаточно денег. до 101 строки аналогичная ситуация
        {
            if (GenesisCrystals >= amount)
                GenesisCrystals -= amount;
            else
                Console.WriteLine("Not enough crystals!");
        }

        public void AddStarglitter(int amount) => Starglitter += amount;
        public void SpendStarglitter(int amount)
        {
            if (Starglitter >= amount)
                Starglitter -= amount;
            else
                Console.WriteLine("Not enough star glitter!");
        }

        public void AddStardust(int amount) => Stardust += amount;
        public void SpendStardust(int amount)
        {
            if (Stardust >= amount)
                Stardust -= amount;
            else
                Console.WriteLine("Not enough stardust!");
        }

        private List<Character> Characters = new List<Character>(); //создаем лист с персонажами плейера
        private List<Weapon> Weapons = new List<Weapon>(); //создаем лист с оружием плейера
        private List<Skin> Skins = new List<Skin>(); //создаем лист со скинами плейера

        public List<Character> GetCharacters() => Characters; //геттер вернет список всех персонажей плейера
        public int GetCharacterCount() => Characters.Count; //вернет кол-во всех персонажей плейера
        public void AddCharacter(Character c) => Characters.Add(c); //это для добавление персонажа
        public bool HasCharacter(Character name) => Characters.Contains(name); //и проверяем по имени есть ли персонаж в списке

        public List<Weapon> GetWeapons() => Weapons; //с 112 до 120 строки повторяются действия как с 107 по 110 строки
        public int GetWeaponCount() => Weapons.Count;
        public void AddWeapon(Weapon w) => Weapons.Add(w);
        public bool HasWeapon(Weapon name) => Weapons.Contains(name);

        public List<Skin> GetSkins() => Skins;
        public int GetSkinsCount() => Skins.Count;
        public void AddSkin(Skin s) => Skins.Add(s);
        public bool HasSkin(Skin s) => Skins.Contains(s);
        
        public IEnumerable<Character> Get5Characters() //используем фильтрацию и возвращаем персонажей с редкостью 5 звезд
        {
            return Characters.Where(c => c.Rarity == 5); //используется linq
        }
        public IEnumerable<Character> Get4Characters() //используем фильтрацию и возвращаем персонажей с редкостью 4 звезд
        {
            return Characters.Where(c => c.Rarity == 4); //используется linq
        }

        public static Player operator +(Player player, int primogems) //перегрузка оператора, которая добавляет плейеры примогемы
        {
            player.Primogems += primogems;
            return player;
        }

        public List<Character> GetCharactersByElement(string element) //фильтруем по элементу персонажей(электро, пиро, гидро и тд) и возращаем персонажей
        {
            return GetCharacters().Where(c => c.Element == element).ToList();
        }

        public Character this[int index] //можно обратиться как к массиву
        {
            get => GetCharacters()[index]; //возвращает персонажа по индексу из списка
        }
    }
}



