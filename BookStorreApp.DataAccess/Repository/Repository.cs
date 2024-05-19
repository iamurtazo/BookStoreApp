using BookStoreApp.DataAccess;
using BookStorreApp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace BookStorreApp.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        Save();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int? id)
    {
        return _dbSet.Find(id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
        Save();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        Save();
    }

    public void Save()
    {
       _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        Save();
    }
}
