using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Work1.Caesar
{
    public class CaesarCipher : Cipher
    {

        public override string Encrypt(string text, int shift, string keyWord = "")
        {
            var handledText = HandleSourceText(text);

            var resString = "";
            foreach (var sym in handledText)
            {
                var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) + shift) % currentLocale.Alphabet.Count;
                if (ciphreIndex < 0)
                {
                    ciphreIndex += currentLocale.Alphabet.Count;
                }
                resString += currentLocale.Alphabet[ciphreIndex];
            }
            return AddSeparator(resString, 5);
        }

        public override string Decrypt(string ciphertext, int shift)
        {
            var handledText = HandleSourceText(ciphertext);

            var resString = "";
            foreach (var sym in handledText)
            {
                var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) - shift) % currentLocale.Alphabet.Count;
                if (ciphreIndex < 0)
                {
                    ciphreIndex += currentLocale.Alphabet.Count;
                }
                resString += currentLocale.Alphabet[ciphreIndex];
            }
            return AddSeparator(resString, 5);
        }

        public override string Hack(string ciphertext)
        {
            var handledText = HandleSourceText(ciphertext);
            var russianLocale = Locales.LocalesList.Find(x => x.Name == "Русский");

            var minShift = 32;
            var minSum = -1.0;
            for (var shift = 0; shift < 32; shift++)
            {
                var resString = "";
                foreach (var sym in handledText)
                {
                    var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                    var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) + shift) % currentLocale.Alphabet.Count;
                    if (ciphreIndex < 0)
                    {
                        ciphreIndex += currentLocale.Alphabet.Count;
                    }
                    resString += currentLocale.Alphabet[ciphreIndex];
                }

                var wTable = GetFrequencyTable(resString);

                var sum = 0.0;
                for (var i = 0; i < 32; i++)
                {
                    sum += Math.Pow((russianLocale.CharFrequency.Values.ToList()[i] - wTable.Values.ToList()[i]), 2);
                }

                if (sum < minSum || minSum == -1.0)
                {
                    minSum = sum;
                    minShift = shift;
                }
            }

            this.HackerShift = 32 - minShift;

            return Decrypt(ciphertext, 32 - minShift);
        }

        private Dictionary<char, double> GetFrequencyTable(string text)
        {
            var russianLocale = Locales.LocalesList.Find(x => x.Name == "Русский");
            return russianLocale.CharFrequency.ToDictionary(charFreq => charFreq.Key, charFreq => CalcFrequency(text, charFreq.Key));
        }

        private double CalcFrequency(string text, char c)
        {
            var count = text.Count(sym => sym == c);
            return (double)count / text.Length;
        }
    }
}
