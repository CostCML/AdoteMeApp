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

        _database.CreateTableAsync<Animal>().Wait();

        _database.CreateTableAsync<ONG>().Wait();

        _database.CreateTableAsync<SolicitacaoAdocao>().Wait();
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

    public async Task<int> SalvarAnimal(
    Animal animal)
    {
        return await _database.InsertAsync(
            animal);
    }

    public async Task<List<Animal>> ListarAnimais()
    {
        return await _database.Table<Animal>()
            .ToListAsync();
    }


    public async Task<int> SalvarONG(
    ONG ong)
    {
        return await _database.InsertAsync(
            ong);
    }

    public async Task<List<ONG>> ListarONGs()
    {
        return await _database.Table<ONG>()
            .ToListAsync();
    }

    public async Task<int> SalvarSolicitacao(
    SolicitacaoAdocao solicitacao)
    {
        return await _database.InsertAsync(
            solicitacao);
    }

    public async Task<List<SolicitacaoAdocao>>
        ListarSolicitacoes()
    {
        return await _database
            .Table<SolicitacaoAdocao>()
            .ToListAsync();
    }

    public async Task AtualizarSolicitacao(
    SolicitacaoAdocao solicitacao)
    {
        await _database.UpdateAsync(
            solicitacao);
    }

    public async Task<int> AtualizarUsuario(
    Usuario usuario)
    {
        return await _database.UpdateAsync(
            usuario);
    }


}