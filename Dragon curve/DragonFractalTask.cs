using System.Drawing;
using System;
namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            double x = 1;  //x и y - координаты первой точки.
            double y = 0; 
            double nextX; //координаты последующих точек.
            double nextY;
            var random = new Random(seed);
            //В данном цикле рисуются фракталы.
            for (int i = 0; i < iterationsCount; i++)
            {
                int randomNumber = random.Next(0, 2); //Генерируем случайное число (0 или 1).
                if (randomNumber == 0)
                {
                    //Преобразование 1: поворачиваем на 45 градусов и сжимаем в sqrt(2) раз.
                    nextX = (x * Math.Cos(Math.PI * 45 / 180) - y * Math.Sin(Math.PI * 45 / 180)) / Math.Sqrt(2);
                    nextY = (x * Math.Sin(Math.PI * 45 / 180) + y * Math.Cos(Math.PI * 45 / 180)) / Math.Sqrt(2);
                    x = nextX;
                    y = nextY;
                }
                else
                {
                    //Преобразование 2: поворачиваем на 135 градусов, сжимаем в sqrt(2) раз и сдвигаем по оси 0X на 1.
                    nextX = ((x * Math.Cos(Math.PI * 135 / 180) - y * Math.Sin(Math.PI * 135 / 180)) / Math.Sqrt(2)) + 1;
                    nextY = (x * Math.Sin(Math.PI * 135 / 180) + y * Math.Cos(Math.PI * 135 / 180)) / Math.Sqrt(2);
                    x = nextX;
                    y = nextY;
                }
                pixels.SetPixel(x, y); //Рисуем точку.
            }
		}
	}
}