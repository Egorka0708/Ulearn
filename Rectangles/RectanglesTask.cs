using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        //Пересекаются ли проекции двух прямоугольников по оси OX.
        public static bool AreIntersectedOfX(Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left && r1.Left <= r2.Right) || (r2.Left >= r1.Left && r2.Left <= r1.Right);
        }

        //Пересекаются ли проекции двух прямоугольников по оси OY.
        public static bool AreIntersectedOfY(Rectangle r1, Rectangle r2)
        {
            return (r1.Top >= r2.Top && r1.Top <= r2.Bottom) || (r2.Top >= r1.Top && r2.Top <= r1.Bottom);
        }

        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return AreIntersectedOfX(r1, r2) && AreIntersectedOfY(r1, r2);
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                //Находим длину площади пересечения.
                int width = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
                //Находим высоту площади пересечения.
                int height = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);
                return width * height;
            }
            else return 0;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            Random rnd = new Random();
            //Проверка совпадения прямоугольников.
            if (r1.Left == r2.Left && r1.Width == r2.Width && r1.Top == r2.Top && r1.Height == r2.Height)
                return rnd.Next(0, 1);
            else
            //Проверка находится ли первый прямоугольник внутри второго. Сначала по оси X, потом по оси Y. 
            if (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
                return 0;
            //Проверка находится ли второй прямоугольник внутри первого, аналогично по осям X и Y.
            if (r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Top >= r1.Top && r2.Bottom <= r1.Bottom)
                return 1;
            else return -1;
        }
    }
}