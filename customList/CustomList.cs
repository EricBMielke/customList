using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>
    {
        private T[] samplePopulatedList;
        public T this[int i]
        {
            get { return samplePopulatedList[i]; }
            set { samplePopulatedList[i] = value; }
        }
        public CustomList()
        {
            samplePopulatedList = new T[Capacity];
        }
        public int Capacity 
        {
            get {return _capacity; }
            set { _capacity = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private int _capacity = 5;
        private int _count = 0;

        public void Add(T itemToAdd)
        {
            if (Count == Capacity)
            {
                T[] newSampleList = new T[Capacity + 1];
                    for (int i = 0; i < Count; i++)
                    {
                        newSampleList[i] = samplePopulatedList[i];
                    }
                samplePopulatedList = newSampleList;
            }
            samplePopulatedList[Count] = itemToAdd;
            Count++;
        }
        public override string ToString()
        {
            return "Current List: " + samplePopulatedList;
        }
    }
}
