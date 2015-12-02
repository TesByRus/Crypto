using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work1.Caesar
{
    class VigenerCipher : Cipher
    {
        public override string Encrypt(string text, int shift = 0, string keyWord = "")
        {
            var handledText = HandleSourceText(text);

            var resString = "";
            var keyWordIndex = 0;
            foreach (var sym in handledText)
            {
                var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) + currentLocale.Alphabet.IndexOf(keyWord[keyWordIndex])) % currentLocale.Alphabet.Count;
                if (ciphreIndex < 0)
                {
                    ciphreIndex += currentLocale.Alphabet.Count;
                }
                resString += currentLocale.Alphabet[ciphreIndex];
                keyWordIndex = (keyWordIndex + 1) % keyWord.Length;
            }


            return AddSeparator(resString, 5);
        }

        public override string Decrypt(string ciphertext, int shift)
        {
            throw new NotImplementedException();
        }

        public override string Hack(string ciphertext)
        {
            throw new NotImplementedException();
        }
    }
}
