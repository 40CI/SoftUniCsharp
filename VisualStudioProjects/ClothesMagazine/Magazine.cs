using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesMagazine
{
    public class Magazine
    {
        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public List<Cloth> Clothes { get; private set; }

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth clothToRemove = Clothes.FirstOrDefault(c => c.Color == color);

            if (clothToRemove != null)
            {
                Clothes.Remove(clothToRemove);
                return true;
            }

            return false;
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.OrderBy(c => c.Size).FirstOrDefault();
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.FirstOrDefault(c => c.Color == color);
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            var orderedClothes = Clothes.OrderBy(c => c.Size);

            string result = $"{Type} magazine contains:\n";

            foreach (var cloth in orderedClothes)
            {
                result += $"{cloth}\n";
            }

            return result;
        }
    }
}
