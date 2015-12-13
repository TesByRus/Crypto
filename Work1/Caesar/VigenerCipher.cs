using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work1.Caesar
{
    class VigenerCipher : Cipher
    {

        public VigenerCipher()
        {
            HackedKeyWord = "";
        }
        public override string Encrypt(string text, int shift = 0, string keyWord = "")
        {
            if (text.Length > 0 && keyWord.Length > 0)
            {

                var handledText = HandleSourceText(text);

                var resString = "";
                var keyWordIndex = 0;
                foreach (var sym in handledText)
                {
                    var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                    var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) +
                                       currentLocale.Alphabet.IndexOf(keyWord[keyWordIndex])) %
                                      currentLocale.Alphabet.Count;
                    if (ciphreIndex < 0)
                    {
                        ciphreIndex += currentLocale.Alphabet.Count;
                    }
                    resString += currentLocale.Alphabet[ciphreIndex];
                    keyWordIndex = (keyWordIndex + 1) % keyWord.Length;
                }



                return AddSeparator(resString, 5);
            }
            return "";
        }

        public override string Decrypt(string ciphertext, int shift = 0, string keyWord = "")
        {
            if (ciphertext.Length > 0 && keyWord.Length > 0)
            {
                var handledText = HandleSourceText(ciphertext);

                var resString = "";
                var keyWordIndex = 0;
                foreach (var sym in handledText)
                {
                    var currentLocale = Locales.LocalesList.Find(x => x.Alphabet.Contains(sym));
                    var ciphreIndex = (currentLocale.Alphabet.IndexOf(sym) -
                                       currentLocale.Alphabet.IndexOf(keyWord[keyWordIndex])) %
                                      currentLocale.Alphabet.Count;
                    if (ciphreIndex < 0)
                    {
                        ciphreIndex += currentLocale.Alphabet.Count;
                    }
                    resString += currentLocale.Alphabet[ciphreIndex];
                    keyWordIndex = (keyWordIndex + 1) % keyWord.Length;
                }
                return AddSeparator(resString, 5);
            }
            return "";
        }

        public override string Hack(string ciphertext)
        {
            var handledText = HandleSourceText(ciphertext);

            if (handledText.Length == 0)
            {
                return "";
            }
            var russianLocale = Locales.LocalesList.Find(x => x.Name == "Русский");
            if (handledText.Any(c => !russianLocale.Alphabet.Contains(c)))
            {
                throw new Exception("Поддерживается взлом, только русских текстов!");
            }

            var delta = GetDelta(handledText);

            var deltaTextList = new List<string>(); //получаем тексты для дешифровки цезарем
            for (var i = 0; i < delta; i++)
            {
                var curIndex = 0;
                var curString = "";
                while ((i + curIndex) < handledText.Length)
                {
                    curString += handledText[i + curIndex];
                    curIndex += delta;
                }
                deltaTextList.Add(curString);
            }

            var hackedDeltaTextList = new List<string>();

            HackedKeyWord = "";
            foreach (var deltaText in deltaTextList)
            {
                var caesarCipher = new CaesarCipher();
                hackedDeltaTextList.Add(HandleSourceText(caesarCipher.Hack(deltaText)));
                HackedKeyWord += russianLocale.Alphabet[caesarCipher.HackerShift];
            }


            var resString = "";
            for (var i = 0; i < handledText.Length / delta + 1; i++)
            {
                foreach (var s in hackedDeltaTextList)
                {
                    if (i < s.Length)
                        resString += s[i];
                }
            }



            return AddSeparator(resString, 5);
        }


        private int GetDelta(string text)
        {
            if (text.Length < 5)
                return 1;
            var countList = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                var count = 0;
                for (var j = 0; j < text.Length; j++)
                {
                    if (text[j] == text[(i + j) % text.Length])
                    {
                        count++;
                    }
                }
                countList.Add(count);
            }

            countList[0] = 0;
            var max = countList.Max();
            var mid = (double)countList.Sum() / countList.Count;
            var borderLine = (max + mid) / 2;


            var indexesRepeat = new List<int>();



            for (var i = 2; i < countList.Count - 2; i++)
            {
                if (0.8 * countList[i] > countList[i - 1] &&
                    0.8 * countList[i] > countList[i + 1] &&
                    0.8 * countList[i] > countList[i - 2] &&
                    0.8 * countList[i] > countList[i + 2])
                {
                    indexesRepeat.Add(i);
                }
            }

            var deltas = new List<int>();
            for (var i = 0; i < indexesRepeat.Count - 1; i++)
            {
                deltas.Add(indexesRepeat[i + 1] - indexesRepeat[i]);
            }


            var deltaCount = new Dictionary<int, int>();

            deltas.RemoveAll(x => x < 3);
            foreach (var delta in deltas)
            {
                if (deltaCount.ContainsKey(delta))
                {
                    deltaCount[delta]++;
                }
                else
                {
                    deltaCount.Add(delta, 0);
                }
            }
            if (deltaCount.Count == 0)
                return 1;
            var maxCount = deltaCount.Values.Max();
            var maxCountIndex = deltaCount.Values.ToList().IndexOf(maxCount);
            var resultDelta = deltaCount.Keys.ToList()[maxCountIndex];

            return resultDelta;
        }


        private string HandleSourceText(string sourceText)
        {
            var upper = sourceText.ToUpper();

            var curLocale = Locales.LocalesList.Find(x => x.Name == "Русский");

            if (curLocale.ReplacmentList.Count != 0)
            {
                upper = Replace(upper, curLocale.ReplacmentList);
            }

            var resString = "";
            foreach (var sym in upper)
            {
                if (curLocale.Alphabet.Contains(sym))
                {
                    resString += sym;
                }
            }
            return resString;
        }

    }
}
