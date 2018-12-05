using System;


namespace BusProject
{
    class Program
    {
        /// <summary>
        /// Init variables and call other functions.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int? onPeakN = null, offPeakN = null, onPeakMean = null, offPeakMean = null, meanDiff = null;
            int?[] onPeakPassengers = null, offPeakPassengers = null;
            string biggerMean = "";
            input(ref onPeakN, ref offPeakN, ref onPeakPassengers, ref offPeakPassengers);
            calculate(onPeakN, ref onPeakMean, onPeakPassengers, offPeakN, ref offPeakMean, offPeakPassengers, ref biggerMean, ref meanDiff);
            output(onPeakMean, offPeakMean, biggerMean, meanDiff);
        }

        /// <summary>
        /// Get number of on-peak and off peak buses.
        /// Iterate for each and get number of passengers
        /// on each bus.
        /// </summary>
        /// <param name="onPeakN"></param>
        /// <param name="offPeakN"></param>
        /// <param name="onPeakPassengers"></param>
        /// <param name="offPeakPassengers"></param>
        static void input(ref int? onPeakN, ref int? offPeakN, ref int?[] onPeakPassengers, ref int?[] offPeakPassengers)
        {
            Console.WriteLine("Enter the number of on-peak buses sampled: ");
            onPeakN = getInput();

            onPeakPassengers = new int?[Convert.ToInt16(onPeakN)];
            for (int i = 0; i < onPeakN; i++)
            {
                Console.WriteLine($"Enter the number of passengers of on-peak bus {i + 1}");
                onPeakPassengers[i] = getInput();
            }

            Console.WriteLine("Enter the number of off-peak buses sampled: ");
            offPeakN = getInput();

            offPeakPassengers = new int?[Convert.ToInt16(offPeakN)];
            for (int i = 0; i < offPeakN; i++)
            {
                Console.WriteLine($"Enter the number of passengers of off-peak bus {i + 1}");
                offPeakPassengers[i] = getInput();
            }

        }

        /// <summary>
        /// Return input only if it's a number.
        /// Loop until user enters a string that can be parsed.
        /// </summary>
        static int? getInput()
        {
            string Input = Console.ReadLine();
            int ret = 0;
            while (int.TryParse(Input, out ret) != true)
            {
                Console.WriteLine("Input must be a number! Try again:");
                Input = Console.ReadLine();
            }
            if (ret < 0)
            {
                Console.WriteLine("Input cannot be negative! Try again: ");
                getInput();
            }
            return ret;
        }

        /// <summary>
        /// Iterate through both arrays and add their values
        /// to total to find mean, mean difference and which
        /// is bigger.
        /// </summary>
        /// <param name="onPeakN"></param>
        /// <param name="onPeakMean"></param>
        /// <param name="onPeakPassengers"></param>
        /// <param name="offPeakN"></param>
        /// <param name="offPeakMean"></param>
        /// <param name="offPeakPassengers"></param>
        /// <param name="biggerMean"></param>
        /// <param name="meanDiff"></param>
        static void calculate(int? onPeakN, ref int? onPeakMean, int?[] onPeakPassengers,
            int? offPeakN, ref int? offPeakMean, int?[] offPeakPassengers, ref string biggerMean, ref int? meanDiff)
        {
            int totalOnPeak = 0;
            if (onPeakN != 0)
            {
                for (int i = 0; i < onPeakN; i++)
                {
                    totalOnPeak += Convert.ToInt16(onPeakPassengers[i]);
                }
                onPeakMean = totalOnPeak / onPeakN;
            }
            else
            {
                onPeakMean = 0;
            }

            int totalOffPeak = 0;
            if (offPeakN != 0)
            {
                for (int i = 0; i < offPeakN; i++)
                {
                    totalOffPeak += Convert.ToInt16(offPeakPassengers[i]);
                }
                offPeakMean = totalOffPeak / offPeakN;
            }
            else
            {
                offPeakMean = 0;
            }

            biggerMean = isBigger(onPeakMean, offPeakMean) ? "On-Peak" : "OffPeak";

            if (isBigger(onPeakMean, offPeakMean)) meanDiff = onPeakMean - offPeakMean;
            else meanDiff = offPeakMean - onPeakMean;

        }

        /// <summary>
        /// Compare two numbers a and b
        /// if a is bigger than b return true
        /// if not then return false.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static bool isBigger(int? a, int? b)
        {
            if (a > b) return true;
            return false;
        }

        /// <summary>
        /// Output means, difference and which one is
        /// bigger onto the screen.
        /// </summary>
        /// <param name="onPeakMean"></param>
        /// <param name="offPeakMean"></param>
        /// <param name="biggerMean"></param>
        /// <param name="meanDiff"></param>
        static void output(int? onPeakMean, int? offPeakMean, string biggerMean, int? meanDiff)
        {
            Console.Clear();
            Console.WriteLine($"Mean number of passengers on the on-peak buses: {onPeakMean} ");
            Console.WriteLine($"Mean number of passengers on the off-peak buses: {offPeakMean} ");
            Console.WriteLine($"The {biggerMean} mean is bigger ");
            Console.WriteLine($"Difference between means is {meanDiff} ");
            Console.Read();
        }
    }
}
