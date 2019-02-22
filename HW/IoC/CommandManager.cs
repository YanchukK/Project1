using HomeWork.Abstractions.PL;
using HomeWork.Services.PL.Commands;
using System;
using System.Text;

namespace HomeWork.Services.PL
{
    public class CommandManager
    {
        private readonly ICommandProcessor processor; // = new CommandProcessor();
        private string info;

        public CommandManager(ICommandProcessor processor)
        {
            this.processor = processor;
        }

        public void Start()
        {
            this.SetupInfo();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(this.info);

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)
                    ||
                    !int.TryParse(input, out var command))
                {
                    continue;
                }

                this.processor.Process(command);

                Console.WriteLine("RETURN to continue...");
                Console.ReadLine();
            }
        }

        private void SetupInfo()
        {
            var sb = new StringBuilder();
            var commands = this.processor.Commands;

            sb.AppendLine("Select operation:");

            foreach (var command in commands)
            {
                sb.AppendLine($"{command.Number}. {command.DisplayName}");
            }

            this.info = sb.ToString();
        }
    }
}
