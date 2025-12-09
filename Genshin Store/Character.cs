using System;//подключаем базовые классы
using System.Collections.Generic; //это для доступа к коллекциям
using System.Linq; //для Linq методов
using System.Text; //для работы со строками
using System.Threading.Tasks;//пространство имён, которое работает с асинхронными задачами
using System.Xml.Linq; //для работы  с XML через Linq 

namespace Genshin_Store //пространство имен для проекта
{
    public class Character : InventoryItem, IWishable, IPurchasable //класс Character наследуется от InventoryItem, реализует IWishable и IPurchasable
    {
        private string name; //приватное поле для имени
        public string Name //публичное с геттерами и сеттерами
        {
            get
            {
                return name; //возвращает имя
            }
            set
            {
                if (value.Length > 25) //проверка того что имя не длиннее 25 символов
                    throw new ArgumentException("The name is too long"); //если длиннее выводим сооб
                name = value; //присваиваем значение
            }
        }

        private int rarity; //приватное поле для редкости
        public int Rarity //свойство редкости
        {
            get
            {
                return rarity; //возвращаем редкость
            }
            set
            {
                if (value != 4 && value != 5) //проверка того что редкость может быть только 4 и 5
                    throw new ArgumentException($"Characters can't be {value} star/s"); //если это не 4 и 5, то выводим сооб
                rarity = value; //присваиваем...
            }
        }

        private string element; //приватное поле для элемента персонажа(пиро, гидро и тд)
        public string Element //свойство 
        {
            get
            {
                return element; //возвращаем элемент 
            }
            set
            {
                if (value != "Pyro" && value != "Cryo" && value != "Dendro" && //проверка на коректность элемента 
                    value != "Geo" && value != "Hydro" && value != "Electro" &&
                    value != "Anemo")
                    throw new ArgumentException($"There's no such element as {value}"); //если неверно ввели 
                element = value; //присваиваем значение...
            }
        }

        public Character(string name, int rarity, string element) //конструктор
        {
            Name = name; //устанавливаем имя, редкость и элемент
            Rarity = rarity;
            Element = element;
        }

        public int Price => Rarity == 4 ? 25 : 15; //возвращает цену в зависимости от редкости 
        public string CurrencyType => "Starglitter"; //фиксированная валюта

        public bool CanPurchase(Player player) //проверка возможности купить
        {
            return player.GetStarglitter() >= Price; //проверка хвататет ли денег
        }

        public void Purchase(Player player) //метод покупки персонажа
        {
            if (!CanPurchase(player))
                throw new ArgumentException("Can't buy character"); //если нельзя купить, то выводим сооб

            player.SetStarglitter(player.GetStarglitter() - Price); //если можно, снимаем деньги и добавдяем персонажа в коллекцию
            player.AddCharacter(this);
            Console.WriteLine($"You bought {this} for {Price} Starglitter"); //выводим сооб об успешности покупки 
        }

        public override void Use() //переопредение абстрактного метода 
        {
            Console.WriteLine($"You selected the character {Name} ({Element})");
        }
        
        public override string ToString() //для вывода информации
        {
            return $"{Name} ({Rarity}* {Element})";
        }
    }
}

