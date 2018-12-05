using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_arithmetics
{
    class Program
    {
        static string in1, in2, aOperator;
        static double answer;
        static bool bcontinue = true;
        static void Main(string[] args)
        {
            while (bcontinue)
            {
                Console.WriteLine("Hello to basic calculator");
                Console.WriteLine("What calculation would you like to perform? (+, -, *, /, %, ^ (power) ) ");
                aOperator = Console.ReadLine();
                while (aOperator != "+" && aOperator != "-" && aOperator != "*" && aOperator != "/" && aOperator != "%" && aOperator != "^")
                {
                    Console.WriteLine("Invalid operator {0}, please try again", aOperator);
                    aOperator = Console.ReadLine();
                }
                if (aOperator == "n^e")
                {
                    Console.WriteLine("Enter the number ");
                    in1 = Console.ReadLine();

                    Console.WriteLine("Enter the power ");
                    in2 = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Enter the first number ");
                    in1 = Console.ReadLine();

                    Console.WriteLine("Enter the second number ");
                    in2 = Console.ReadLine();
                }

                switch (aOperator)
                {
                    case "+":
                        answer = Convert.ToDouble(in1) + Convert.ToDouble(in2);
                        break;
                    case "-":
                        answer = Convert.ToDouble(in1) - Convert.ToDouble(in2);
                        break;
                    case "*":
                        answer = Convert.ToDouble(in1) * Convert.ToDouble(in2);
                        break;
                    case "/":
                        answer = Convert.ToDouble(in1) / Convert.ToDouble(in2);
                        break;
                    case "%":
                        answer = Convert.ToDouble(in1) % Convert.ToDouble(in2);
                        break;
                    case "^":
                        answer = Math.Pow(Convert.ToInt16(in1), Convert.ToInt16(in2));
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

                Console.WriteLine(" {0} {1} {2} = {3} ", in1, aOperator, in2, Convert.ToString(answer));
                Console.WriteLine("Do you want to perform another calculation? y/n");
                string c = Console.ReadLine();
                if (c == "y")
                {
                    answer = 0;
                }
                else if (c == "n")
                {
                    bcontinue = false;
                    Console.WriteLine("BYE!");
                }
                else
                {
                    Console.WriteLine("Incorrect input -  quitting");
                    bcontinue = false;
                }
            }
        }
    }
}
