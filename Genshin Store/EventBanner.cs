using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Store
{
    public class EventBanner : Banner
    {
        public override string Name { get; }
        public override int Cost => 160;

        private Character eventCharacter;
        private int pityCounter = 0;
        private bool guaranteed = false;

        public EventBanner(string name, Character eventChar) : base()
        {
            Name = name;
            eventCharacter = eventChar;

            if (!Characters.Contains(eventChar))
                Characters.Add(eventChar);
        }

        protected override void InitializeItems()
        {
            base.InitializeItems();
        }

        public virtual int GetRarity(int chance)
        {
            pityCounter++;

            int result;

            if (pityCounter >= 99)
            {
                result = 5;
            }
            else
            {
                result = base.GetRarity(chance);
            }

            if (result == 5)
                pityCounter = 0;

            return result;

        }

        protected override object GetRandomItem(int rarity)
        {
            if (rarity == 5)
            {
                bool getEvent = guaranteed || Random.Next(2) == 0;

                if (getEvent)
                {
                    guaranteed = false;
                    return eventCharacter;
                }
                else
                {
                    var other5Star = Characters
                        .Where(c => c.Rarity == 5 && c != eventCharacter)
                        .ToList();

                    if (other5Star.Count > 0)
                    {
                        guaranteed = true;
                        return other5Star[Random.Next(other5Star.Count)];
                    }
                    else
                    {
                        return eventCharacter;
                    }
                }
            }

            return base.GetRandomItem(rarity);
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"\"{Name}\"");
            Console.WriteLine($"Event character: {eventCharacter.Name}");
            Console.WriteLine($"Cost: {Cost} Primogems per wish");
            Console.WriteLine($"Pity counter: {pityCounter}/90");
            Console.WriteLine($"Guaranteed event character: " + (guaranteed ? "Yes" : "No"));
            Console.WriteLine();
            Console.WriteLine("5* Rates:");
            Console.WriteLine("- 50% to get event character");
            Console.WriteLine("- If you don't get event character, next 5* is guaranteed event character");
            Console.WriteLine("- Guaranteed 5* at 90 wishes");
        }
    }
}
