using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work1.Caesar
{
    public abstract class Cipher
    {
        public abstract string Encrypt(string text, int shift);

        public abstract string Decrypt(string ciphertext, int shift);

        public abstract string Hack(string ciphertext);

        public int HackerShift { get; protected set; }

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
