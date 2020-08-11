using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    //Основной класс программы
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var result = new PointF[3];
            var firstPointX = Manipulator.UpperArm * (float)Math.Cos(shoulder);
            var firstPointY = (float)Manipulator.UpperArm * (float)Math.Sin(shoulder);
            result[0] = new PointF(firstPointX, firstPointY);

            var alpha = elbow - Math.PI / 2 - Math.PI / 2 + shoulder;
            var secondPointX = firstPointX + Manipulator.Forearm * (float)Math.Cos(alpha);
            var secondPointY = firstPointY + Manipulator.Forearm * (float)Math.Sin(alpha);
            result[1] = new PointF(secondPointX, secondPointY);

            var beta = wrist - Math.PI / 2 + alpha;
            var thirdPointX = secondPointX + Manipulator.Palm * (float)Math.Sin(beta);
            var thirdPointY = secondPointY - Manipulator.Palm * (float)Math.Cos(beta);
            result[2] = new PointF(thirdPointX, thirdPointY);

            return result;
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests //Содержит тесты для проверки
    {
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm, Manipulator.Forearm, Manipulator.UpperArm, 0, Manipulator.UpperArm)]
        [TestCase(0, Math.PI, Math.PI, Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm, 0, Manipulator.UpperArm + Manipulator.Forearm, 0, Manipulator.UpperArm, 0)]
        [TestCase(Math.PI / 2, Math.PI, Math.PI, 0, Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm, 0, Manipulator.UpperArm + Manipulator.Forearm, 0, Manipulator.UpperArm)]
        [TestCase(Math.PI, Math.PI, Math.PI, -Manipulator.Palm - Manipulator.Forearm - Manipulator.UpperArm, 0, -Manipulator.Forearm - Manipulator.UpperArm, 0, -Manipulator.UpperArm, 0)]
        [TestCase(0, 0, 0, Manipulator.UpperArm - Manipulator.Forearm + Manipulator.Palm, 0, Manipulator.UpperArm - Manipulator.Forearm, 0, Manipulator.UpperArm, 0)]
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI / 2, Manipulator.Forearm, Manipulator.UpperArm - Manipulator.Palm, Manipulator.Forearm, Manipulator.UpperArm, 0, Manipulator.UpperArm)]
        [TestCase(-Math.PI / 2, Math.PI, Math.PI, 0, -Manipulator.UpperArm - Manipulator.Forearm - Manipulator.Palm, 0, -Manipulator.UpperArm - Manipulator.Forearm, 0, -Manipulator.UpperArm)]

        //Проверят правильность вычислений
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY, double wristX, double wristY, double elbowX, double elbowY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            var delta = 1e-5;
            Assert.AreEqual(palmEndX, joints[2].X, delta, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, delta, "palm endY");
            Assert.AreEqual(wristX, joints[1].X, delta, "wrist X");
            Assert.AreEqual(wristY, joints[1].Y, delta, "wrist Y");
            Assert.AreEqual(elbowX, joints[0].X, delta, "elbow X");
            Assert.AreEqual(elbowY, joints[0].Y, delta, "elbow Y");

            Assert.AreEqual(DistanceBetweenPoints(palmEndX, palmEndY, wristX, wristY), Manipulator.Palm);
            Assert.AreEqual(DistanceBetweenPoints(elbowX, elbowY, wristX, wristY), Manipulator.Forearm);
            Assert.AreEqual(DistanceBetweenPoints(elbowX, elbowY, 0, 0), Manipulator.UpperArm);

            //Находит расстояние между двумя точками
            double DistanceBetweenPoints(double x, double y, double x1, double y1)
            {
                return Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
            }
        }
    }
}