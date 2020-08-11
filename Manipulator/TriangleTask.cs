using System;
using NUnit.Framework;

namespace Manipulation
{
    public class TriangleTask //Класс, находящий угол в треугольнике
    {
        /// <summary>
        /// Возвращает угол (в радианах) между сторонами a и b в треугольнике со сторонами a, b, c 
        /// </summary>
        public static double GetABAngle(double a, double b, double c)
        {
            var corner = 0.0;
            if (a + b >= c && a + c >= b && b + c >= a)
                corner = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            else
                corner = double.NaN;
            return corner;
        }
    }

    [TestFixture]
    public class TriangleTask_Tests //Класс, содержащий тесты для проверки
    {
        [TestCase(3, 4, 5, Math.PI / 2)]
        [TestCase(1, 1, 1, Math.PI / 3)]
        [TestCase(15, 1, 1, double.NaN)]
        [TestCase(-1, 5, 0, double.NaN)]

        //Метод, проверяющий результат на ошибку
        public void TestGetABAngle(double a, double b, double c, double expectedAngle)
        {
            Assert.AreEqual(expectedAngle, TriangleTask.GetABAngle(a, b, c), 1e-5);
        }
    }
}