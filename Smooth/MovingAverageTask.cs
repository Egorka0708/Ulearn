using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace yield
{
    //Основной класс программы
    public static class MovingAverageTask
    {
        //Выполняет сглаживание графика по скользящему среднему
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var sum = 0.0; //Среднее значение всех предыдущих элементов
            var currentIndex = 1; //Индекс текущего элемента
            var queue = new Queue<double>(); //Очередь для хранения предыдущих элементов

            foreach (var point in data)
            {
                if (currentIndex > windowWidth)
                {
                    sum += point.OriginalY - queue.Dequeue();
                    point.AvgSmoothedY = sum / windowWidth;
                }
                else
                {
                    sum += point.OriginalY;
                    point.AvgSmoothedY = sum / currentIndex;
                }

                yield return point;
                queue.Enqueue(point.OriginalY);
                currentIndex++;
            }
        }
    }
}