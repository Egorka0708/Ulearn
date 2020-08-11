using System.Collections.Generic;

namespace yield
{
    //�������� ����� ���������
    public static class ExpSmoothingTask
    {
        //��������� ���������������� ����������� �������
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var currentIndex = 1; //������� �������� ������� ��������
            var previousPointY = 1.0; //���������� �������� Y
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