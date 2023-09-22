using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Calc_ClassExample_
{
    /// <summary>
    /// Calulates binary to real whole numbers and vice versa
    /// </summary>
    public static class BinCalculator
    {
        /// <summary>
        /// Finds the binary equivilent of a real number in string format
        /// </summary>
        /// <param name="real">Whole real number</param>
        /// <returns>Equal binary value string</returns>
        public static string CalcBinary(int real)
        {
            uint max = (uint)Math.Pow(2, 30); // sets maximum value: 2 to the power of 30 
            string binary = "";
            while (max > 0)
            {
                if (real == 0) // if real value has been found - fill rest of the unused bits with 0s
                {
                    for (uint i = 1; i < Math.Pow(2, 30); i *= 2) // repeat until i == max
                    {
                        if (i <= max) // adds the 0s to the string
                        {
                            binary += "0";
                        }
                        else
                        {
                            return binary; // has found all bits
                        }
                    }

                }
                if (max > real) // maximum is higher than the number - halves the maximum & adds 0 to the end
                {
                    if (binary != "") // if no 1s are present skips adding 0
                    {
                        binary += "0";
                    }
                }
                else if (max == real && max == 1) // real == 1 - add a 0 to the end and set max to 0 (prevent infinite loops)
                {
                    binary += "1";
                    max = 0;
                }
                else // real number is greater than the maximum - take the amount of max out of the real number and add a 1 to the binary
                {
                    real -= (int)max;
                    binary += "1";
                }
                max /= 2;
            }
            return binary;
        }
        /// <summary>
        /// Calulates binary from real number, returns int (limited by int32)
        /// </summary>
        /// <param name="real">Whole real number</param>
        /// <returns>Int version of the binary equivilent</returns>
        public static int CalcBinaryInt(int real)
        {
            return int.Parse(CalcBinary(real));
        }
        /// <summary>
        /// Takes a binary number and returns the real number
        /// </summary>
        /// <param name="binary">Binary number</param>
        /// <returns>real number equivilent</returns>
        public static int CalcDecimal(int binary)
        {
            int total = 0; // the real number
            int bit_count = 1; // top value of bit making the number
            foreach (char bit in binary.ToString().Reverse()) // reverses string version of the binary number
            {
                if (bit == '1')
                {
                    total += bit_count; // If 1 is found add the value of top bit
                }
                bit_count *= 2; // double maximum bit value
            }
            return total;
        }
    }
}
