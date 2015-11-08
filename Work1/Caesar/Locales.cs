using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Work1.Caesar
{
    public static class Locales
    {
        static Locales()
        {
            LocalesDictionary = new Dictionary<int, Locale> { { 0, GenerateRussian() }, { 1, GenerateEnglish() } };
        }
        public static Dictionary<int, Locale> LocalesDictionary { get; }

        private static Locale GenerateRussian()
        {
            var loc = new Locale();

            loc.Name = "Русский";

            for (var i = 'А'; i <= 'Е'; i++)
            {
                loc.Alphabet.Add(i);
            }
            loc.Alphabet.Add('Ё');
            for (var i = 'Ж'; i <= 'Я'; i++)
            {
                loc.Alphabet.Add(i);
            }

            for (var i = 'А'; i <= 'Я'; i++)
            {
                loc.CipherAlphabet.Add(i);
            }

            loc.ReplacmentList.Add(new Tuple<char, char>('Ё', 'Е'));
            return loc;
        }

        private static Locale GenerateEnglish()
        {
            var loc = new Locale();
            for (var i = 'A'; i <= 'Z'; i++)
            {
                loc.Alphabet.Add(i);
            }
            loc.CipherAlphabet = new List<char>(loc.Alphabet);
            loc.Name = "Английский";
            return loc;
        }
    }
}
