namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                if (height > width)
                {
                    int diagonalNumber = (height - 2) / (width - 2);
                    DiagonalMove(robot, diagonalNumber, Direction.Down, Direction.Right);
                }
                else
                {
                    int diagonalNumber = (width - 2) / (height - 2);
                    DiagonalMove(robot, diagonalNumber, Direction.Right, Direction.Down);
                }
            }
        }

        public static void DiagonalMove(Robot robot, int diagonalNumber, Direction dir1, Direction dir2)
        {
            for (int i = 0; i < diagonalNumber; i++)
                robot.MoveTo(dir1);
            if (!robot.Finished)
                robot.MoveTo(dir2);
        }
	}
}