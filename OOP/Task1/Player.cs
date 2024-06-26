namespace OOP.Task1
{
    internal class Player
    {
        private int _id;
        private string _visibleName;
        private string _login;
        private string _passwordHash;
        private DateTime _registrationDate;

        public Player(
            int id,
            string visibleName,
            string login,
            string passwordHash,
            DateTime registrationDate)
        {
            _id = id;
            _visibleName = visibleName;
            _login = login;
            _passwordHash = passwordHash;
            _registrationDate = registrationDate;
        }

        public Player(int id, string visibleName, string login, string passwordHash)
            : this(id, visibleName, login, passwordHash, DateTime.Now)
        {

        }

        public override string ToString()
        {
            return
                $"\n{{" +
                $"\n    \"{nameof(_id)}\" : {_id}," +
                $"\n    \"{nameof(_visibleName)}\" : \"{_visibleName}\"," +
                $"\n    \"{nameof(_login)}\" : \"{_login}\"," +
                $"\n    \"{nameof(_passwordHash)}\" : \"{_passwordHash}\"," +
                $"\n    \"{nameof(_registrationDate)}\" : \"{_registrationDate}\"," +
                $"\n}}";
        }

        public void PrintToStream(TextWriter textWriter)
        {
            textWriter.WriteLine(ToString());
        }
    }
}
