using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{

    public class WordAnalyser
    {
        public List<string> FindLongestWords(string text)
        {
            string[] parts = text.Split(' ');
            int longest = 0;
            string longString = "";
            List<string> ans = new List<string>();
            foreach (string part in parts)
            {
                if (part.Length > longest)
                {
                    longString = part;
                    longest = longString.Length;
                }
            }
            ans.Add(longString);
            return ans;
        }

        public Dictionary<char, int> CalculateLetterFrequency(string text)
        {
            Dictionary<char, int> dict = new();
            foreach (char c in text)
            {
                if (!dict.ContainsKey(c)) dict[c] = 0;
                dict[c]++;
            }
            return dict;
        }
    }
}
