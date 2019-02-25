namespace Registration
{
    interface IRegistration
    {
        void RegisterUser();

        string GetEmail();

        string GetUsername();

        string GetPassword();
    }
}
