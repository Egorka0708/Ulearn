using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace yield
{
    //�������� ����� ���������
    public static class MovingAverageTask
    {
        //��������� ����������� ������� �� ����������� ��������
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var sum = 0.0; //������� �������� ���� ���������� ���������
            var currentIndex = 1; //������ �������� ��������
            var queue = new Queue<double>(); //������� ��� �������� ���������� ���������

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