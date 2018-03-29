using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex01_02;

namespace B18_Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            RunB18_Ex01_03();
        }

        public static void RunB18_Ex01_03()
        {
            Console.WriteLine("Hello. Insert height of HourGlass and than press enter: ");
            int requestedHourGlassHeight = getHeightFromUser();
            StringBuilder hourGlass = B18_Ex01_02.Program.buildHourGlassWithHeight(requestedHourGlassHeight);
            Console.WriteLine(hourGlass);
        }

        public static int getHeightFromUser()
        {
            string inputFromUser = Console.ReadLine();
            int requestedHourGlassHeight;
            while (!int.TryParse(inputFromUser, out requestedHourGlassHeight))
            {
                Console.WriteLine("Illegal input. Please try again.");
                inputFromUser = Console.ReadLine();
            }

            return requestedHourGlassHeight;
        }
    }
}
