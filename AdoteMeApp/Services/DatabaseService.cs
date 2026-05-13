using SQLite;
using AdoteMeApp.Models;

namespace AdoteMeApp.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath =
            Path.Combine(
                FileSystem.AppDataDirectory,
                "adoteme.db3");

        _database =
            new SQLiteAsyncConnection(dbPath);

        _database.CreateTableAsync<Usuario>().Wait();
    }

    public async Task<int> SalvarUsuario(
        Usuario usuario)
    {
        return await _database.InsertAsync(
            usuario);
    }

    public async Task<Usuario?> Login(
        string email,
        string senha)
    {
        return await _database.Table<Usuario>()
            .Where(u =>
                u.Email == email &&
                u.Senha == senha)
            .FirstOrDefaultAsync();
    }

    public async Task<Usuario?> BuscarPorEmail(
        string email)
    {
        return await _database.Table<Usuario>()
            .Where(u =>
                u.Email == email)
            .FirstOrDefaultAsync();
    }
}