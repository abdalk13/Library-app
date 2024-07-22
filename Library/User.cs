namespace LibrarySystem
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Authenticate(string password)
        {
            return Password == password;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
