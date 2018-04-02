using System;
using System.Text.RegularExpressions;

namespace B18_Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            RunB18_Ex01_04();
        }

        public static void RunB18_Ex01_04()
        {
            Console.WriteLine("Hello, please enter a 8 characters string");
            string userInputString = Parse();
            PrintPalindromityOfString(userInputString);
            if (IsNumericString(userInputString))
            {
                PrintParityOfNumericString(userInputString);
            }
            else
            {
                PrintNumberOfLowerCaseLetters(userInputString);
            }
        }

        public static string Parse()
        {
            string recievedString = Console.ReadLine();

            while (!TryParse(recievedString))
            {
                Console.WriteLine("Not a legal string\nPlease try again.");
                recievedString = Console.ReadLine();
            }

            return recievedString;
        }

        public static bool TryParse(string i_InputString)
        {
            bool isLetterString = IsLetterString(i_InputString);
            bool isNumericString = IsNumericString(i_InputString);

            return (isLetterString || isNumericString) && i_InputString.Length == 8 ? true : false;
        }

        public static void PrintPalindromityOfString(string i_InputString)
        {
            Console.WriteLine(string.Format(
                "The string is{0}a palindrome!",
                IsStringPalindrome(i_InputString) ? " " : " not "));
        }

        public static bool IsStringPalindrome(string i_InputString)
        {
            bool isStringPalindrome = true;

            for (int i = 0; i < (i_InputString.Length / 2); i++)
            {
                if (i_InputString[i] != i_InputString[i_InputString.Length - i - 1])
                {
                     isStringPalindrome = false;
                }
            }

            return isStringPalindrome;
        }

        public static void PrintParityOfNumericString(string i_InputString)
        {
            Console.WriteLine(string.Format(
                "The number is {0} ", 
                IsNumericStringEven(i_InputString) ? "Even!" : "Odd!"));        
        }

        public static bool IsLetterString(string i_InputString)
        {
            bool isLetterString = Regex.IsMatch(i_InputString, "^[a-z,A-Z]+$");

            return isLetterString;
        }

        public static bool IsNumericString(string i_InputString)
        {
            bool isNumericString = Regex.IsMatch(i_InputString, "^[0-9]+$");

            return isNumericString;
        }

        public static bool IsNumericStringEven(string i_InputString)
        {
            bool isNumericStringEven = int.Parse(i_InputString) % 2 == 0 ? true : false;

            return isNumericStringEven;
        }

        public static void PrintNumberOfLowerCaseLetters(string i_InputString)
        {
            Console.WriteLine(string.Format(
                "There {0} {1} lower case letter{2}!", 
                NumberOfLowerCaseLetterInLetterString(i_InputString) > 1 ? "are" : "is a", 
                NumberOfLowerCaseLetterInLetterString(i_InputString), 
                NumberOfLowerCaseLetterInLetterString(i_InputString) > 1 ? "s" : string.Empty));
        }

        public static int NumberOfLowerCaseLetterInLetterString(string i_InputString)
        {
            int numberOfLowerCaseLetterInLetterString = Regex.Matches(i_InputString, @"\p{Ll}").Count;

            return numberOfLowerCaseLetterInLetterString;
        }
    }
}