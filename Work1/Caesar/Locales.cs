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
            LocalesList = new List<Locale>() { GenerateRussian(), GenerateEnglish() };
        }
        public static List<Locale> LocalesList { get; }

        private static Locale GenerateRussian()
        {
            var loc = new Locale();

            loc.Name = "Русский";

            for (var i = 'А'; i <= 'Я'; i++)
            {
                loc.Alphabet.Add(i);
            }

            loc.ReplacmentList.Add(new Tuple<char, char>('Ё', 'Е'));

            loc.CharFrequency = new Dictionary<char, double>()
            {
                {'А', 0.062},
                {'Б', 0.014},
                {'В', 0.038},
                {'Г', 0.013},
                {'Д', 0.025},
                {'Е', 0.072},
                {'Ж', 0.007},
                {'З', 0.016},
                {'И', 0.062},
                {'Й', 0.010},
                {'К', 0.028},
                {'Л', 0.035},
                {'М', 0.026},
                {'Н', 0.053},
                {'О', 0.090},
                {'П', 0.023},
                {'Р', 0.040},
                {'С', 0.045},
                {'Т', 0.053},
                {'У', 0.021},
                {'Ф', 0.002},
                {'Х', 0.009},
                {'Ц', 0.003},
                {'Ч', 0.012},
                {'Ш', 0.006},
                {'Щ', 0.003},
                {'Ъ', 0.014},
                {'Ы', 0.016},
                {'Ь', 0.014},
                {'Э', 0.003},
                {'Ю', 0.006},
                {'Я', 0.018}
            };

            return loc;
        }

        private static Locale GenerateEnglish()
        {
            var loc = new Locale();
            for (var i = 'A'; i <= 'Z'; i++)
            {
                loc.Alphabet.Add(i);
            }
            loc.Name = "Английский";
            return loc;
        }
    }
}
