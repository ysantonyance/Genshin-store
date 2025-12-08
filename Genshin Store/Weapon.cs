using System; //подключаем базовые классы
using System.Collections.Generic; //это для доступа к коллекциям
using System.Linq; //для Linq методов
using System.Text; //для работы со строками
using System.Threading.Tasks; //пространство имён, которое работает с асинхронными задачами
using System.Xml.Linq; //для работы с Xml

namespace Genshin_Store //пространство имен проекта
{
    public class Weapon : InventoryItem, IWishable, IPurchasable //Weapon наследует InventoryItem и реализует интерфейсы IWishable и IPurchasable
    {
        private string name; //приватное поле имени

        public string Name //и публичное с прроверкой
        {
            get
            {
                return name; //возвращает имя оружия
            }
            set
            {
                if (value.Length > 40) //проверяем длину имени оружия 
                    throw new ArgumentException("The name is too long"); //если слишком длинное выводим ошибку
                name = value; //сохраняем.....
            }
        }

        private int rarity; //приватное поле для редкости оружия
        public int Rarity //публичное с проверкой
        {
            get
            {
                return rarity; //возвращаем редкрсть оружия
            }
            set
            {
                if (value != 3 && value != 4 && value != 5) //проверяем к какой редкости относиться
                    throw new ArgumentException($"Weapons can't be {value} star/s"); //ошибка если нет такоц редкости
                rarity = value; //сохраняем.......
            }
        }

        private string type; //приватное поле для типа оружия
        public string Type //публичное с проверкой 
        {
            get
            {
                return type; //возвращаем тип оружия
            }
            set
            {
                if (value != "Sword" && value != "Claymore" && value != "Polearm" && //проверка типа оружия
                    value != "Bow" && value != "Catalyst")
                    throw new ArgumentException($"Weapons can't be {value} type"); //если такого типа нет то выводится ошибка
                type = value; //сохраняем...
            }
        }

        public Weapon(string name, int rarity, string type) //конструктор
        {
            Name = name; //устанавливаем имя, редкость и тип оружия
            Rarity = rarity;
            Type = type;
        }

        /*public void SetName(string name)
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
        }*/

        public override string ToString() //для вывода информации об оружии
        {
            return $"{Name} ({Rarity}* {Type})"; //вывод строки
        }

        private int price;
        public int Price //расчет цены в зависимости от редкости
        {
            get
            {
                return Rarity == 4 ? 25 : 
                    Rarity == 3 ? 15 : 10;
            }
        }

        public bool IsCharacter() //метод из интерфейса IWishable 
        {
            return false; //это оружие поэтому это ложь
        }

        private string currencyType = "Starglitter"; //валюта
        public string CurrencyType //свойство для валюты
        {
            get
            {
                return currencyType; //возвращаем валюту 
            }
        }

        public bool CanPurchase(Player player) //проверка может ли плейер купить оружие
        {
            return player.GetStarglitter() >= Price; //если достаточно денег тогда тру
        }

        public void Purchase (Player player) //метод покупки
        {
            if (!CanPurchase(player)) //если нельзя купить тогда будет ошибка
                throw new ArgumentException("Can't buy weapon");

            player.SetStarglitter(player.GetStarglitter() - Price); //в ином случае списываем валюту
            player.AddWeapon(this); //и добавляем оружие игроку
            Console.WriteLine($"You bought {this} for {Price} Starglitter"); //выводим сообщение об успешности покупки
        }
    }
}

