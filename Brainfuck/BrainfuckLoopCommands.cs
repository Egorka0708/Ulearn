using System.Collections.Generic;

namespace func.brainfuck
{
    //�������� ����� ���������
    public class BrainfuckLoopCommands
    {
        //���������� ������� ��� brainfuck �����
        public static void RegisterTo(IVirtualMachine vm)
        {
            var braces = FindBraces(vm.Instructions);

            vm.RegisterCommand('[', b =>
            { if (b.Memory[b.MemoryPointer] == 0) b.InstructionPointer = braces[b.InstructionPointer]; });

            vm.RegisterCommand(']', b =>
            { if (b.Memory[b.MemoryPointer] != 0) b.InstructionPointer = braces[b.InstructionPointer]; });
        }

        //������� ������� ����������� � ����������� ������ � ���������� �� � �������
        private static Dictionary<int, int> FindBraces(string program)
        {
            var result = new Dictionary<int, int>();
            var bracesPosition = new Stack<int>();
            for (var i = 0; i < program.Length; i++)
            {
                if (program[i] == '[')
                    bracesPosition.Push(i);
                if (program[i] == ']')
                {
                    var openBrace = bracesPosition.Pop();
                    var closeBrace = i;
                    result.Add(openBrace, closeBrace);
                    result.Add(closeBrace, openBrace);
                }
            }
            return result;
        }
    }
}