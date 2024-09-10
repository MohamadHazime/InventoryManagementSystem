namespace Inventory.Domain.SeedWork;

public interface IEntityRepository<T> where T : Entity
{
    T Add(T entity);
    Task<T> GetAsync(int entityId);
    void Update(T entity);
    Task<bool> DeleteAsync(int entityId);
}
