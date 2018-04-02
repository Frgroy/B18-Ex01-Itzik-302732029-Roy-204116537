using System;

namespace B18_Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            RunB18_Ex01_05();
        }

        public static void RunB18_Ex01_05()
        {
            Console.WriteLine("Please insert 6 digits natural number, and than press enter");
            string recievedNaturalNumberString = Get6DigitsNaturalNumberString();
            Console.WriteLine(
            string.Format(
            "The largest digit in the recieved number is {0}",
            GetMaximumDigitFromNaturalNumberString(recievedNaturalNumberString)));
            Console.WriteLine(string.Format(
                "The smallest digit in the recieved number is {0}",
                GetMinimumDigitFromNaturalNumberString(recievedNaturalNumberString)));
                PrintNumberOfEvenDigitsInNaturalNumberString(recievedNaturalNumberString);
                PrintNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString(recievedNaturalNumberString);
        }

        public static string Get6DigitsNaturalNumberString()
        {
            int recievedNaturalNumber;
            string recievedString = Console.ReadLine();

            while (!int.TryParse(recievedString, out recievedNaturalNumber) || recievedString.Length != 6)
            {
                Console.WriteLine("Illegal input! Please try again.");
                recievedString = Console.ReadLine();
            }

            return recievedString;
        }

        public static int GetMaximumDigitFromNaturalNumberString(string naturalNumber)
        {
            int maximumDigitInString = (int)char.GetNumericValue(naturalNumber[0]);

            for (int i = 1; i < naturalNumber.Length; i++)
            {
                maximumDigitInString = (int)Math.Max(char.GetNumericValue(naturalNumber[i]), maximumDigitInString);
            }

            return maximumDigitInString;
        }

        public static int GetMinimumDigitFromNaturalNumberString(string naturalNumber)
        {
            int minimumDigitInString = (int)char.GetNumericValue(naturalNumber[0]);

            for (int i = 1; i < naturalNumber.Length; i++)
            {
                minimumDigitInString = (int)Math.Min(char.GetNumericValue(naturalNumber[i]), minimumDigitInString);
            }

            return minimumDigitInString;
        }

        public static void PrintNumberOfEvenDigitsInNaturalNumberString(string naturalNumber)
        {
            int countNumberOfEvenDigitsInNaturalNumberString = 0;

            for (int i = 0; i < naturalNumber.Length; i++)
            {
                if ((int)char.GetNumericValue(naturalNumber[i]) % 2 == 0)
                {
                    countNumberOfEvenDigitsInNaturalNumberString++;
                }
            }

            Console.WriteLine(string.Format(
                "There {0} {1} even number{2}",
                countNumberOfEvenDigitsInNaturalNumberString > 1 ? "are" : "is a",
                countNumberOfEvenDigitsInNaturalNumberString,
                countNumberOfEvenDigitsInNaturalNumberString > 1 ? "s" : string.Empty));
        }

        public static void PrintNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString(string naturalNumber)
        {
            int firstDigitValue = (int)char.GetNumericValue(naturalNumber, 0);
            int countNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString = 0;

            for (int i = 0; i < naturalNumber.Length; i++)
            {
                if ((int)char.GetNumericValue(naturalNumber[i]) < firstDigitValue)
                {
                    countNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString++;
                }
            }

            Console.WriteLine(string.Format(
                "There {0} {1} number{2} that smaller than the first digit",
                countNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString > 1 ? "are" : "is a",
                countNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString,
                countNumberOfDigitsThatSmallerThanTheFirstDigitInNaturalNumberString > 1 ? "s" : string.Empty));
        }
    }
}
