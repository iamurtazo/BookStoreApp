namespace BookStorreApp.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // T - Category
    IEnumerable<T> GetAll();
    T GetById(int? id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
