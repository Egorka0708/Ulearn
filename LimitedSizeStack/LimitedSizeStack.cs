using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T> : LinkedList<T>
    {
        private int Limit;

        public LimitedSizeStack(int limit)
        {
            if (limit > 0)
                Limit = limit;
        }

        public void Push(T item)
        {
            if (Count == Limit)
                RemoveFirst();
            AddLast(item);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            var result = Last;
            RemoveLast();
            return result.Value;
        }
    }
}
