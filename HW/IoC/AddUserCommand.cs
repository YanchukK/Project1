using System;
using HomeWork.Abstractions.BLL;
using HomeWork.Abstractions.PL;
using HomeWork.Models;


namespace HomeWork.Services.PL.Commands
{
    public class AddUserCommand : ICommand
    {
        private readonly IUserStore userStore = new UserStore();

        //public AddUserCommand(IUserStore userStore)
        //{
        //    this.userStore = userStore;
        //}

        public int Number { get; } = 1;

        public string DisplayName { get; } = "Add user";

        public void Execute()
        {
            var rnd = new Random();
            var id = rnd.Next(1, 101);

            this.userStore.AddUser(new User
            {
                Id = id,
                Name = $"User {id}"
            });
        }
    }
}
