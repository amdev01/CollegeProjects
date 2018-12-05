using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks
{
    class AdamsQueue<T> where T : struct
    {
        public int frontPointer;
        public int backPointer;
        private T?[] queue;
        public int queueSize;

        public AdamsQueue(int size)
        {
            queueSize = size;
            queue = new T?[queueSize];
            frontPointer = -1;
            backPointer = -1;
        }
        private bool hasEmpty()
        {
            for (int i=0;i<queueSize-1;i++)
            {
                if (queue[i] == null) return true;
            }
            return false;
        }
        public bool isFull()
        {
            if (frontPointer == 0 && backPointer > queueSize - 1) return true;
            else return false;
        }
        public bool isEmpty()
        {
            if (frontPointer < 0 && backPointer < 0) return true;
            else return false;
        }
        public void Enqueue(T data)
        {
            if (!isFull())
            {
                if (isEmpty()) frontPointer = 0;
                if (!isFull() && frontPointer > 0 && backPointer == queueSize - 1) backPointer = 0;
                else backPointer++;
                queue[backPointer] = data;
            }
            else Console.WriteLine("Queue is filled");
        }
        public void Dequeue()
        {
            if (!isEmpty())
            {
                queue[frontPointer] = null;
                frontPointer++;
            }
            else Console.WriteLine("Queue is empty");
        }
        public T? FrontQueue()
        {
            T? data = null;
            if (!isEmpty()) data = queue[frontPointer];
            return data;
        }
        public void printQueue()
        {
            if (!isEmpty())
            {
                string display = "";
                for (int i = 0; i < queue.Length; i++)
                    display += queue[i] + ", ";
                Console.WriteLine(display);
            }
            else Console.WriteLine("Queue is empty");
        }
    }
}
