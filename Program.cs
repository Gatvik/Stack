using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);
            stack.Add(4);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}