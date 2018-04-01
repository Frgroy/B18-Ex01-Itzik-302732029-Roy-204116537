namespace B18_Ex01_01
{
    using System;

    public class Program
    {
        public static void Main()
        {
            RunB18_Ex01_01();
        }

        public static void RunB18_Ex01_01()
        {
            System.Console.WriteLine("Hello! please enter 3 binary numbers, with 9 digits.\nAfter every number, press Enter!");

            string firstBinaryNumber = Parse();
            string secondBinaryNumber = Parse();
            string thirdBinaryNumber = Parse();
            int firstDecimalNumber = ToDecimalInt(firstBinaryNumber);
            int secondDecimalNumber = ToDecimalInt(secondBinaryNumber);
            int thirdDecimalNumber = ToDecimalInt(thirdBinaryNumber);

            System.Console.WriteLine("The folowing numbers in decimal are: {0}, {1}, {2}", firstDecimalNumber, secondDecimalNumber, thirdDecimalNumber);
            PrintAverageOfOnesAndZerosInBinaryNumber(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber);
            int numberOf2PowerNumbers = CalcNumberOf2PowerNumbers(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber);
            string TwoPowerNumsMsg = string.Format(
            @"There {0} {1} {2} that {0} power of 2",
            numberOf2PowerNumbers > 1 ? "are" : "is a",
            numberOf2PowerNumbers,
            numberOf2PowerNumbers > 1 ? "numbers" : "number");

            System.Console.WriteLine(TwoPowerNumsMsg);

            int numberOfDownSeriesNumbers = CalcNumberOfDownSeriesNumbers(firstDecimalNumber, secondDecimalNumber, thirdDecimalNumber);
            string DownSeriesNumsMsg = string.Format(
            @"There {0} {1} {2} that {3} digits {0} down series",
            numberOfDownSeriesNumbers > 1 ? "are" : "is",
            numberOfDownSeriesNumbers,
            numberOfDownSeriesNumbers > 1 ? "numbers" : "number",
            numberOfDownSeriesNumbers > 1 ? "their" : "its");

            System.Console.WriteLine(DownSeriesNumsMsg);
            float averageOfRecievedNumbers = CalcAverageOfRecievedNumbers(firstDecimalNumber, secondDecimalNumber, thirdDecimalNumber);
            string decimalNumbersAvgMsg = string.Format(
            "The average of the recieved numbers is {0}",
            Math.Round(averageOfRecievedNumbers, 2));

            System.Console.WriteLine(decimalNumbersAvgMsg);
        }

        public static string Parse()
        {
            string i_RecievedString = System.Console.ReadLine();
            while (!TryParse(i_RecievedString))
            {
                System.Console.WriteLine("Not a binary number or a binary number with more than 9 digits!\nPlease try again.");
                i_RecievedString = System.Console.ReadLine();
            }

            return i_RecievedString;
        }

        public static bool TryParse(string i_RecievedUserBinaryString)
        {
            int i;

            for (i = 0; i < i_RecievedUserBinaryString.Length; i++)
            {
                if (i_RecievedUserBinaryString[i] != '0' && i_RecievedUserBinaryString[i] != '1')
                {
                    return false;
                }
            }

            return i == 9 ? true : false;
        }

        public static int ToDecimalInt(string i_RecievedUserBinaryString)
        {
            int i_DecimalNumber = 0;
            for (int i = 0; i < i_RecievedUserBinaryString.Length; i++)
            {
                if (i_RecievedUserBinaryString[i] == '1')
                {
                    i_DecimalNumber += (int)Math.Pow(2, 8 - i);
                }
            }

            return i_DecimalNumber;
        }

        public static int GetNumOfOneDigitsInBinaryNum(string i_RecievedUserString)
        {
            int i_CountNumOfOnesDigitsInBinaryNum = 0;
            for (int i = 0; i < i_RecievedUserString.Length; i++)
            {
                if (i_RecievedUserString[i] == '1')
                {
                    i_CountNumOfOnesDigitsInBinaryNum++;
                }
            }

            return i_CountNumOfOnesDigitsInBinaryNum;
        }

        public static bool IsTwoPower(string i_RecievedUserString)
        {
            return GetNumOfOneDigitsInBinaryNum(i_RecievedUserString) == 1;
        }

        public static int CalcNumberOf2PowerNumbers(params string[] i_RecievedUserBinaryStrings)
        {
            int i_CountNumberOf2PowerNumbers = 0;

            for (int i = 0; i < i_RecievedUserBinaryStrings.Length; i++)
            {
                if (IsTwoPower(i_RecievedUserBinaryStrings[i]))
                {
                    i_CountNumberOf2PowerNumbers++;
                }
            }

            return i_CountNumberOf2PowerNumbers;
        }

        public static void PrintAverageOfOnesAndZerosInBinaryNumber(params string[] i_RecievedUserStrings)
        {
            for (int i = 0; i < i_RecievedUserStrings.Length; i++ )
            {
                float AverageNumberOfOnesInTheIString = (float)GetNumOfOneDigitsInBinaryNum(i_RecievedUserStrings[i]) / i_RecievedUserStrings[i].Length;
                float AverageNumberOfZerosInTheIString = 1 - AverageNumberOfOnesInTheIString;
                Console.WriteLine(string.Format(@"Average of ones and zeros in number {0}: {1}, {2}", i + 1, AverageNumberOfOnesInTheIString, AverageNumberOfZerosInTheIString));
            }
        }

        public static bool IsNumDigitsDownSeries(int i_RecievedDecimalNumber)
        {
            int lastReadDigit = i_RecievedDecimalNumber % 10;

            i_RecievedDecimalNumber /= 10;
            while (i_RecievedDecimalNumber > 0)
            {
                if (i_RecievedDecimalNumber % 10 <= lastReadDigit)
                {
                    return false;
                }

                lastReadDigit = i_RecievedDecimalNumber % 10;
                i_RecievedDecimalNumber /= 10;
            }

            return true;
        }

        public static int CalcNumberOfDownSeriesNumbers(params int[] i_RecievedDecimalNumbers)
        {
            int i_CountNumberOfDownSeriesNumbers = 0;
            for (int i = 0; i < i_RecievedDecimalNumbers.Length; i++)
            {
                if (IsNumDigitsDownSeries(i_RecievedDecimalNumbers[i]))
                {
                    i_CountNumberOfDownSeriesNumbers++;
                }
            }

            return i_CountNumberOfDownSeriesNumbers;
        }

        public static float CalcAverageOfRecievedNumbers(params int[] i_RecievedDecimalNumbers)
        {
            int summaryOfRecievedDecimalNumbers = 0;

            for (int i = 0; i < i_RecievedDecimalNumbers.Length; i++)
            {
                summaryOfRecievedDecimalNumbers += i_RecievedDecimalNumbers[i];
            }

            return (float)summaryOfRecievedDecimalNumbers / i_RecievedDecimalNumbers.Length;
        }
    }
}