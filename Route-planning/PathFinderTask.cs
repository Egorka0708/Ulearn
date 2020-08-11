using System;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask //Основной класс программы
    {
        //Метод, находящий порядок номеров чекпоинтов для самого короткого пути
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var shortestDistance = double.PositiveInfinity;
            var checkpointCount = checkpoints.Length;
            var shortestWay = new int[checkpointCount];
            var way = new int[checkpointCount];
            GetShortestWay(checkpoints, shortestWay, way, 1, shortestDistance);
            return shortestWay;
        }

        //Метод, находящий самый короткий путь, проходящий через каждую из данных точек
        private static double GetShortestWay(Point[] checkpoints, int[] shortestWay, int[] way, int position, double shortestDistance)
        {
            var distance = checkpoints.GetPathLength(way);
            var checkpointCount = checkpoints.Length;
            if (position == way.Length && distance < shortestDistance)
            {
                shortestDistance = distance;
                Array.Copy(way, shortestWay, checkpointCount);
                return shortestDistance;
            }
            for (var i = 0; i < checkpointCount; i++)
            {
                var index = Array.IndexOf(way, i, 0, position);

                if (index == -1)
                {
                    way[position] = i;
                    shortestDistance = GetShortestWay(checkpoints, shortestWay, way,
                        position + 1, shortestDistance);
                }
            }
            return shortestDistance;
        }
    }
}