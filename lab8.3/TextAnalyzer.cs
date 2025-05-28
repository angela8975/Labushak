using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._3
{
    class TextAnalyzer
    {
        public string Text { get; set; }
        public TextAnalyzer(string text)
        {
            Text = text;
        }
        public bool ContainsWord(string word)
        {
            return Text?.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        public bool ContainsAnyWords(string[] words)
        {
            return words.Any(word => Text?.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
