using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store //простронство имен для кода внутри проекта
{
    internal class Shop //класс шоп для того чтобы представить шоп
    {
        public class StoreItem //для описания обьектов в шопе
        {
            private string name; //приватное имя предмета
            private string type; //приватный тип предмета
            private int price; //приватная цена предмета

            public string GetName() //геттер для того, чтобы получить имя предмета
            {
                return name; //ретюрн возвращает поле имени
            }

            public string GetTypeName() //геттер для того, чтобы получить тип предмета
            {
                return type; //ретюрн возвращает поле типа
            }

            public int GetPrice() //геттер для того, чтобы получить цену предмета
            {
                return price; //ретюрн возвращает поле цены
            }

            public void SetName(string value) //сеттер чтобы установить имя предмета
            {
                name = value; //присваивание полю имени какое то значение
            }

            public void SetTypeName(string value) //сеттер чтобы установить тип предмета
            {
                type = value; //присваивание полю типа какое то значение
            }

            public void SetPrice(int value) //сеттер чтобы установить цену предмета
            {
                price = value; //присваивание полю цены какое то значение
            }

        public StoreItem(string name, string type, int price) //создаем конструктор
        {
            SetName(name); //устанавливаем имя
            SetTypeName(type); //устанавливаем тип
            SetPrice(price);  //устанавливаем цену
        }

    }
        private List<StoreItem> items = new List<StoreItem>(); //создаем список для всех предметов в шопе
        public void AddItem(StoreItem item) => items.Add(item); //и добавляем

        public void ShowItems() //шоу айтемс поможет нам показать все предметы в шопе
        {
            Console.WriteLine("SHOP"); //название шопа
            foreach (var item in items) //перебираем все прдеметы 
            {
                Console.WriteLine($"{item.GetName()} ({item.GetTypeName()}) — {item.GetPrice()} primogems"); //выводит всю инфу о предмете
            }
        }
        
        public void PrintRecommended() //метод рекомендации для покупки
        {
            Console.WriteLine("Recommended:"); //вывод текста по рекомендации на консоль
            Console.WriteLine("1. Blessing of the Welkin Moon - $5");
            Console.WriteLine("\t(300 Genesis Cystals + 90 Primogems daily for 30 days)");
        }

        public void PrintSkins() //метод, который покажет скины
        {
            Console.WriteLine("Characters' Outfits:");
            Console.WriteLine("1. Red Dead of Night (Diluc) - 1680 GC");
            Console.WriteLine("2. Blossoming Starlight (Klee) - 1350 GC");
            Console.WriteLine("3. Summertime Sparkle (Barbara) - 1350 GC");
        }

        public void PrintPrimogemShop() //метод, который показывает магазин где можно купить примогемы
        {
            Console.WriteLine("");
        }

        public bool BuyWelkinMoon(Player player) //метод покупки
        {
            Console.WriteLine("Purchased Welkin Moon!\n+300 GC, will receive 90 Primogems daily"); 
            player.SetGenesisCrystals(player.GetGenesisCrystals() + 300); //это добавит игроку +300 валюты
            return true; //тру покажет успешна ли покупка
        }

        public bool BuyOutfit(Player player, Skin skinName, int price) //метод для покупки скина
        {
            if (player.GetGenesisCrystals() >= price) //проверяем есть ли у игрока ваще деньги
            {
                player.SetGenesisCrystals(player.GetGenesisCrystals() - price); //снимаем деньгу
                player.AddSkin(skinName); //и добавляем скин игроку
                Console.WriteLine($"Bought {skinName}"); //если покупка удачна выводится фраза об успешности покупки
                return true;
            }
            Console.WriteLine($"Not enough Genesis Crystals"); //а если не хватает деньги, выводиться эта фраза
            return false;
        }

        public bool BuyWithStarglitter(Player player, string item, int price) //покупка за звездный блеск
        {
            /*if Starglitter >= price
                st -= price
                if item contains fate Primogems += 160
                else weapon add item
                return true

            else
                not enough st
                return true*/

            if (player.GetStarglitter() >= price) //проверет хвататет ли игроку блеска
            {
                player.SetStarglitter(player.GetStarglitter() - price); //списываем блеск

                if (item.Contains("Fate") || item.Contains("fate")) //и если покупка фейт
                {
                    player.SetPrimogems(player.GetPrimogems() + 160); //начисляем блеска игроку
                    Console.WriteLine($"Bought {item}! +160 Primogems"); //и выводим сообщение
                }
                return true; //покупка успешна
            }

            Console.WriteLine("Not enough Starglitter"); //если не достаточно блеска выводим сообщение
            return false; //о провале покупки
        }

        public bool BuyWithStardust(Player player, string item, int price) //ананлогичная ситуация как и с звездным блеском
        {
            /*if Stardust >= price
                st -= price
                if item contains fate Primogems += 160
                return true

            else
                not enough st
                return true*/

            if (player.GetStardust() >= price)
            {
                player.SetStardust(player.GetStardust() - price);

                if (item.Contains("Fate") || item.Contains("fate"))
                {
                    player.SetPrimogems(player.GetPrimogems() + 160);
                    Console.WriteLine($"Bought {item}! +160 Primogems");
                }
                else
                {
                    Console.WriteLine($"Bought {item}!");
                }
                return true;
            }

            Console.WriteLine("Not enough Stardust");
            return false;
        }

        public bool BuyWithPrimogems(Player player, string item, int price)  //ананлогичная ситуация как и с звездным блеском
        {
            /*if Primogems >= price
                st -= price
                 Primogems += 160
                return true

            else
                not enough Primogems
                return true*/

            if (player.GetPrimogems() >= price)
            {
                player.SetPrimogems(player.GetPrimogems() - price);

                if (item.Contains("Fate") || item.Contains("fate"))
                {
                    player.SetPrimogems(player.GetPrimogems() + 160);
                    Console.WriteLine($"Bought {item}! +160 Primogems");
                }
                else
                {
                    Console.WriteLine($"Bought {item}!");
                }
                return true;
            }

            Console.WriteLine("Not enough Primogems");
            return false;
        }
        
        public void BuyItem(Player player, string itemName) //покупка по имени предмета
        {
            StoreItem item = items.FirstOrDefault(i => i.Name == itemName); //поиск предмета

            if (item == null) //если предмет не найден
            {
                Console.WriteLine("There is no such product!"); //выводим сооб и выходим из метода
                return;
            }

            if (player.GetPrimogems() < item.Price) //если недостаточно примогемов
            {
                Console.WriteLine("Not enough Primogems!"); //выводим сооб и выходим из метода
                return;
            }

            player.SpendPrimogems(item.Price); //снимаем примогемы со счета игрока

            switch (item.Type) //определяем тип предмета
            {
                case "Character":
                    player.AddCharacter(new Character() { Name = item.Name }); //добавляем персонажа 
                    Console.WriteLine($"Bought character {item.Name}!"); //и выводим сооб о покупке
                    break;

                case "Weapon":
                    player.AddWeapon(new Weapon() { Name = item.Name }); //добавляем оружие
                    Console.WriteLine($"Bought weapon {item.Name}!");
                    break;

                case "Skin":
                    player.AddSkin(new Skin() { Name = item.Name }); //добавляем скин
                    Console.WriteLine($"Bought skin {item.Name}!");
                    break;

                default:
                    Console.WriteLine("Unknown item type!"); //и если ничего из вышеперечисленного переходим в дефолт и выводим сообщение о том что такого предмета нету
                    break;
            }
        }
    }
}




