using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
    //Основной класс программы
    public class ReadonlyBytes : IEnumerable<byte>
    {
        public readonly byte[] Collection;
        public int Hash = -1;

        //Передаёт значение коллекции
        public ReadonlyBytes(params byte[] list)
        {
            Collection = list ?? throw new ArgumentNullException();
        }

        //Возвращает элемент
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Collection.Length) throw new IndexOutOfRangeException();
                return Collection[index];
            }
            set
            {
                if (index < 0 || index >= Collection.Length) throw new IndexOutOfRangeException();
                Collection[index] = value;
            }
        }

        //Находит длину
        public int Length { get { return Collection.Length; } }

        //Проверяет идентичность объектов
        public override bool Equals(object obj)
        {
            bool result;
            var bytes = obj as ReadonlyBytes;
            if (bytes?.Length != Collection.Length) result = false;
            for (int i = 0; i < Collection.Length; i++)
            {
                if (Collection[i] != bytes[i])
                    result = false;
            }
            result = true;
            return result;
        }

        //Возвращает хэш
        public override int GetHashCode()
        {
            unchecked
            {
                if (Hash != -1) return Hash;
                var prime = 514229;
                Hash = 1;
                for (int i = 0; i < Collection.Length; i++)
                {
                    Hash *= prime;
                    Hash ^= Collection[i];
                }
                return Hash;
            }
        }

        //Проверка на идентичность двух данных ReadonlyBytes коллекций 
        private bool Equals(ReadonlyBytes another)
        {
            return Equals(Collection, another.Collection);
        }

        //Перевод в string
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append('[' + string.Join(", ", Collection) + ']');
            return result.ToString();
        }      

        //Перечеслитель
        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Collection.Length; i++)
                yield return Collection[i];
        }

        //Реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}