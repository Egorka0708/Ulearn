using System.Collections.Generic;

namespace yield
{
    //Основной класс программы
    public static class ExpSmoothingTask
    {
        //Выполняет экспоненциальное сглаживание графика
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var currentIndex = 1; //Счётчик текущего индекса элемента
            var previousPointY = 1.0; //Предыдущее значение Y
            foreach (var point in data)
            {
                if (currentIndex == 1)
                    point.ExpSmoothedY = point.OriginalY;
                else
                    point.ExpSmoothedY = alpha * point.OriginalY + (1 - alpha) * previousPointY;
                yield return point;
                previousPointY = point.ExpSmoothedY;
                currentIndex++;
            }
        }
    }
}