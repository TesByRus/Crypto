using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Work1.Caesar
{
    public class Locale
    {
        public Locale()
        {
            Alphabet = new List<char>();
            CipherAlphabet = new List<char>();
            ReplacmentList = new List<Tuple<char, char>>();
        }
        public string Name { get; set; }
        public List<char> Alphabet { get; set; }
        public List<char> CipherAlphabet { get; set; }
        public List<Tuple<char, char>> ReplacmentList { get; set; }
    }
}
