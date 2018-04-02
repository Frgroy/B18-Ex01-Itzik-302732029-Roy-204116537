using System;
using System.Text;

namespace B18_Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            RunB18_Ex01_02();
        }

        public static void RunB18_Ex01_02()
        {
            StringBuilder hourGlass = BuildHourGlassWithHeight(5);
            Console.WriteLine(hourGlass);
        }

        public static StringBuilder BuildHourGlassWithHeight(int requestedHeight)
        {
            StringBuilder hourGlass = new StringBuilder(requestedHeight);
            int remainderOfDivisionByTwo;
            int higherHourGlassHeight = Math.DivRem(requestedHeight, 2, out remainderOfDivisionByTwo) - 1 + remainderOfDivisionByTwo;
            int lowerHourGlassHeight = higherHourGlassHeight;
            int midHourGlassHeight = 2 - remainderOfDivisionByTwo;

            for (int i = 0; i < higherHourGlassHeight; i++)
            {
                string hourGlassLineSpaces = new string(' ', i);
                hourGlass.Append(hourGlassLineSpaces);
                string hourGlassLineAsterisks = new string('*', requestedHeight + remainderOfDivisionByTwo - (2 * i) - 1);
                hourGlass.AppendLine(hourGlassLineAsterisks);
            }

            for (int i = 0; i < midHourGlassHeight; i++)
            {
                string hourGlassLineSpaces = new string(' ', (requestedHeight - 1) / 2);
                hourGlass.Append(hourGlassLineSpaces);
                string hourGlassLineAsterisks = new string('*', 1);
                hourGlass.AppendLine(hourGlassLineAsterisks);
            }

            for (int i = lowerHourGlassHeight; i > 0; i--)
            {
                string hourGlassLineSpaces = new string(' ', i - 1);
                hourGlass.Append(hourGlassLineSpaces);
                string hourGlassLineAsterisks = new string('*', requestedHeight - (2 * (i - 1)) + remainderOfDivisionByTwo - 1);
                hourGlass.AppendLine(hourGlassLineAsterisks);
            }

            return hourGlass;
        }
    }
}
