using System.Collections.Generic;

namespace Recognizer
{
    //Класс, содержащий метод, для перевода изображения в чёрно-белый цвет
    public static class ThresholdFilterTask 
    {
        //Метод, возвращающий изображение в чёрно-белом цвете.
        //Смена цвета пикселя зависит от порогового значения
        public static double[,] ThresholdFilter(double[,] original, double threshold)
        {
            var lengthX = original.GetLength(0); //Длина оси OX
            var lengthY = original.GetLength(1); //Длина оси OY
            //Пороговое значение
            var thresholdValue = GetThresholdValue(original, threshold, lengthX, lengthY); 
            var filteredPixels = new double[lengthX, lengthY];
            for (var x = 0; x < lengthX; x++)
                for (var y = 0; y < lengthY; y++)
                    filteredPixels[x, y] = (original[x, y] >= thresholdValue) ? 1.0 : 0.0;
            return filteredPixels;
        }

        //Метод, расчитывающий порогове значение в зависимости от значения порога
        public static double GetThresholdValue(double[,] original, double threshold, int height, int width)
        {
            var numberOfPixels = width * height; //общеее кол-во пикселей
            var pixels = new List<double>(numberOfPixels);
            var pixelsToChange = (int)(numberOfPixels * threshold);
            for (var x = 0; x < height; x++)
                for (var y = 0; y < width; y++)
                    pixels.Add(original[x, y]);
            pixels.Sort();
            if (pixelsToChange == numberOfPixels)
                return double.MinValue;
            else if (pixelsToChange == 0)
                return double.MaxValue;
            else return pixels[numberOfPixels - pixelsToChange];
        }
    }
}