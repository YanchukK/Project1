namespace Registration
{
    class Registration : IRegistration
    {
        private const string Path = "users.json";

        // e - mail: адрес почты куда придёт ссылка для подтвереждения регистрации
        public string GetEmail()
        {
            string email = Validator.ValidateEmail();
            bool ish = FileService.IsPropertyAlreadyExist(email, Path);

            if (ish)
                return email;
            else
                email = Validator.ValidateEmail();
            return email;
        }

        public string GetUsername()
        {
            string name = Validator.ValidateUsername();
            bool ish = FileService.IsPropertyAlreadyExist(name, Path);

            if (ish)
                return name;
            else
                name = Validator.ValidateUsername();

            return name;
        }

        public string GetPassword()
        {
            string password = Validator.ValidatePassword();

            bool ish = FileService.IsPropertyAlreadyExist(password, Path);

            if (ish)
                return password;
            else
                password = Validator.ValidatePassword();

            return password;
        }
       
        public void RegisterUser()
        {
            var user = new User
            {
                Email = GetEmail(),
                Username = GetUsername(),
                Password = GetPassword()
            };

            FileService.SaveUser(user, Path);
        }
  
    }
}
