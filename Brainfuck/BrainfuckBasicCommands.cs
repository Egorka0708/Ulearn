using System;
using System.Collections.Generic;
using System.Linq;

namespace func.brainfuck
{
    //Основной класс программы
    public static class BrainfuckBasicCommands
    {
        //Добавление комманд для brainfuck языка
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            vm.RegisterCommand('.', b => write((char)b.Memory[b.MemoryPointer]));

            vm.RegisterCommand('+', b => b.Memory[b.MemoryPointer] =
               (byte)(b.Memory[b.MemoryPointer] == 255 ? 0 : b.Memory[b.MemoryPointer] + 1));

            vm.RegisterCommand('-', b => b.Memory[b.MemoryPointer] =
               (byte)(b.Memory[b.MemoryPointer] == 0 ? 255 : b.Memory[b.MemoryPointer] - 1));

            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte)read(); });

            vm.RegisterCommand('>', b =>
            { b.MemoryPointer = b.MemoryPointer == b.Memory.Length - 1 ? 0 : ++b.MemoryPointer; });

            vm.RegisterCommand('<', b =>
            { b.MemoryPointer = b.MemoryPointer == 0 ? b.Memory.Length - 1 : --b.MemoryPointer; });

            SaveSymbolsFromRange(vm,
                                 new Tuple<char, char>('a', 'z'),
                                 new Tuple<char, char>('A', 'Z'),
                                 new Tuple<char, char>('0', '9'));
        }

        //Добавляет алфавит и цифры в память
        private static void SaveSymbolsFromRange(IVirtualMachine vm, params Tuple<char, char>[] ranges)
        {
            foreach (var range in ranges)
                for (var i = range.Item1; i <= range.Item2; i++)
                {
                    var symbol = i;
                    vm.RegisterCommand(symbol, b => b.Memory[b.MemoryPointer] = (byte)symbol);
                }
        }
    }
}