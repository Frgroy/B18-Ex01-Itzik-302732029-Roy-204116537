using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            printPalindromityOfString(userInputString);
            if (isNumericString(userInputString))
            {
                printParityOfNumericString(userInputString);
            }
            else
            {
                printNumberOfLowerCaseLetters(userInputString);
            }
        }

        public static string Parse()
        {
            string i_RecievedString = Console.ReadLine();
            while (!TryParse(i_RecievedString))
            {
                Console.WriteLine("Not a legal string\nPlease try again.");
                i_RecievedString = Console.ReadLine();
            }

            return i_RecievedString;
        }

        public static bool TryParse(string i_InputString)
        {
            return (isLetterString(i_InputString) || isNumericString(i_InputString)) && i_InputString.Length == 8 ? true : false;
        }

        public static void printPalindromityOfString(string i_InputString)
        {
            Console.WriteLine(string.Format("The string is{0}a palindrome!", 
                isStringPalindrome(i_InputString) ? " " : " not "));
        }

        public static bool isStringPalindrome(string i_InputString)
        {
            for (int i = 0; i < (i_InputString.Length / 2); i++)
            {
                if (i_InputString[i] != i_InputString[i_InputString.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static void printParityOfNumericString(string i_InputString)
        {
            Console.WriteLine(string.Format("The number is {0} ", 
                isNumericStringEven(i_InputString) ? "Even!" : "Odd!"));        
        }

        public static bool isLetterString(string i_InputString)
        {
            return Regex.IsMatch(i_InputString, "^[a-z,A-Z]+$");
        }

        public static bool isNumericString(string i_InputString)
        {
            return Regex.IsMatch(i_InputString, "^[0-9]+$");
        }

        public static bool isNumericStringEven(string i_InputString)
        {
            return int.Parse(i_InputString) % 2 == 0 ? true : false;
        }

        public static void printNumberOfLowerCaseLetters(string i_InputString)
        {
            Console.WriteLine(string.Format("There {0} {1} lower case letter{2}!", 
                numberOfLowerCaseLetterInLetterString(i_InputString) > 1 ? "are" : "is a", 
                numberOfLowerCaseLetterInLetterString(i_InputString), 
                numberOfLowerCaseLetterInLetterString(i_InputString) > 1 ? "s" : string.Empty));
        }

        public static int numberOfLowerCaseLetterInLetterString(string i_InputString)
        {
            return Regex.Matches(i_InputString, @"\p{Ll}").Count;
        }
    }
}