using LiteDB;

namespace CartingService.DataAccessLayer;

public class LiteDbRepository<T> : IRepository<T> where T : class
{
    private readonly string _collectionName;
    private readonly LiteDatabase _db;

    public LiteDbRepository(string dbName, string collectionName)
    {
        _collectionName = collectionName;
        _db = new LiteDatabase(dbName);
    }

    public T? GetById(Guid id)
    {
        var collection = _db.GetCollection<T>(_collectionName);
        return collection.FindById(id);
    }

    public IEnumerable<T> GetAll()
    {
        var collection = _db.GetCollection<T>(_collectionName);
        return collection.FindAll();
    }

    public void Create(T entity)
    {
        var collection = _db.GetCollection<T>(_collectionName);
        collection.Insert(entity);
    }

    public void Update(T entity)
    {
        var collection = _db.GetCollection<T>(_collectionName);
        collection.Update(entity);
    }

    public void Delete(Guid id)
    {
        var collection = _db.GetCollection<T>(_collectionName);
        collection.Delete(id);
    }
}