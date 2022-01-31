using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeUI.Consoles
{
    public interface IConsole
    {
        void Clear();

        void WriteLine(string s);
        void WriteLine(object o);

        void Write(string s);
        void Write(object o);

        string ReadLine();

        ConsoleKeyInfo ReadKey();
    }
}