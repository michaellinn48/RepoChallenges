using System;
using CafeUI.Consoles;

namespace CafeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // what console I want to use
            IConsole console = new RealConsole();
            // pass that info to my UI
            UserInterface ui = new UserInterface(console);
            ui.Run();
        }
    }
}
