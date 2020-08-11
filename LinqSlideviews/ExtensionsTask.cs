using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public static class ExtensionsTask
    {
        /// <summary>
        /// Медиана списка из нечетного количества элементов — это серединный элемент списка после сортировки.
        /// Медиана списка из четного количества элементов — это среднее арифметическое 
        /// двух серединных элементов списка после сортировки.
        /// </summary>
        /// <exception cref="InvalidOperationException">Если последовательность не содержит элементов</exception>
        public static double Median(this IEnumerable<double> items)
        {
            var resultList = items.ToList();
            resultList.Sort();
            if (resultList.Count == 0)
                throw new InvalidOperationException();

            return resultList.Count % 2 == 0 ? (resultList[resultList.Count / 2] + resultList[resultList.Count / 2 - 1]) / 2 : resultList[resultList.Count / 2];
        }

        /// <returns>
        /// Возвращает последовательность, состоящую из пар соседних элементов.
        /// Например, по последовательности {1,2,3} метод должен вернуть две пары: (1,2) и (2,3).
        /// </returns>
        public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
        {
            var enumerator = items.GetEnumerator();
            enumerator.MoveNext();
            var previousItem = enumerator.Current;

            while (enumerator.MoveNext())
            {
                yield return Tuple.Create(previousItem, enumerator.Current);
                previousItem = enumerator.Current;
            }
        }
    }
}