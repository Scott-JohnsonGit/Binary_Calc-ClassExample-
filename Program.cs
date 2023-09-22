namespace Binary_Calc_ClassExample_
{
    using System;
    using System.Threading;
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int startspeed;
            int count = 0;
            while (true)
            {
                int fingers = 0;
                Console.Write("How Many fingers will you count on?: ");
                try
                {
                    fingers = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine($"Invalid number of fingers (Please use whole numbers Ex: 3)");
                    Thread.Sleep(3000);
                }
                if (count > 2) // adjust the starting speed based on the amount of playthroughs (for presentation purposes)
                {
                    startspeed = 1;
                }
                else if (count > 1)
                {
                    startspeed = 400;
                }
                else
                {
                    startspeed = 700;
                }
                
                p.Countfingers(fingers, startspeed);
                count++;
            }
            
            
        }
        /// <summary>
        /// finds the highest number associated with the amount of fingers used to count in binary (aka bits used for binary)
        /// </summary>
        /// <param name="fingers">fingers counted on (bits)</param>
        /// <param name="startspeed">how quickly the program will count to 10 (exponentially accelerates from there)</param>
        private void Countfingers(int fingers, int startspeed)
        {
            string s = "";
            int i = 1;
            while (s.Length <= fingers) // repeats until the number of bits rises above the number of fingers specified
            {

                s = BinCalculator.CalcBinary(i); // calulates the binary equivilent
                if (s.Length > fingers)
                {
                    break; // double checks after the value is calulated
                }
                Console.Clear(); // clear the console for smooth viewing experience
                Console.WriteLine($"Counting on {fingers} maximum fingers, fingers used {s.Length}\nNumber counted to {i}\nBinary number {s}"); // print information in console
                i++; // increase the number
                Thread.Sleep(startspeed); // slow down the counting so it is visible
                if (i > 10 && startspeed > 100) // speed up the counting exponentially after counting past 10
                {
                    startspeed -= 20;
                }
                else if (i > 10 && startspeed > 1) // speed up exponentially to max speed viewable speed after reaching 10ms (max is 1ms or 100 per second)
                {
                    startspeed -= 1;
                }
            }

        }
    }
}