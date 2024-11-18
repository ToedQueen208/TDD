using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{

    public class WordAnalyser
    {
        public List<string> FindLongestWords(string text)
        {
            text = text.Trim();
            if (text.Length == 1) return new List<string>{ text };
            Dictionary<string, int> wordLengths = new();
            string[] parts = text.Split(' ');
            int longestLength = Int32.MinValue;

            foreach (string part in parts)
            {
                int n = part.Length;
                if (!wordLengths.ContainsKey(part)) wordLengths[part] = n;
                longestLength = Math.Max(longestLength, n);
            }

            List<string> ans = new List<string>();

            foreach (var entry in wordLengths)
            {
                if (entry.Value == longestLength)
                {
                    ans.Add(entry.Key);
                }
            }
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
