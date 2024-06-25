namespace OOP.Task1
{
    internal class Player
    {
        public int Id { get; private set; }

        public string VisibleName { get; private set; }

        public string Login { get; private set; }

        public string PasswordHash { get; private set; }

        public DateTime RegistrationDate { get; private set; }

        public Player(
            int id,
            string visibleName,
            string login,
            string passwordHash,
            DateTime registrationDate)
        {
            Id = id;
            VisibleName = visibleName;
            Login = login;
            PasswordHash = passwordHash;
            RegistrationDate = registrationDate;
        }

        public Player(int id, string visibleName, string login, string passwordHash)
            : this(id, visibleName, login, passwordHash, DateTime.Now)
        {

        }

        public void PrintToStream(TextWriter textWriter)
        {
            textWriter.WriteLine(ToString());
        }

        public override string ToString()
        {
            return
                $"\n{{" +
                $"\n    \"{nameof(Id)}\" : {Id}," +
                $"\n    \"{nameof(VisibleName)}\" : \"{VisibleName}\"," +
                $"\n    \"{nameof(Login)}\" : \"{Login}\"," +
                $"\n    \"{nameof(PasswordHash)}\" : \"{PasswordHash}\"," +
                $"\n    \"{nameof(RegistrationDate)}\" : \"{RegistrationDate}\"," +
                $"\n}}";
        }
    }
}
