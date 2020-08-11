namespace Recognizer
{
    //Класс, содержащий метод для перевода цветного изображения в оттенки серого
    public static class GrayscaleTask
    {
        //Метод, переводящий цвет изображения в оттенки серого
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var lengthX = original.GetLength(0); //Длина изображения по оси OX
            var lengthY = original.GetLength(1); //Длина изображения по оси OY
            var grayscale = new double[lengthX, lengthY];
            for (var x = 0; x < lengthX; x++)
            {
                for (var y = 0; y < lengthY; y++)
                {
                    //Переводим цвета в оттенки серого по формуле:
                    //Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
                    Pixel pixel = original[x, y];
                    grayscale[x, y] = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255;
                }
            }
            return grayscale;
        }
    }
}