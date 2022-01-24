namespace QueryPlusPlus.Domain.Utils.Interfaces
{
    public interface IMapper
    {
        TOutput Map<TInput, TOutput>(TInput input);

        TOutput Map<TInput, TOutput>(TInput input, TOutput output);

        IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> input);

        IQueryable<TOutput> ProjectTo<TOutput>(IQueryable input);
    }
}
