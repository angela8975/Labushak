using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._2
{
    public class Suitcase
    {

        private string Color;
        private string Brand;
        private double Weight;
        private double MaxVolume;
        private Item[] Contents;
        private int Count;

        public Suitcase(string color, string brand, double weight, double maxVolume, Item[] contents, int count)
        {
            Color = color;
            this.Brand = brand;
            Weight = weight;
            MaxVolume = maxVolume;
            Contents = new Item[100];
            Count = 0;
        }
        public string _Color
        {
            get { return Color; }
            set { Color = value; }
        }
        public string _Brand
        {
            get { return Brand; }
            set { Brand = value; }
        }
        public double _Weight
        {
            get { return Weight; }
            set { Weight = value; }
        }
        public double _MaxVolume
        {
            get { return MaxVolume; }
            set { MaxVolume = value; }
        }
        public Item[] _Contents
        {
            get
            {
                Item[] current = new Item[Count];
                for (int i = 0; i < Count; i++)
                {
                    current[i] = Contents[i];
                }
                return current;
            }

        }
        public double CurrentVolume
        {
            get
            {
                double total = 0;
                for (int i = 0; i < Count; i++)
                {
                    total += Contents[i].Volume;

                }
                return total;
            }
        }
        public event Action<Item> OnItemAdded;
        public void AddItem(Item item)
        {
            if (CurrentVolume + item.Volume > MaxVolume)
                throw new
                    InvalidOperationException("Перевищено допустимий об'єм валізи!");
            if (Count >= Contents.Length)
                throw new
                    InvalidOperationException("Валіза переповнена (100 предметів максимум)!");
            Contents[Count] = item;
            Count++;

            if (OnItemAdded != null)
            {
                OnItemAdded(item);
            }



        }


    }
}
