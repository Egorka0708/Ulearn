using System.Collections.Generic;
using System.Linq;
using System;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask //Класс, содержащий метод для решения задачи.
    {
        //Метод, находящий все биграммы и триграммы,
        //и выводящий их по частоте встречаемости, а также самые лексикографически меньшие.
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var pairs = new Dictionary<string, Dictionary<string, int>>(); 
            foreach (var sentence in text) 
            {
                for (var i = 0; i < sentence.Count - 1; i++)
                {
                    if (!pairs.ContainsKey(sentence[i]))
                    {
                        //Если такой пары ещё не существует, то инициалиризуем её.
                        pairs[sentence[i]] = new Dictionary<string, int> { { sentence[i + 1], 1 } };
                    }
                    else
                    {
                        if (pairs[sentence[i]].ContainsKey(sentence[i + 1]))
                            //Если пара уже существует, то прибавляем к частоте встречаемости 1.
                            pairs[sentence[i]][sentence[i + 1]]++;
                        else //иначе = 1, т.к. встретилась в первый раз.
                            pairs[sentence[i]][sentence[i + 1]] = 1; 
                    }
                }
            }
            var result = new Dictionary<string, string>(pairs.Count);
            foreach (var e in pairs)
                //Сортируем в порядке частоты встречаемости в тексте (в порядке убывания ключа), а также по лексикографическим размерам.
                result.Add(e.Key, e.Value.OrderByDescending(x => x.Value).ThenBy(s => s.Key, StringComparer.Ordinal).First().Key);
            return result;
        }
   }
}