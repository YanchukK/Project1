using HomeWork.Services.PL;
using SimpleInjector;
using HomeWork.Services.PL.Commands;
using HomeWork.Abstractions.PL;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    { 
        private static void Main()
        {
            // Your Inversion of Control (Simple Injector)
            var container = new Container();

            // 2. Configure the container (register)

            //var a = Lifestyle.Transient.CreateProducer<ICommand, AddUserCommand>(container);
            //var b = Lifestyle.Transient.CreateProducer<ICommand, ListUsersCommand>(container);

            container.Collection.Register(typeof(ICommand), new[] {
                typeof(ListUsersCommand),
                typeof(AddUserCommand)
            });

            container.Register<ICommandProcessor>(() => new CommandProcessor(
                container.GetInstance<ICommand>(),
                Dictionary < container.GetInstance<ICommand>().Number,
                ICommand > ()));

            //container.Register<ICommandProcessor>(() =>
            //new CommandProcessor(new System.Collections.Generic.));


            //container.Register<ICommand, AddUserCommand>();
            //container.Register<ICommand, ListUsersCommand>();

            container.Register<ICommandProcessor, CommandProcessor>();
            container.Register<CommandManager>();

            // 3. Verify your configuration
            container.Verify();

            var manager = container.GetInstance<CommandManager>();

            //var manager = new CommandManager();

            manager.Start();
        }
    }
}

