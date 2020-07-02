using System;
using System.Collections.Generic;
using System.Linq;

namespace Kemija
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kemija
            // https://open.kattis.com/problems/kemija08 
            // “papapripikapa” ->->->->  “paprika”
            // -------- I get Time Limit Exceeded !!!! ---------------


            //var myCipherText = EnterCipherText();
            var myCipherText = Console.ReadLine();

            var cipherList = StringToCharList(myCipherText);

            //var plainList = GetPlaintCharList(cipherList);
            var plainList = GetPlaintCharList2(cipherList);

            var answer = CharListToOneString(plainList);
            Console.WriteLine(answer);

        } // == End main() ==
        private static string CharListToOneString(List<char> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str = str + list[i].ToString();
            }
            return str;
        }
        private static List<char> GetPlaintCharList2(List<char> yourCipher)
        {
            var noVowels = new List<char>();

            char pivot=' ';
            int k = 0;
            try
            {
                if (yourCipher.Count == 0)
                    throw new IndexOutOfRangeException();
                while (true)
                {
                    pivot = yourCipher[k];

                    if (IsVowelNotY(pivot) == true)
                    {
                        noVowels.Add(pivot);
                        k = k + 3;
                    }
                    else
                    {
                        noVowels.Add(pivot);
                        k = k + 1;
                    }
                    if (k >= yourCipher.Count)
                        break;
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<char>();
            }
            return noVowels;
        }
        private static List<char> GetPlaintCharList(List<char> yourCipher)
        {
            var result = new List<char>();
            result = yourCipher;

            for (int i = 0; i < result.Count; i++)
            {
                if (IsVowelNotY(result[i]) == true) // vowel case
                    DoubleRemoveInList(result, i);

                else
                    continue;
            }
            return result;
        }
        private static void DoubleRemoveInList(List<char> list, int myIndex)
        {
            list.RemoveAt(myIndex + 1);
            list.RemoveAt(myIndex + 1);
        }

        private static bool IsVowelNotY(char yourChar)
        {
            // the case of 'y' is not discussed
            char pivot = char.ToLower(yourChar);
            switch (pivot)
            {
                case 'a':
                    return true;
                case 'e':
                    return true;
                case 'i':
                    return true;
                case 'o':
                    return true;
                case 'u':
                    return true;
                default:
                    return false;
            }
        }

        private static List<char> StringToCharList(string str)
        {
            //var arrChar = str.ToCharArray();
            //var listChar = arrChar.ToList();
            //return listChar;

            var myChars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                myChars.Add(str[i]);
            }
            return myChars;
        }
        private static string EnterCipherText()
        {
            string str = "";
            try
            {
                str = Console.ReadLine();

                if (InputConditions(str) == false)
                    throw new ArgumentException();
                if (AllIsLowerOrSpace(str) == false)
                    throw new ArgumentException();

                str = str.ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterCipherText();
            }
            return str;
        }
        private static bool InputConditions(string str)
        {
            if (str.Length < 0 || str.Length > 100)
                return false;
            else return true;
        }
        private static bool AllIsLowerOrSpace(string str)
        {
            var arr = str.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsWhiteSpace(arr[i]) == false && char.IsLower(arr[i]) == false)
                    return false;
            }
            return true;
        }
    }
}
