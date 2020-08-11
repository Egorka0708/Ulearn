using System.Collections.Generic;
using System.Linq;

namespace yield
{
    //Основной класс программы
    public static class MovingMaxTask
    {        
        //Выполняет нахождения максимума в окне ограниченного размера
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var potentialMax = new LinkedList<Coordinates>();
            var pointsX = new Queue<double>();
            foreach (var point in data)
            {
                pointsX.Enqueue(point.X);
                if (pointsX.Count > windowWidth && potentialMax.First.Value.X == pointsX.Dequeue())
                    potentialMax.RemoveFirst();

                while (potentialMax.Count != 0 && potentialMax.Last.Value.Y < point.OriginalY)
                    potentialMax.RemoveLast();

                potentialMax.AddLast(new Coordinates(point.X, point.OriginalY));

                point.MaxY = potentialMax.First.Value.Y;
                yield return point;
            }
        }

        //Класс, содержащий координаты точки
        public class Coordinates
        {
            public double X;
            public double Y;

            //Передаёт координаты
            public Coordinates(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}