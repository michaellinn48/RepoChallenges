using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeUI.Consoles
{
    public class MockConsole : IConsole
    {
        public Queue<string> UserInput;
        public string Output { get; private set; }

        public MockConsole(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);

            Output = "";
        }

        public void Clear()
        {            
            Output += "Console Clear was Called\n";
        }

        public ConsoleKeyInfo ReadKey()
        {
            Output += "ReadKey called\n";
            return new ConsoleKeyInfo();
        }

        public string ReadLine()
        {
            Output += "ReadLine called\n";
            return UserInput.Dequeue();
        }

        public void Write(string s)
        {
            Output += s;
        }

        public void Write(object o)
        {
            Output += o;
        }

        public void WriteLine(string s)
        {
            Output += s + "\n";
        }

        public void WriteLine(object o)
        {
            Output += o + "\n";
        }
    }
}