using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	internal static class MedianFilterTask //Класс, содержащий метод для удаления шума на изображени
	{
        /* Метод, заменяющий каждый пиксель изображение
         * на медианное значение всех соседних пикселей  */
        public static double[,] MedianFilter(double[,] original)
        {
            var lengthX = original.GetLength(0); //Длина оси OX
            var lengthY = original.GetLength(1); //Длина оси OY
            for (var x = 0; x < lengthX; x++)
                for (var y = 0; y < lengthY; y++)
                {
                    original[x, y] = GetPixelValue(x, y, original);
                }
            return original;
        }

        //Метод, проверяющий на существование пикселя
        public static bool PixelExist(int x, int y, int lengthY, int lengthX)
        {
            return (x > -1 && y > -1) && (x < lengthY && y < lengthX);
        }

        //Метод, возвращающий медианное значение списка
        public static double GetMedian(List<double> pixels)
        {
            if (pixels.Count % 2 == 0)
                return (pixels[pixels.Count / 2 - 1] + pixels[pixels.Count / 2]) / 2;
            else
                return pixels[pixels.Count / 2];
        }

        /* Метод, находящий все пиксели вокруг данного,
         * сортирующий их по велечине и возвращающий
         * медианное значение
        */
        public static double GetPixelValue(int x, int y, double[,] original)
        {
            var pixelsAroundThePoint = new List<double>();
            var lengthX = original.GetLength(0); //Длина оси OX
            var lengthY = original.GetLength(1); //Длина оси OY
            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                {
                    if (PixelExist(x + i, y + j, lengthX, lengthY))
                        pixelsAroundThePoint.Add(original[x + i, y + j]);
                }
            pixelsAroundThePoint.Sort();
            return GetMedian(pixelsAroundThePoint);
        }
	}
}