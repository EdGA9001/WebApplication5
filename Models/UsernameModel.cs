namespace WebApplication5.Models
{
    public class UsernameModel
    {
        private const string UserStorage = "ValidUsernames.txt";

        public bool Register(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var users = File.ReadAllLines(UserStorage);

            if (users.Any(line => line.Split(',')[0].Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            File.AppendAllText(UserStorage, $"{username},{password}\n");

            return true;
        }

        public bool ValidateUser(string username, string password)
        {
            var users = File.ReadAllLines(UserStorage);

            return users.Any(line =>
            {
                var parts = line.Split(',');

                return parts[0].Equals(username, StringComparison.OrdinalIgnoreCase) && parts[1] == password;
            }
            );
        }
    }
}