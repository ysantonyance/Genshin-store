using System; //подключаем базовые классы
using System.Collections.Generic;//это для доступа к коллекциям
using System.Linq;//для Linq методов
using System.Text;//для работы со строками
using System.Threading.Tasks;//пространство имён, которое работает с асинхронными задачами

namespace Genshin_Store //пространство имён проекта
{
    public class Skin : InventoryItem, IPurchasable //класс Skin наследуется от InventoryItem и реализует интерфейс IPurchasable
    {
        private string ForCharacter; //приватное поле для имени персонажа, которому пренадлежит скин
        public void SetForCharacter(string forCharacter) //сеттер чтобы установить персонажа под скин
        {
            this.ForCharacter = forCharacter; //присваиваем значение для forCharacter
        }
        public string GetForCharacter() //геттер для получение имени персонажа
        {
            return ForCharacter; //возвращаем значение
        }
        public Skin(string name, int rarity, string forCharacter) //конструктор
        {
            Name = name; //устанавливаем для скина имя, редкость и персонажа, которму будет принадлежать скин
            Rarity = rarity;
            ForCharacter = forCharacter;

            if (string.IsNullOrWhiteSpace(Name)) //проверяем имя, чтобы оно было не пустое
                throw new ArgumentException("The name of the skin must not be empty");

            if (Rarity != 4 && Rarity != 5) //проверяем редкость скина
                throw new ArgumentException("Skins must only be 4* or 5*");

            if (string.IsNullOrWhiteSpace(ForCharacter)) //проверка, что указан верный персонаж
                throw new ArgumentException("Character wasn't specified for the skin");
        }
        public int Price //свойство для получение цены
        {
            get
            {
                return Rarity == 5 ? 2000 : 1680; //цена зависит от редкости, если 5 то 2000, если 4 то 1680
            }
        }

        public string CurrencyType => "GenesisCrystals"; //фиксированная валюта

        public bool CanPurchase(Player player) //проверка возможности купить скин
        {
            return player.GetGenesisCrystals() >= Price; //тру если у плейера есть деньги
        }

        public void Purchase(Player player) //метод покупки
        {
            if (!CanPurchase(player)) //проверка возможности приобрести 
                throw new InvalidOperationException("Not enought Genesis Crystals to buy a skin"); //если нет возможности, выводится на консоль сообщение

            player.SetGenesisCrystals(player.GetGenesisCrystals() - Price); //в ином случае списываем валюту со счета плейера и добавляем скин в коллекцию
            player.AddSkin(this);
            Console.WriteLine($"you bought {Name} for {Price} Genesis Crystals"); //выводим сообщение об успешности покупки
        }
        public override void Use() //реализация абстрактного класса из инвентори айтем
        {
            Console.WriteLine($"You equipped the skin {Name} for {ForCharacter}"); //сообщение что скин одет на персонажа
        }

        public override string ToString() //для вывода информации про скин
        {
            return $"{Name} ({Rarity}*) for {ForCharacter}";
        }
    }
}

