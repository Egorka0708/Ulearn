namespace ReadOnlyVectorTask
{
    public class ReadOnlyVector //Класс, содержащий readonly вектор
    {
        public readonly double X; //координата Х вектора
        public readonly double Y; //координата Y вектора

        public ReadOnlyVector(double x, double y) //Конструктор
        {
            X = x;
            Y = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector vector) //Сумма векторов
        {
            return new ReadOnlyVector(vector.X + X, vector.Y + Y);
        }

        public ReadOnlyVector WithX(double x) //Создаёт такой же вектор, но с другим X
        {
            return new ReadOnlyVector(x, Y);
        }

        public ReadOnlyVector WithY(double y) //Создаёт такой же вектор, но с другим Y
        {
            return new ReadOnlyVector(X, y);
        }
    }
}