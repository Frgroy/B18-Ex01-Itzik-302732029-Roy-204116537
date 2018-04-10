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

            System.Console.WriteLine(
               "The folowing numbers in decimal are: {0}, {1}, {2}",
                firstDecimalNumber,
                secondDecimalNumber,
                thirdDecimalNumber);
            PrintAverageOfOnesAndZerosInBinaryNumber(
                firstBinaryNumber,
                secondBinaryNumber,
                thirdBinaryNumber);
            int numberOf2PowerNumbers = CalcNumberOf2PowerNumbers(
                firstBinaryNumber,
                secondBinaryNumber,
                thirdBinaryNumber);
            string TwoPowerNumsMsg = string.Format(
            @"There {0} {1} {2} that {0} power of 2",
            numberOf2PowerNumbers > 1 ? "are" : "is a",
            numberOf2PowerNumbers,
            numberOf2PowerNumbers > 1 ? "numbers" : "number");
            System.Console.WriteLine(TwoPowerNumsMsg);
            int numberOfDownSeriesNumbers = CalcNumberOfDownSeriesNumbers(
                firstDecimalNumber,
                secondDecimalNumber,
                thirdDecimalNumber);
            string DownSeriesNumsMsg = string.Format(
            @"There {0} {1} {2} that {3} digits {0} down series",
            numberOfDownSeriesNumbers > 1 ? "are" : "is",
            numberOfDownSeriesNumbers,
            numberOfDownSeriesNumbers > 1 ? "numbers" : "number",
            numberOfDownSeriesNumbers > 1 ? "their" : "its");
            System.Console.WriteLine(DownSeriesNumsMsg);
            float averageOfRecievedNumbers = CalcAverageOfRecievedNumbers(
                firstDecimalNumber,
                secondDecimalNumber,
                thirdDecimalNumber);
            string decimalNumbersAvgMsg = string.Format(
            "The average of the recieved numbers is {0}",
            Math.Round(averageOfRecievedNumbers, 2));
            System.Console.WriteLine(decimalNumbersAvgMsg);
        }

        public static string Parse()
        {
            string recievedString = System.Console.ReadLine();
            while (!TryParse(recievedString))
            {
                System.Console.WriteLine("Not a binary number or a binary number with more than 9 digits!\nPlease try again.");
                recievedString = System.Console.ReadLine();
            }

            return recievedString;
        }

        public static bool TryParse(string i_RecievedUserBinaryString)
        {
            int i;
            bool isInputContentLegal = true;

            for (i = 0; i < i_RecievedUserBinaryString.Length; i++)
            {
                if (i_RecievedUserBinaryString[i] != '0' && i_RecievedUserBinaryString[i] != '1')
                {
                    isInputContentLegal = false;
                }
            }

            return isInputContentLegal && i == 9 ? true : false;
        }

        public static int ToDecimalInt(string i_RecievedUserBinaryString)
        {
            int decimalNumber = 0;

            for (int i = 0; i < i_RecievedUserBinaryString.Length; i++)
            {
                if (i_RecievedUserBinaryString[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, 8 - i);
                }
            }

            return decimalNumber;
        }

        public static int GetNumOfOneDigitsInBinaryNum(string i_RecievedUserString)
        {
            int countNumOfOnesDigitsInBinaryNum = 0;

            for (int i = 0; i < i_RecievedUserString.Length; i++)
            {
                if (i_RecievedUserString[i] == '1')
                {
                    countNumOfOnesDigitsInBinaryNum++;
                }
            }

            return countNumOfOnesDigitsInBinaryNum;
        }

        public static bool IsTwoPower(string i_RecievedUserString)
        {
            bool isTwoPower = GetNumOfOneDigitsInBinaryNum(i_RecievedUserString) == 1 ? true : false;

            return isTwoPower;
        }

        public static int CalcNumberOf2PowerNumbers(params string[] i_RecievedUserBinaryStrings)
        {
            int countNumberOf2PowerNumbers = 0;

            for (int i = 0; i < i_RecievedUserBinaryStrings.Length; i++)
            {
                if (IsTwoPower(i_RecievedUserBinaryStrings[i]))
                {
                    countNumberOf2PowerNumbers++;
                }
            }

            return countNumberOf2PowerNumbers;
        }

        public static void PrintAverageOfOnesAndZerosInBinaryNumber(params string[] i_RecievedUserStrings)
        {
            for (int i = 0; i < i_RecievedUserStrings.Length; i++)
            {
                float averageNumberOfOnesInTheIString = (float)GetNumOfOneDigitsInBinaryNum(i_RecievedUserStrings[i]) / i_RecievedUserStrings[i].Length;
                float averageNumberOfZerosInTheIString = 1 - averageNumberOfOnesInTheIString;
                string avgMsgForIString = string.Format(
                @"Average of ones and zeros in {0}: {1}, {2}",
                i_RecievedUserStrings[i],
                Math.Round(averageNumberOfOnesInTheIString, 2),
                Math.Round(averageNumberOfZerosInTheIString, 2));
                Console.WriteLine(avgMsgForIString);
        }
    }

    public static bool IsNumDigitsDownSeries(int i_RecievedDecimalNumber)
    {
        int lastReadDigit = i_RecievedDecimalNumber % 10;
        bool isNumDigitsDownSeries = true;

        i_RecievedDecimalNumber /= 10;
        while (i_RecievedDecimalNumber > 0)
        {
            if (i_RecievedDecimalNumber % 10 <= lastReadDigit)
            {
                isNumDigitsDownSeries = false;
            }

            lastReadDigit = i_RecievedDecimalNumber % 10;
            i_RecievedDecimalNumber /= 10;
        }

        return isNumDigitsDownSeries;
    }

    public static int CalcNumberOfDownSeriesNumbers(params int[] i_RecievedDecimalNumbers)
    {
        int countNumberOfDownSeriesNumbers = 0;

        for (int i = 0; i < i_RecievedDecimalNumbers.Length; i++)
        {
            if (IsNumDigitsDownSeries(i_RecievedDecimalNumbers[i]))
            {
                countNumberOfDownSeriesNumbers++;
            }
        }

        return countNumberOfDownSeriesNumbers;
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