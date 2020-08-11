using System.Collections.Generic;

namespace Clones
{
    //Основной класс программы
    public class CloneVersionSystem : ICloneVersionSystem
    {
        //Лист, содержащий всех клонов
        private List<Clone> clones;

        //Конструктор для создания первоначального клона
        public CloneVersionSystem()
        {
            clones = new List<Clone> { new Clone() };
        }

        //Выполняет данную комманду для данного клона
        public string Execute(string query)
        {
            var instructions = query.Split(' ');
            var command = instructions[0];
            var clone = clones[int.Parse(instructions[1]) - 1];

            switch (command)
            {
                case "learn":
                    {
                        var program = int.Parse(instructions[2]);
                        clone.Learn(program);
                        return null;
                    }

                case "rollback":
                    {
                        clone.RollBack();
                        return null;
                    }

                case "relearn":
                    {
                        clone.Relearn();
                        return null;
                    }

                case "clone":
                    {
                        clones.Add(new Clone(clone));
                        return null;
                    }

                case "check":
                    {
                        return clone.Check();
                    }
            }
            return null;
        }
    }

    //Класс, содержащий клона и комманды для него
    public class Clone
    {
        private Stack knowledge; //Знания клона
        private Stack history; //Стёртые знания клона

        //Конструктор
        public Clone()
        {
            knowledge = new Stack();
            history = new Stack();
        }

        //Обучить клона данной программе,
        //и сбросить все стёртые знания
        public void Learn(int program)
        {
            history.Clear();
            knowledge.Push(program);
        }

        //Откатить последнюю программу у клона
        public void RollBack()
        {
            history.Push(knowledge.Pop());
        }

        //Переусвоить последний откат у клона
        public void Relearn()
        {
            knowledge.Push(history.Pop());
        }

        //Клонировать клона
        public Clone(Clone cloneToCopy)
        {
            knowledge = new Stack(cloneToCopy.knowledge);
            history = new Stack(cloneToCopy.history);
        }

        //Вернуть программу, которой владеет клон
        //и при этом усвоил последней.
        //Если клон владеет только базовыми знаниям, вернуть "basic"
        public string Check()
        {
            return knowledge.IsEmpty() ? "basic" :
                                         knowledge.Peek().ToString();
        }
    }

    //Класс, реализующий стэк на односвязном списке
    public class Stack
    {
        private StackItem lastItem; //Верхний элемент стэка
        public Stack() { } //Конструктор

        //Переносит значение
        public Stack(Stack stack)
        {
            lastItem = stack.lastItem;
        }

        //Добавляет значение в стэк
        public void Push(int value)
        {
            lastItem = new StackItem(value, lastItem);
        }

        //Возвращает значение верхнего элемента стэка
        public int Peek()
        {
            return lastItem.Value;
        }

        //Достаёт верхний элемент из стэка
        //и возвращает его значение
        public int Pop()
        {
            var value = lastItem.Value;
            lastItem = lastItem.Previous;
            return value;
        }

        //Проверяет, пуст ли стэк
        public bool IsEmpty()
        {
            return lastItem == null;
        }

        //Отчищает стэк
        public void Clear()
        {
            lastItem = null;
        }
    }

    //Вспомогательный класс стэка, содержащий значения его элементов
    public class StackItem
    {
        public int Value; //Значение элемента
        public StackItem Previous; //Предыдущий элемент стэка

        //Присваивает значения элементам
        public StackItem(int value, StackItem previous)
        {
            Value = value;
            Previous = previous;
        }
    }
}