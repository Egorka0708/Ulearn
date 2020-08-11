namespace Mazes
{
    public static class SnakeMazeTask
    {
        //Метод, перемещающий робота змейкой, пока тот не финиширует.
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished) //Пока робот не финиширует, он выполняет данный блок инструкций.
            {
                MoveRight(robot, width);
                MoveDown(robot);
                MoveLeft(robot, width); 
                MoveDown(robot);
            }
        }

        //Метод, передвигающий робота до упора вправо.
        public static void MoveRight(Robot robot, int width)
        {
            for (int i = 1; i < width - 2; i++) //width - 2 - это крайняя правая координата, в которой может оказаться робот.
                robot.MoveTo(Direction.Right);
        }

        //Метод, передвигающий робота до упора влево.
        public static void MoveLeft(Robot robot, int width)
        {
            for (int i = width - 2; i > 1; i--)
                robot.MoveTo(Direction.Left);
        }

        //Метод, передвигающий робота на 2 клетки вниз.
        public static void MoveDown(Robot robot)
        {
            if (!robot.Finished) //Эта проверка нужна, так как конец лабиринта наступает при сдвижении робота влево, а не вниз.
            {
                robot.MoveTo(Direction.Down);
                robot.MoveTo(Direction.Down);
            }
        }
	}
}