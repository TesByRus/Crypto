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
            if (text.Length > 0 && keyWord.Length > 0)
            {

                var handledText = HandleSourceText(text);

                if (GetTextLocale(handledText) != GetTextLocale(keyWord))
                {
                    throw new Exception("Язык исходного текста и ключевого слова, должен быть одинаковый!");
                }

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

                if (GetTextLocale(handledText) != GetTextLocale(keyWord))
                {
                    throw new Exception("Язык исходного текста и ключевого слова, должен быть одинаковый!");
                }

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
            foreach (var deltaText in deltaTextList)
            {
                var caesarCipher = new CaesarCipher();
                hackedDeltaTextList.Add(caesarCipher.Hack(deltaText));
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


            var indexesRepeat = new List<int>();
            for (var i = 0; i < countList.Count; i++)
            {
                if (countList[i] > 0.9 * max)
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
            var maxCount = deltaCount.Values.Max();
            var maxCountIndex = deltaCount.Values.ToList().IndexOf(maxCount);
            var resultDelta = deltaCount.Keys.ToList()[maxCountIndex];
            return resultDelta;
        }


        private string HandleSourceText(string sourceText)
        {
            var upper = sourceText.ToUpper();

            Locale curLocale = null;
            foreach (var sym in upper)
            {
                foreach (var locale in Locales.LocalesList)
                {
                    if (locale.Alphabet.Contains(sym))
                    {
                        curLocale = locale;
                        break;
                    }

                }
                if (curLocale != null)
                {
                    break;
                }
            }

            if (curLocale == null)
            {
                return "";
            }
            if (curLocale.ReplacmentList.Count != 0)
            {
                upper = Replace(upper, curLocale.ReplacmentList);
            }

            string resString = "";
            foreach (var sym in upper)
            {
                if (curLocale.Alphabet.Contains(sym))
                {
                    resString += sym;
                }
            }
            return resString;
        }

        private Locale GetTextLocale(string text)
        {
            Locale curLocale = null;
            foreach (var sym in text)
            {
                foreach (var locale in Locales.LocalesList)
                {
                    if (locale.Alphabet.Contains(sym))
                    {
                        curLocale = locale;
                        break;
                    }

                }
                if (curLocale != null)
                {
                    break;
                }
            }
            return curLocale;
        }
    }
}
