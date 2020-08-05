using System;
using System.Collections.Generic;
using System.Linq;

namespace console_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = { "I live in Cherkassy Cherkassy is is is is beautiful city Beautiful people live hear", "I live in Cherkassy Cherkassy is beautiful city Beautiful people live hear" };
            var f = CountWordFrequency(text);
            Console.WriteLine((f.Count == 0) ? "empty word list" : "all right");
            DrawDictionary(f);
        }

        static public Dictionary<string, int> CountWordFrequency(string[] text)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (string row in text)
            {
                string[] words = row.ToLower().Split(' ');
                foreach (string word in words)
                {
                    if (!frequency.ContainsKey(word))
                    {
                        frequency.Add(word, 1);
                    }
                    else
                    {
                        int previousCount = 0;
                        frequency.TryGetValue(word, out previousCount);
                        frequency.Remove(word);
                        frequency.Add(word, previousCount + 1);
                    }
                }
            }
            return frequency;
        }

        static void DrawDictionary(Dictionary<string, int> list)
        {
            foreach (KeyValuePair<string, int> kvp in list)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
