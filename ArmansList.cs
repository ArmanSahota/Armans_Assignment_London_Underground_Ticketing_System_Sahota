using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Arman Sahota
// Assignment: Lond Underground Communt
// 01/20/2024

namespace Assignment_London_Underground_Ticketing_System
{
    
    public class ArmansList<T> : IEnumerable<T> where T : Rider
    {

        
        private T[] items;

        //count in array
        private int count;

        //public count in array
        public int Count => count;

        public ArmansList() : this(10) { }
        //list with size of 10

        public ArmansList(int initialSize)
        {//list size is the initial size
            items = new T[initialSize];
        }

        private void CheckIntegrity()
        {
            //if list is 80% full list increase the size by 2
            if (count >= 0.8 * items.Length)
            {
                T[] largerArray = new T[items.Length + 2];
                Array.Copy(items, largerArray, count);
                items = largerArray;
            }
        }

        public void Add(T item)
        {//adds item to end of list
            
            CheckIntegrity();
           
            items[count++] = item;
        }

        public void AddAtIndex(T item, int index)
        {//Inseret item at specific spot
            
            CheckIntegrity();
            for (int i = count - 1; i >= index; i--)
            {//move items down until reached desired index
                items[i + 1] = items[i];
            }
            
            items[index] = item;
            count++;
        }

        public void RemoveAtIndex(int index)
        {// remove items at certain index
            
            if (index < 0 || index >= count)
            {
                return;
            }
            // move everything after certain index to fit
            for (int i = index + 1; i < count; i++)
            {
                items[i - 1] = items[i];
            }
            count--;
        }

        public T? GetItem(int index)
        {
            if (index < 0 || index >= count)
            {// return to stop crashing
                return default(T);
            }
            
            return items[index];
        }

       
        IEnumerator IEnumerable.GetEnumerator() 
        {

            return this.GetEnumerator();
        }

        
        public IEnumerator<T> GetEnumerator()
        {
            
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        public ArmansList<T> ReturnRidersAtStation(int station)
        {//show list of riders that started at specific station

            ArmansList<T> result = new ArmansList<T>();
            foreach (T item in this)
            {
               
                if ((int)item.StationOn == station)
                {
                    result.Add(item);
                }
            }
            
            return result;
        }

        public ArmansList<T> ReturnRidersAtStation(Station station)
        {
            return this.ReturnRidersAtStation((int)station);
        }

        public ArmansList<T> ReturnAllActiveRiders()
        {//Returns a list of riders that haven't gotten off yet
            
            ArmansList<T> result = new ArmansList<T>();
            foreach (T item in this)
            {
                if (item.IsActive)
                {
                    result.Add(item);
                }
            }
            
            return result;
        }

    }
}