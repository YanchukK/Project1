using System.Runtime.Serialization;

namespace Registration
{
    [DataContract]
    class User
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        public User ()
        {

        }

        public User(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
