namespace Inventory.Domain.SeedWork;

public interface IEntityRepository<T>
{
    T Add(T entity);
    Task<T> GetAsync(int entityId);
    void Update(T entity);
    Task<bool> DeleteAsync(int entityId);
}
