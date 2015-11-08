using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Work1.Caesar
{
    public class CaesarCipher
    {
        private string _sourceText;

        public string SourceText
        {
            get { return _sourceText; }
            set { _sourceText = ConvertSourceText(value); }
        }
        public string CurrentCipher { get; set; }
        public Locale CurrentLocale { get; set; }
        public int Shift { get; set; }

        public void Run()
        {
            var resList = new List<string>();
            foreach (var sym in SourceText)
            {
                var ciphreIndex = (CurrentLocale.CipherAlphabet.IndexOf(sym) + Shift) % CurrentLocale.CipherAlphabet.Count;
                if (ciphreIndex < 0)
                {
                    ciphreIndex += CurrentLocale.CipherAlphabet.Count;
                }
                resList.Add(CurrentLocale.CipherAlphabet[ciphreIndex].ToString());
            }
            CurrentCipher = String.Concat(resList.ToArray());
        }


        string ConvertSourceText(string sourceText)
        {
            var upper = sourceText.ToUpper();

            upper = Replace(upper, CurrentLocale.ReplacmentList);
            var resString = new List<string>();

            foreach (var sym in upper)
            {
                if (CurrentLocale.Alphabet.Contains(sym))
                {
                    resString.Add(sym.ToString());
                }
            }
            return String.Concat(resString.ToArray());
        }

        private string Replace(string text, List<Tuple<char, char>> replaces)
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
    }
}
