using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{
    public class StringManipulator
    {
        public string ReverseString(string input)
        {
            // TODO: Implement the logic to reverse the input string
            char[] chars = input.ToCharArray();
          Array.Reverse(chars);


        //    return new string(chars);

            return new string(chars);
        }

        public bool IsPalindrome(string input)
        {
            // TODO: Implement the logic to check if the input string is a palindrome
            // (A palindrome = same forwards as backwards)

            input = input.ToLower();
            for (int i = 0, j = input.Length - 1; i <= j; i++, j--)
            {
                if (input[i] != input[j])
                {
                    return false;
                }

            }
            return true;
        }
    }
}
