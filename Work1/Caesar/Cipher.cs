using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work1.Caesar
{
    public abstract class Cipher
    {
        public abstract string Encrypt(string text, int shift = 0, string keyWord = "");

        public abstract string Decrypt(string ciphertext, int shift = 0, string keyWord = "");

        public abstract string Hack(string ciphertext);

        public int HackerShift { get; protected set; }

        public string HackedKeyWord { get; set; }



        public static string Replace(string text, List<Tuple<char, char>> replaces)
        {
            if (replaces == null || replaces.Count == 0)
            {
                return text;
            }

            string resultText = "";
            foreach (var replace in replaces)
            {
                foreach (var sym in text)
                {
                    if (sym == replace.Item1)
                    {
                        resultText += replace.Item2;
                    }
                    else
                    {
                        resultText += sym;
                    }
                }
            }
            return resultText;
        }

        protected string AddSeparator(string text, int dist)
        {
            var resText = "";
            for (int i = 0; i < text.Length; i++)
            {
                resText += text[i];
                if (i % dist == dist - 1)
                {
                    resText += " ";
                }
            }
            return resText;
        }
    }
}
