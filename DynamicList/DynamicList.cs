using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
    [ExportClass]
    public class DynamicList<T> : IEnumerable
    {
        private T[] list;
        public int Count { get { return list.Length; } }

        public DynamicList()
        {
            this.list = new T[0];
        }
        public DynamicList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            this.list = new T[0];
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public T Items(int index)
        {
            if (index > list.Length - 1 || index < 0)
                throw new IndexOutOfRangeException();
            else
                return list[index];
        }
        public void Items(int index, T item)
        {
            if (index > list.Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                list[index] = item;
            }
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Array.Resize<T>(ref this.list, this.list.Length + 1);
            list[list.Length - 1] = item;
        }
        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            list = list.Where(element => !element.Equals(item)).ToArray();
        }
        public void RemoveAt(int index)
        {
            if (index > list.Length - 1 || index < 0)
                throw new IndexOutOfRangeException();
            else
            {
                list = list.Where((item, num) => num != index).ToArray();
            }
        }
        public void Clear()
        {
            list = new T[0];
        }

        public IEnumerator GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        
    }
    
}
