using System;
using System.Collections.Generic;

namespace func.brainfuck
{
    //�������� ����� ���������
    public class VirtualMachine : IVirtualMachine
    {
        public string Instructions { get; } 
        public int InstructionPointer { get; set; } = 0;
        public byte[] Memory { get; }
        public int MemoryPointer { get; set; } = 0; 
        private Dictionary<char, Action<IVirtualMachine>> commands = new Dictionary<char, Action<IVirtualMachine>>();

        //����������� ��������
        public VirtualMachine(string program, int memorySize)
        {
            Instructions = program;
            Memory = new byte[memorySize];
        }

        //��������� ������� � �������
        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {
            commands.Add(symbol, execute);
        }
    
        //��������� �������
        public void Run()
        {
            while (InstructionPointer < Instructions.Length && InstructionPointer >= 0)
            {
                var symbol = Instructions[InstructionPointer];
                if (commands.ContainsKey(symbol))
                    commands[symbol](this);
                InstructionPointer++;
            }
        }
    }
}