using AdoteMeApp.Data;
using AdoteMeApp.Models;

namespace AdoteMeApp.Controllers;

public class OngController
{
    private readonly AppDatabase _database;

    public OngController(AppDatabase database)
    {
        _database = database;
    }

    public List<Animal> GetAnimals()
    {
        return _database.GetAnimals();
    }
}