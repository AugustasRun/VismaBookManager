using System;
using VismaBookManager.Models;
using VismaBookManager.ConsoleUI;
using VismaBookManager.PublicationRepository;

namespace VismaBookManager
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleInterface consoleUI = new ConsoleInterface();
            BookRunner run = new BookRunner(consoleUI);
            run.Run();
        }
    }
}
