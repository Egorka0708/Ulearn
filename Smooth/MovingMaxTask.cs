using System.Collections.Generic;
using System.Linq;

namespace yield
{
    //�������� ����� ���������
    public static class MovingMaxTask
    {        
        //��������� ���������� ��������� � ���� ������������� �������
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

        //�����, ���������� ���������� �����
        public class Coordinates
        {
            public double X;
            public double Y;

            //������� ����������
            public Coordinates(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}