using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Manipulation
{
    public static class VisualizerTask //Класс, визиализирующий манипулятор
    {
        public static double X = 220;
        public static double Y = -100;
        public static double Alpha = 0.05;
        public static double Wrist = 2 * Math.PI / 3;
        public static double Elbow = 3 * Math.PI / 4;
        public static double Shoulder = Math.PI / 2;

        public static Brush UnreachableAreaBrush = new SolidBrush(Color.FromArgb(255, 255, 230, 230));
        public static Brush ReachableAreaBrush = new SolidBrush(Color.FromArgb(255, 230, 255, 230));
        public static Pen ManipulatorPen = new Pen(Color.Black, 3);
        public static Brush JointBrush = Brushes.Gray;

        //Метод, меняющий изображение в зависимости от нажатия клавиш QAWS
        public static void KeyDown(Form form, KeyEventArgs key)
        {
            var delta = 1.0e-12;
            if (key.KeyCode == Keys.Q)
                Shoulder += delta;
            else if (key.KeyCode == Keys.A)
                Shoulder -= delta;
            else if (key.KeyCode == Keys.W)
                Elbow += delta;
            else if (key.KeyCode == Keys.S)
                Elbow -= delta;
            Wrist = -Alpha - Shoulder - Elbow;
            form.Invalidate();
        }

        //Метод, меняющий X и Y, пересчитвая их координаты в логические
        public static void MouseMove(Form form, MouseEventArgs e)
        {
            var newCoordinate = ConvertWindowToMath(new PointF(e.X, e.Y), GetShoulderPos(form));
            X = newCoordinate.X;
            Y = newCoordinate.Y;
            UpdateManipulator();
            form.Invalidate();
        }

        //В зависимости от прокрутки колёсика мыши меняет Alpha
        public static void MouseWheel(Form form, MouseEventArgs e)
        {
            var delta = 1.0e-12;
            if (e.Delta > 0)
                Alpha += delta;
            else
                Alpha -= delta;
            UpdateManipulator();
            form.Invalidate();
        }

        //Обновляет углы
        public static void UpdateManipulator()
        {
            var newCorners = ManipulatorTask.MoveManipulatorTo(X, Y, Alpha);
            if (!double.IsNaN(newCorners[0]))
            {
                Shoulder = newCorners[0];
                Elbow = newCorners[0];
                Wrist = newCorners[0];
            }
        }

        //Метод, рисующий сегменты манипулятора
        public static void DrawManipulator(Graphics graphics, PointF shoulderPos)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(Shoulder, Elbow, Wrist);
            graphics.DrawString($"X={X:0}, Y={Y:0}, Alpha={Alpha:0.00}", new Font(SystemFonts.DefaultFont.FontFamily, 12), Brushes.DarkRed, 10, 10);
            DrawReachableZone(graphics, ReachableAreaBrush, UnreachableAreaBrush, shoulderPos, joints);
            for (var i = 0; i < 3; i++)
                joints[i] = ConvertMathToWindow(joints[i], shoulderPos);
            for (var i = 0; i < 3; i++)
            {
                graphics.FillEllipse(JointBrush, new RectangleF(joints[i], new SizeF(1, 1)));
                if (i == 0)
                    graphics.DrawLine(ManipulatorPen, shoulderPos.X, shoulderPos.Y, joints[i].X, joints[i].Y);
                else
                    graphics.DrawLine(ManipulatorPen, joints[i - 1].X, joints[i - 1].Y, joints[i].X, joints[i].Y);
            }
        }

        //Рисует достижимую зону
        private static void DrawReachableZone(Graphics graphics, Brush reachableBrush, Brush unreachableBrush, PointF shoulderPos, PointF[] joints)
        {
            var rmin = Math.Abs(Manipulator.UpperArm - Manipulator.Forearm);
            var rmax = Manipulator.UpperArm + Manipulator.Forearm;
            var mathCenter = new PointF(joints[2].X - joints[1].X, joints[2].Y - joints[1].Y);
            var windowCenter = ConvertMathToWindow(mathCenter, shoulderPos);
            graphics.FillEllipse(reachableBrush, windowCenter.X - rmax, windowCenter.Y - rmax, 2 * rmax, 2 * rmax);
            graphics.FillEllipse(unreachableBrush, windowCenter.X - rmin, windowCenter.Y - rmin, 2 * rmin, 2 * rmin);
        }

        //Находит положение плеча
        public static PointF GetShoulderPos(Form form)
        {
            return new PointF(form.ClientSize.Width / 2f, form.ClientSize.Height / 2f);
        }

        //Меняет тип из логического в оконное
        public static PointF ConvertMathToWindow(PointF mathPoint, PointF shoulderPos)
        {
            return new PointF(mathPoint.X + shoulderPos.X, shoulderPos.Y - mathPoint.Y);
        }

        //Меняет тип из оконного в логическое
        public static PointF ConvertWindowToMath(PointF windowPoint, PointF shoulderPos)
        {
            return new PointF(windowPoint.X - shoulderPos.X, shoulderPos.Y - windowPoint.Y);
        }
    }
}