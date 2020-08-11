using System;
using NUnit.Framework;

namespace Manipulation
{
    public static class ManipulatorTask //Основной класс программы
    {
        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y
        /// с углом между последним суставом и горизонталью, равному angle (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double angle)
        {
            var wristX = x - Manipulator.Palm * Math.Cos(angle);
            var wristY = y + Manipulator.Palm * Math.Sin(angle);
            var distance = Math.Sqrt(wristX * wristX + wristY * wristY);
            var elbow = TriangleTask.GetABAngle(Manipulator.UpperArm, Manipulator.Forearm, distance);
            var shoulder = TriangleTask.GetABAngle(distance, Manipulator.UpperArm, Manipulator.Forearm) + Math.Atan2(wristY, wristX);
            var wrist = -angle - shoulder - elbow;
            if (elbow == double.NaN || shoulder == double.NaN || wrist == double.NaN)
                return new[] { double.NaN, double.NaN, double.NaN };
            else
                return new[] { shoulder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests //Класс, содержащий тесты для проверки
    {
        [Test]
        public void TestMoveManipulatorTo() //Проверяет вычисления
        {
            var random = new Random();
            var angle = random.Next(180) * Math.PI / 180;
            var x = random.Next(100);
            var y = random.Next(100);
            var angles = ManipulatorTask.MoveManipulatorTo(x, y, angle);
            var joints = AnglesToCoordinatesTask.GetJointPositions(angles[0], angles[1], angles[2]);
            Assert.AreEqual(x, joints[2].X, 0.00001);
            Assert.AreEqual(y, joints[2].Y, 0.00001);
        }
    }
}