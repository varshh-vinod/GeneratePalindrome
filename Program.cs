using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Codejam
{
    class PalindromeMaker
    {
        static String Make(String baseString)
        {
            Dictionary<Char, int> letterCount = new Dictionary<Char, int>();
            int evenCountLetters = 0;
            int oddCountLetters = 0;
            foreach (Char letter in baseString)
            {
                if (letterCount.ContainsKey(letter))
                    letterCount[letter] += 1;
                else
                    letterCount[letter] = 1;
            }
            foreach (int countOfLetter in letterCount.Values)
            {
                if (countOfLetter % 2 == 0)
                    evenCountLetters++;             //evenCountLetters= letterCount.Where(p => p.Value %2 == 0).Count();
                else               
                    oddCountLetters++;            //oddCountLetters = letterCount.Where(p => p.Value % 2 != 0).Count();
            }
            if (evenCountLetters + oddCountLetters == 1)
                return baseString;
            if (oddCountLetters <= 1)
                return MakePalindrome(baseString, new SortedDictionary<Char, int>(letterCount));
            else
                return "";
        }
        public static String MakePalindrome(String baseString, SortedDictionary<Char, int> letterCount)
        {
            int indexOfNewPalindromeString = 0;
            Char[] PalindromeCharacterArray = new Char[baseString.Length];
            int numberOfUsedUpLetters = 0;
            foreach (Char c in letterCount.Keys)
            {
                numberOfUsedUpLetters = 0;
                while (numberOfUsedUpLetters < letterCount[c])
                {
                    if (numberOfUsedUpLetters !=0 || letterCount[c] % 2 == 0)
                    {
                        PalindromeCharacterArray[indexOfNewPalindromeString] = c;
                        PalindromeCharacterArray[baseString.Length - indexOfNewPalindromeString - 1] = c;
                        numberOfUsedUpLetters = numberOfUsedUpLetters + 2;
                        indexOfNewPalindromeString++;
                    }
                    else
                    {
                        PalindromeCharacterArray[baseString.Length / 2] = c;
                        numberOfUsedUpLetters = numberOfUsedUpLetters+1;
                    }
                }
            }
            return new string(PalindromeCharacterArray);
        }
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            PalindromeMaker palindromeMaker = new PalindromeMaker();
            do
            {
                Console.WriteLine(Make(input));
                input = Console.ReadLine();
            } while (input != "-1");
        }
    }
}
