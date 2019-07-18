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
                Capacity++;
            }
            samplePopulatedList[Count] = itemToAdd;
            Count++;
        }
        public void Remove(T valueToRemove)
        {
            if (Find(valueToRemove) >= 0)
            {
                int indexToRemove = Find(valueToRemove);

                T[] newTemporaryList = new T[Capacity];
                int j = 0;
                for (int i = 0; i < Count; i++, j++)
                {
                    if (i != indexToRemove)
                    {
                        newTemporaryList[j] = samplePopulatedList[i];
                    }
                    else
                    { 
                        j--;
                    }
                }
                samplePopulatedList = newTemporaryList;
                Count--;
            }
        }
        public int Find(T valueToFind)
        {
            for (int i = 0; i < Count; i++)
            {
                if (samplePopulatedList[i].Equals(valueToFind))
                {
                    return i;
                }
            }
            return -1;
        }
        public override string ToString()
        {
            StringBuilder newString = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                newString.Append(samplePopulatedList[i]);
                if (i != (Count - 1))
                {
                    newString.Append(" ");
                }
            }
            return newString.ToString();
        }
    }
}
