using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class WillsList<T> : IEnumerable<T>
    {
        // Do not alter this code in any way
        private T[] _items;
        private int _count;
        private const int InitialCapacity = 100;

        public WillsList()
        {
            _items = new T[InitialCapacity];
            _count = 0;
        }

        public void Add(T item)
        {
            _items[_count] = item;
            _count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}