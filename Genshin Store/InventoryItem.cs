using System; //подключаем базовые классы
using System.Collections.Generic; //это для доступа к коллекциям
using System.Linq; //для Linq методов
using System.Text;  //для работы со строками
using System.Threading.Tasks; //пространство имён, которое работает с асинхронными задачами

namespace Genshin_Store //пространство имён для проекта
{
    public abstract class InventoryItem : IComparable<InventoryItem> //абстрактный класс InventoryItem, от которого будут наследоваться все предметы
    //реализует интерфейс IComparable для сортировки предметов
    {
        private string name; //приватное поле для имени предмета
        public string Name //и публичное
        {
            get {  return name; } //возвращает имя предмета
            set { name = value; } //устанавливает новое имя
        }

        private int rarity; //приватное поле для редкости предмета
        public int Rarity //т публичное
        {
            get { return rarity;}  //возвращает редкость предмета
            set { rarity = value; }  //устанавливает новую редкость
        }

        private int quantity = 1; //для кол-во предметов в инвенатре
        public int Quantity
        {
            get { return quantity; } //возвращает колво 
            set { quantity = value; }//устанавливает колво
        }

        protected InventoryItem(string name, int rarity, int quantity = 1) //при создании обьекта вызывается класс, который задает обьекту редкость, имя и колво
        {
            Name = name;
            Rarity = rarity;
            Quantity = quantity;
        }

        public abstract void Use(); //абстрактный класс, который определяет что именно произойдет если использовать предмет

        //public static InventoryItem operator +(InventoryItem a, InventoryItem b)
        //{
          //  return a + b;
        //}

        public static bool operator ==(InventoryItem a, InventoryItem b) //перегрузка оператора == 
        {
            return a?.Name == b?.Name && a?.Rarity == b?.Rarity; //сравниваем имя и редкость
        }

        public static bool operator !=(InventoryItem a, InventoryItem b) //перегрузка оператора !=
        {
            return !(a == b); //возвращаем значение == 
        }

        public static bool operator >(InventoryItem a, InventoryItem b) //перегрузка оператора >
        {
            return a.Rarity > b.Rarity; //будет истинной если первый предмет больше
        }

        public static bool operator <(InventoryItem a, InventoryItem b) //перегрузка оператора <
        {
            return a.Rarity < b.Rarity; //будет истинной если первый предмет будет меньше
        }

        public override bool Equals(object obj) //для сравнения предметов
        {
            InventoryItem other = obj as InventoryItem; //приводим обьект к инвентарь айтем 
            if (other == null) return false; //если не выходит то false
            return this.Name == other.Name && this.Rarity == other.Rarity; //сравниваем имя и редкость
        }

        public override int GetHashCode() //для использования  вколлекциях
        {
            return Name.GetHashCode() + Rarity.GetHashCode(); //генерируем имя и редкость
        }

        public int CompareTo(InventoryItem other) //сортировка предметов по редкости
        {
            if (other == null) return 1; //если второй обьект нулл, то текущий обьект больше
            return Rarity.CompareTo(other.Rarity); //сравниваем...
        }
        
        public void AddQuantity(int amount) //метод для увеличение колво предметов
        {
            if (amount > 0)
                Quantity += amount; //увеличиваем...
        }
        
        public void RemoveQuantity(int amount) //метод для уменьшения колво предметов
        {
            if (amount > 0 && amount <= Quantity)
                Quantity -= amount; //уменьшаем...
        }
    }
}

