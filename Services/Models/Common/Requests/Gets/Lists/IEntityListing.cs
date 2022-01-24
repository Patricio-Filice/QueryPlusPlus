namespace QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists
{
    public interface IEntityListing<TEntity> : IEntityFilter<TEntity>, IEntityOrderer<TEntity>
    {
    }
}
