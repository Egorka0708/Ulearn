using System;

namespace Recognizer
{
    //Класс, содержащий методы для выделения границ объектов через фильтр Собеля
    internal static class SobelFilterTask 
    {
        //Метод, применяющий фильтр Собеля к изображению
        public static double[,] SobelFilter(double[,] original, double[,] sx)
        {
            var lengthX = original.GetLength(0); //Длина оси OX
            var lengthY = original.GetLength(1); //Длина оси OY
            var sy = TransportMatrix(sx); //Транспортируем матрицу
            var correctonX = sx.GetLength(0) / 2; //поправка на смещение
            var correctionY = sx.GetLength(1) / 2;
            var filteredPixels = new double[lengthX, lengthY];
            for (var x = correctonX; x < lengthX - correctonX; x++)
            {
                for (var y = correctionY; y < lengthY - correctionY; y++)
                {
                    //Сворачиваем матрицу
                    var gx = CollapsingMatrix(original, sx, x, y, correctonX);
                    var gy = CollapsingMatrix(original, sy, x, y, correctionY);
                    filteredPixels[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }
            return filteredPixels;
        }

        //Метод, транспортирующий матрицу
        public static double[,] TransportMatrix(double[,] matrix)
        {
            var lengthX = matrix.GetLength(0);
            var lengthY = matrix.GetLength(1);
            var result = new double[lengthX, lengthY];
            for (var x = 0; x < lengthX; x++)
                for (var y = 0; y < lengthY; y++)
                    result[x, y] = matrix[y, x];
            return result;
        }

        //Метод, сворачивающий матрицу по фильтру Собеля
        public static double CollapsingMatrix(double[,] original, double[,] matrix, int x, int y, int correction)
        {
            var lengthX = matrix.GetLength(0);
            var lengthY = matrix.GetLength(1);
            var result = 0.0;
            for (var i = 0; i < lengthX; i++)
                for (var j = 0; j < lengthY; j++)
                    result += matrix[i, j] * original[x + i - correction, y + j - correction];
            return result;
        }
    }
}
