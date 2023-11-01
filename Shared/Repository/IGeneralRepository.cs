namespace Shared.Repository;

public interface IGeneralRepository
{
    public void add(object entity);

    public void delete(object entity);

    public void update(object entity);

    public IQueryable<TEntity> Query<TEntity>()
        where TEntity : class;

}