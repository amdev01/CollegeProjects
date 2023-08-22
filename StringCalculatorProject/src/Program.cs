namespace StringCalculatorProject;

public class Program
{
    static void Main(string[] args)
        {
            StringCalculator sc = new StringCalculator();
            Console.WriteLine($"Enter the equation you want to work out down below with the maximum of {StringCalculator._maxLen} characters in the equation (enter 'help' to display help menu)");
            (int code, string message) status = sc.Calc(Console.ReadLine());
            while (status.code == -1) status = sc.Calc(Console.ReadLine());


            // CALC
            Console.WriteLine("" + status.message);
            Console.Read();
        }

}
