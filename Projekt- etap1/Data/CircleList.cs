using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Text;

namespace Data
{
    public class CirclesList<T>
    {
        private List<T> _list = new();

        public void AddCircle(T obj)
        {
            _list.Add(obj);
        }

        public List<T> GetAllCircles()
        {
            return _list;
        }

        public void RemoveCircle(T obj)
        {
            _list.Remove(obj);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int Count()
        {
            int count = 0;
            foreach (T obj in _list)
                count++;
            return count;
        }

        

    }
}