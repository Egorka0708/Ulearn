using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public class ParsingTask
	{
		/// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
		/// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
		/// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
		public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
		{
            return lines.Select(line => line.Split(';'))
                .Skip(1)
                .Where(line => line.Count() >= 3)
                .Where(line => int.TryParse(line[0], out int result) &&
                (line[1].Equals(SlideType.Exercise.ToString().ToLower()) ||
                line[1].Equals(SlideType.Quiz.ToString().ToLower()) ||
                line[1].Equals(SlideType.Theory.ToString().ToLower())))
                .ToDictionary(line => int.Parse(line[0]), line =>
                {
                    if (line[1] == "theory")
                        return new SlideRecord(int.Parse(line[0]), SlideType.Theory, line[2]);
                    if (line[1] == "quiz")
                        return new SlideRecord(int.Parse(line[0]), SlideType.Quiz, line[2]);
                    if (line[1] == "exercise")
                        return new SlideRecord(int.Parse(line[0]), SlideType.Exercise, line[2]);
                    return null;
                });
        }

		/// <param name="lines">все строки файла, которые нужно распарсить. Первая строка — заголовочная.</param>
		/// <param name="slides">Словарь информации о слайдах по идентификатору слайда. 
		/// Такой словарь можно получить методом ParseSlideRecords</param>
		/// <returns>Список информации о посещениях</returns>
		/// <exception cref="FormatException">Если среди строк есть некорректные</exception>
		public static IEnumerable<VisitRecord> ParseVisitRecords(
			IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
		{
			lines = lines.Skip(1);
            return lines.Select(line => line.Split(';'))
                .Select(line =>
                {
                    try
                    {
                        List<int> dataList = line[2].Split('-').Select(x => int.Parse(x)).ToList();
                        dataList.AddRange(line[3].Split(':').Select(x => int.Parse(x)).ToList());
                        return new VisitRecord(int.Parse(line[0]), int.Parse(line[1]),
                                               new DateTime(dataList[0], dataList[1], dataList[2], dataList[3],
                                                            dataList[4], dataList[5]),slides
                                               .Where(slide => slide.Key ==
                                        int.Parse(line[1])).First().Value.SlideType);
                    }
                    catch
                    {
                        throw new FormatException();
                    }
                });
		}
	}
}