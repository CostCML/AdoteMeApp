namespace AdoteMeApp.Controllers;

public class LoginController
{
    public bool ValidarLogin(string email, string senha)
    {
        if (email == "admin@ong.com" && senha == "123")
            return true;

        return false;
    }
}