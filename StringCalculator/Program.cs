using System;


    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator sc = new StringCalculator();
            Console.WriteLine($"Enter the equation you want to work out down below with the maximum of {StringCalculator._maxLen} characters in the equation (enter 'help' to display help menu)");
            string sEquation = Console.ReadLine();
            while (sEquation.Length > StringCalculator._maxLen || sEquation.Length == 0)
            {
                Console.WriteLine($"Give equation is {sEquation.Length} characters long, the maximum is {StringCalculator._maxLen}, please re enter the equation");
                sEquation = Console.ReadLine();
            }

           
            // CALC

            Console.Read();
        }

}