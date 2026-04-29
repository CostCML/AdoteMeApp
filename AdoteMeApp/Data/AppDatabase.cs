using SQLite;
using AdoteMeApp.Models;

namespace AdoteMeApp.Data;

public class AppDatabase
{
    private readonly SQLiteConnection _database;

    public AppDatabase(string dbPath)
    {
        _database = new SQLiteConnection(dbPath);

        _database.CreateTable<Animal>();
        _database.CreateTable<Adotante>();
        _database.CreateTable<Voluntario>();
        _database.CreateTable<Parceiro>();
        _database.CreateTable<ONG>();
    }

    public List<Animal> GetAnimals()
    {
        return _database.Table<Animal>().ToList();
    }

    public int SaveAnimal(Animal animal)
    {
        return _database.Insert(animal);
    }
}