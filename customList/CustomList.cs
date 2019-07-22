using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable //,IComparable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return samplePopulatedList[i];
            }
        }
        //int IComparable.CompareTo(object obj)
        //{
        //    CustomList<int> c = (CustomList<int>)obj;
        //    return obj.CompareTo(this.obj);

        //}
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
                    newString.Append(",");
                }
            }
            return newString.ToString();
        }
        public static CustomList<T> operator + (CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> addedList = new CustomList<T>();
            for (int i = 0; i < list1.Count; i++)
            {
                addedList.Add(list1[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                addedList.Add(list2[i]);
            }
            return addedList;
        }
        public CustomList<T> Zip(CustomList<T> list1)
        {
            CustomList<T> zippedList = new CustomList<T>();
            int smallerArray = 0;
            if (list1.Count >= Count)
            {
                smallerArray = Count;
            }
            else
            {
                smallerArray = list1.Count;
            }
            for (int i = 0; i < smallerArray; i++)
            {
                zippedList.Add(samplePopulatedList[i]);
                zippedList.Add(list1[i]);
            }
            if (list1.Count >= Count)
            {
                for (int i = Count; i < list1.Count; i++)
                {
                    zippedList.Add(list1[i]);
                }
            }
            else
            {
                for (int i = list1.Count; i < Count; i++)
                {
                    zippedList.Add(samplePopulatedList[i]);
                }
            }
            return zippedList;
        }
        public static CustomList<T> operator - (CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> addedList = new CustomList<T>();
            addedList = list1;
            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                    if (list1[i].Equals(list2[j]))
                    {
                        addedList.Remove(list1[i]);
                    }
            }
            return addedList;
        }
        //public void Sort()
        //{
        //    T temp;
        //    for (int i = 0; i < samplePopulatedList.Length - 1; i++)

        //        for (int j = i + 1; j < samplePopulatedList.Length; j++)

        //            if ((samplePopulatedList[i]< samplePopulatedList[j]))
        //            {
        //               temp = samplePopulatedList[i];
        //               samplePopulatedList[i] = samplePopulatedList[j];
        //               samplePopulatedList[j] = temp;
        //            }

        //        foreach (T value in samplePopulatedList)
        //        {
        //            Console.Write(value + " ");
        //        }
        //}
    }
}
