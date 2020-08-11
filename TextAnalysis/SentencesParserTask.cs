using System.Collections.Generic;
using System.Linq;
using System;

namespace TextAnalysis
{
    static class SentencesParserTask //Класс, содержащий методы, для решения задачи.
    {
        const string Splitters = ".!?;:()"; //Символы, разделяющие предложения.

        public static List<List<string>> ParseSentences(string text)
        {
            //Финальный список, содержащий список предложений,
            //где каждое предложение - это список из одного или более слов в нижнем регистре.
            var result = new List<List<string>>();
            //Список, хранящий предложения, разделённые одним из символов splitters в text.
            List<string> sentences = text.Split(Splitters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string sentence in sentences)
            {
                if (DivisionByWords(sentence).Count > 0)
                    result.Add(DivisionByWords(sentence));
            }
            return result;
        }

        //Метод, делящий предложение sentence на слова, которые заносятся в список слов words.
        public static List<string> DivisionByWords(string sentence)
        {
            var word = ""; //Переменная, с которой будем работать для составления слов.
            var words = new List<string>(); //Список, хранящий все слова.
            foreach (char symbol in sentence)
            {
                //Для каждого символа в предложении:
                //Если символ (symbol) существует или является апострофом,
                //то прибавляем его к слову (word) и переносим в нижний регистр,
                //иначе, если слово не пустое, то заносим слово
                //в список слов (words) и обнуляем переменную (word).
                if (char.IsLetter(symbol) || symbol == '\'')
                {
                    word += symbol.ToString();
                    word = word.ToLower();
                }
                else
                    if (word.Length > 0)
                {
                    words.Add(word);
                    word = "";
                }
            }
            if (word.Length > 0)
                words.Add(word);
            return words;
        }
    }
}