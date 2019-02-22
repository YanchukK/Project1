using HomeWork.Abstractions;
using HomeWork.Abstractions.BLL;
using HomeWork.Abstractions.PL;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Services.PL.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands;// = new Dictionary<int, ICommand>();

        public CommandProcessor(/*ICommand command, */Dictionary<int, ICommand> commands)
        {
            this.commands.Add(commands.Number, command);
            //var addUsers = new AddUserCommand();
            //var listUsers = new ListUsersCommand();

            //this.commands.Add(addUsers.Number, addUsers);
            //this.commands.Add(listUsers.Number, listUsers);
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}
