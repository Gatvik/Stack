using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /*
     * Стэк, который внутри себя имеет массив.
     * 
     * При вызове метода void Add(T item), проверяется не переполнен ли массив, и, если нет,
     * то добавлять в конец массива item. Если переполнен, увеличивается длина массива на 1
     * и вновь добавляется item.
     * 
     * При вызове метода T Pop(), в переменную записывается последний элемент массива, длина
     * массива изменяется на Length - 1 и возвращается переменная. 
     * 
     * При вызове метода T Peek(), возвращается последний элемент массива.
    */
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] stack = new T[0];
        private int counter = 0;

        public void Add(T item)
        {
            IncreaseStack();
            stack[counter] = item;
            counter++;
        }

        public T Pop()
        {
            if (stack.Length == 0) throw new Exception("StackIsEmpty");

            T item = stack[^1];
            DecreaseStack();
            return item;
        }

        public T Peek() => stack[^1];

        private void IncreaseStack()
        {
            T[] newStack = new T[stack.Length + 1];
            for (int i = 0; i < stack.Length; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }
        private void DecreaseStack()
        {
            T[] newStack = new T[stack.Length - 1];
            for (int i = 0; i < stack.Length - 1; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(stack, counter);

            //for(int i = counter - 1; i >= 0; i--)
            //{
            //    yield return stack[i];
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int position;
        private readonly int counter;
        public StackEnumerator(T[] array, int counter = 0)
        {
            this.array = array;
            this.counter = counter;
            position = counter;
        }

        public T Current { get { return array[position]; } }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position--;
            return position >= 0;
        }

        public void Reset()
        {
            position = counter;
        }
    }
}
