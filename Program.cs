using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishAlphabet
{
    class EnglishAlphabet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>List with different variations of alphabet according to the input</returns>
        public static List<string> GetAlphabetString(int stream)
        {
            var code = stream.ToString();
            var result = new List<string>();
            // base case - just digits 1 2 5 6 8
            var baseCase = new List<string>();
            for (int i = 0; i < code.Length; i++)
                baseCase.Add(code[i].ToString());

            var baseCombination = Iterate(baseCase);
            if(baseCombination != null)
                result.Add(baseCombination);

            //to hold the indexes already passed
            var previous = new List<string>();
            for (int j = 0; j < code.Length - 1; j++)
            {
                var key = code[j].ToString() + code[j + 1].ToString();

                //array with combinations like 12 5 6 8 or 1 25 6 8
                var codeCombination = new List<string>();
                codeCombination.AddRange(previous);
                codeCombination.Add(key);
                for (int k = j + 2; k < code.Length; k++)
                    codeCombination.Add(code[k].ToString());

                previous.Add(code[j].ToString());
                var alphabetCombination = Iterate(codeCombination);
                //if alphabetCombination is not null, means it is a valid stream
                if (alphabetCombination != null)
                    result.Add(alphabetCombination);
            }

            return result;            
        }

        public static string Iterate(List<string> code)
        {
            var result = new StringBuilder();

            for (int i = 0; i < code.Count; i++)
            {
                //verify that key exists in dictionary
                if (englishDictionary.ContainsKey(code[i]))
                    result.Append(englishDictionary[code[i]]);
                else
                    return null;
            }
            return result.ToString();
        }

        public static Dictionary<string, string> englishDictionary = new Dictionary<string, string>()
        {
            { "1", "A"},
            { "2", "B"},
            { "3", "C"},
            { "4", "D"},
            { "5", "E"},
            { "6", "F"},
            { "7", "G"},
            { "8", "H"},
            { "9", "I"},
            { "10", "J"},
            { "11", "K"},
            { "12", "L"},
            { "13", "M"},
            { "14", "N"},
            { "15", "O"},
            { "16", "P"},
            { "17", "Q"},
            { "18", "R"},
            { "19", "S"},
            { "20", "T"},
            { "21", "U"},
            { "22", "V"},
            { "23", "W"},
            { "24", "X"},
            { "25", "Y"},
            { "26", "Z"}
        };

        static void Main(string[] args)
        {
            var alphabetCombinations = EnglishAlphabet.GetAlphabetString(12568);

            foreach(var combination in alphabetCombinations)
            {
                Console.WriteLine(combination);
            }

            Console.ReadLine();
        }

    }
}
