using AdoteMeApp.Models;

namespace AdoteMeApp.Services;

public class AuthService
{
    private readonly DatabaseService _database;

    public AuthService(
        DatabaseService database)
    {
        _database = database;
    }

    public async Task<Usuario?> Login(
        string email,
        string senha)
    {
        return await _database.Login(
            email,
            senha);
    }

    public async Task<bool> UsuarioExiste(
        string email)
    {
        var usuario =
            await _database.BuscarPorEmail(
                email);

        return usuario != null;
    }
}