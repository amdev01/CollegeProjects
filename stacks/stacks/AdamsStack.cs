using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks
{
    class AdamsStack<T> where T : struct
    {
        public int stackPointer;
        private T?[] stack;
        public int stackSize;
        private bool dynamic;

        public AdamsStack(int size)
        {
            stackSize = size;
            stack = new T?[stackSize];
            stackPointer = -1;
            dynamic = false;
        }

        public AdamsStack()
        {
            stack = new T?[0];
            stackPointer = -1;
            dynamic = true;
        }

        public bool isFull()
        {
            if (stackPointer == stack.Length - 1)
                return true;
            else return false;
        }

        public bool isEmpty()
        {
            if (stackPointer < 0)
                return true;
            else return false;
        }

        public void push(T data)
        {
            if (!dynamic)
            {
                if (!isFull())
                {
                    stackPointer++;
                    stack[stackPointer] = data;
                }
                else Console.WriteLine("Stack is full");
            }
            else
            {
                Array.Resize(ref stack, stack.Length + 1);
                stackPointer++;
                stack[stackPointer] = data;
            }
        }

        public void pop()
        {
            if (!isEmpty())
            {
                stack[stackPointer] = default(T);
                stackPointer--;
                if (dynamic) Array.Resize(ref stack, stack.Length - 1);
            }
            else Console.WriteLine("Stack is empty");
        }

        public T? peak()
        {
            T? data = null;
            if (!isEmpty())
            {
                data = stack[stackPointer];
            }
            return data;
        }

        public void printStack()
        {
            if (!isEmpty())
            {
                string display = "";
                for (int i = 0; i < stack.Length; i++)
                    display += stack[i] + ", ";
                Console.WriteLine(display);
            }
            else Console.WriteLine("Stack is empty");
        }
    }
}
