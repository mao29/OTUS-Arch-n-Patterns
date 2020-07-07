using CommandParser;
using System;

namespace CommandParseHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите команду");
            string commandStr = Console.ReadLine();

            var parser = new CommandParser.CommandParser();
            string commandText = parser.TryParseCommand(commandStr, out var command)
                    ? command.ToString()
                    : "Команда не валидна";

            Console.WriteLine(commandText);
            Console.WriteLine("Для завершения работы нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
