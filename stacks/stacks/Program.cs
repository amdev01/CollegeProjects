using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            queues();
        }
         static void queues()
        {
            int size;
            Console.WriteLine("Enter the size of your queue:");
            size = getInput();
            AdamsQueue<int> newQueue = new AdamsQueue<int>(size);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Display queue 2. Enqueue 3. Get front value 4. Dequeue 5. exit");
                int menu = getInput();
                switch (menu)
                {
                    case 1:
                        newQueue.printQueue();
                        break;
                    case 2:
                        newQueue.Enqueue(getInput());
                        break;
                    case 3:
                        Console.WriteLine($"Front item is {newQueue.FrontQueue()}");
                        break;
                    case 4:
                        Console.WriteLine("Deleting front item...");
                        newQueue.Dequeue();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        static void stacks()
        {
            Console.WriteLine("Fixed size stack (1) or dynamic stack (2)?");
            int stackType = getInput();
            AdamsStack<int> newStack;
            while (stackType != 1 && stackType != 2)
            {
                Console.WriteLine("Fixed size stack (1) or dynamic stack (2)?");
                stackType = getInput();
            }
            int size;
            if (stackType == 1)
            {
                Console.WriteLine("Enter the size of your stack:");
                size = getInput();
                newStack = new AdamsStack<int>(size);
            }
            else newStack = new AdamsStack<int>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Display stack 2. Add to stack 3. Get the top value 4. Delete the top value 5. exit");
                int menu = getInput();
                switch (menu)
                {
                    case 1:
                        newStack.printStack();
                        break;
                    case 2:
                        Console.WriteLine("Type value to be added to the stack:");
                        newStack.push(getInput());
                        break;
                    case 3:
                        Console.WriteLine($"Top value is {newStack.peak()}");
                        break;
                    case 4:
                        Console.WriteLine("Deleting the top value...");
                        newStack.pop();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        static int getInput()
        {
            int newC;
            string console = Console.ReadLine();
            while (!int.TryParse(console, out newC))
            {
                Console.WriteLine($"{console} is not a number! Try again!");
                console = Console.ReadLine();
            }
            return newC;
        }
    }
}
