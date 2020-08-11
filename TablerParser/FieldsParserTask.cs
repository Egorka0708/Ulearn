using System.Collections.Generic;
using System.Text;

namespace TableParser
{
    public class FieldsParserTask //Класс, содержащий методы для вывода таблицы парсеров
    {
        //Основной метод, разделяющий строку по пробелам, кавычкам или парсерам
        public static List<string> ParseLine(string line)
        {
            var result = new List<string>(); //Конечная переменная, в которую заносится результат
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\'' || line[i] == '\"')
                {
                    //Если встретили апостроф или кавычку, то
                    //добавляем текст, который внутри них
                    var text = TextInQuotes(line, i);
                    result.Add(text.Value);
                    i = text.GetIndexNextToToken();
                }
                else
                {
                    if (line[i] != ' ')
                    {
                        //Добавляем весь текст до первостреченного пробела,
                        //апострофа или кавычки
                        var text = ParseText(line, i);
                        result.Add(text.Value);
                        i = text.GetIndexNextToToken();
                    }
                }
            }
            return result;
        }

        //Метод, отделяющий текст с начального индекса до первостреченного
        //пробела, апострофа или кавычки
        public static Token ParseText(string line, int startIndex)
        {
            int i = startIndex + 1;
            while (i < line.Length && line[i] != ' ' && line[i] != '\"' && line[i] != '\'')
                i++;
            var result = line.Substring(startIndex, i - startIndex);
            int resultLength = i - startIndex - 1;
            return new Token(result, startIndex, resultLength);
        }

        //Метод, возвращающий текст внутри апострофов или кавычек
        public static Token TextInQuotes(string line, int startIndex)
        {
            int i;
            var result = new StringBuilder();
            for (i = startIndex + 1; i < line.Length && line[i] != line[startIndex]; i++)
            {
                if (line[i] == '\\')
                {
                    i++;
                }
                result.Append(line[i]);
            }
            int resultLength = i - startIndex;
            return new Token(result.ToString(), startIndex, resultLength);
        }
    }
}