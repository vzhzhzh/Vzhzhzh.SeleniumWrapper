namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data
{
    public class LoginInfo
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public LoginInfo(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}