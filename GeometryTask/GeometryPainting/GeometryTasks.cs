using System;

namespace GeometryTasks
{
    public class Vector //Содержит проекции вектора на оси
    {
        public double X;
        public double Y;

        //Вычисляет длину данного вектора
        public double GetLength() 
        {
            return Geometry.GetLength(this);
        }

        //Вычисляет сумму вектора с данным
        public Vector Add(Vector vector) 
        {
            return Geometry.Add(this, vector);
        }

        //Проверяет принадлежность точки, заданной данным вектором, с отрезком
        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    } 

    public class Segment //Содержит начало и конец отрезка
    {
        public Vector Begin;
        public Vector End;

        //Вычисляет длину данного отрезка
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        //Проверяет принадлежность точки, заданной вектором, с данным отрезком
        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }

    public class Geometry //Здесь проводятся вычисления
    {
        //Вычисляет длину вектора
        public static double GetLength(Vector vector) 
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        //Вычисляет сумму векторов
        public static Vector Add(Vector vector1, Vector vector2) 
        {
            var result = new Vector();
            result.X = vector1.X + vector2.X;
            result.Y = vector1.Y + vector2.Y;
            return result;
        }

        //Вычисляет длину сегмента
        public static double GetLength(Segment segment) 
        {
            var vector = new Vector { X = segment.End.X - segment.Begin.X, Y = segment.End.Y - segment.Begin.Y };
            return GetLength(vector);
        }

        //Вычисляет расстояние между точками, заданными векторами
        public static double GetDistance(Vector a, Vector b) 
        {
            return GetLength(new Vector { X = a.X - b.X, Y = a.Y - b.Y } );
        }

        //Определяет принадлежность точки, заданную вектором, к сегменту
        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            return Math.Abs(GetDistance(segment.Begin, vector) + GetDistance(segment.End, vector) - GetDistance(segment.Begin, segment.End)) < 1e-9;
        }
    }
}