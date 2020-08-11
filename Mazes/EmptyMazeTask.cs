namespace Mazes
{
    public static class EmptyMazeTask
    {
        //Метод, перемещающий Робота в точку width - 2, height - 2 (Так просят в задании).
        public static void MoveOut(Robot robot, int width, int height)
        {
            int stepsRight = width - 2;
            int stepsDown = height - 2;
            MoveRight(robot, stepsRight);
            MoveDown(robot, stepsDown);
        }

        //Перемещает Робота по горизонтали вправо на координату width.
        public static void MoveRight(Robot robot, int width)
        {
            for (int i = 1; i < width; i++)
                robot.MoveTo(Direction.Right);
        }

        //Перемещает Робота по вертикали вниз на координату height.
        public static void MoveDown(Robot robot, int height)
        {
            for (int i = 1; i < height; i++)
                robot.MoveTo(Direction.Down);
        }
    }
}