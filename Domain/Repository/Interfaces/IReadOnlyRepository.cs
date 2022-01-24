namespace QueryPlusPlus.Domain.Repository.Interfaces
{
    public interface IReadOnlyRepository<TEntity>
    {
        IQueryable<TEntity> ListAll();
    }
}
