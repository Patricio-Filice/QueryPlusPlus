using QueryPlusPlus.Domain.Utils.Interfaces;

namespace QueryPlusPlus.Domain.Utils.Gadgets
{
    public class AutoMapperWrapper : IMapper
    {
        private readonly AutoMapper.IMapper mapper;

        public AutoMapperWrapper(AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> input)
        {
            return this.mapper.Map<IEnumerable<TInput>, IEnumerable<TOutput>>(input);
        }

        public TOutput Map<TInput, TOutput>(TInput input)
        {
            return this.mapper.Map<TInput, TOutput>(input);
        }
        public TOutput Map<TInput, TOutput>(TInput input, TOutput output)
        {
            return this.mapper.Map(input, output);
        }

        public IQueryable<TOutput> ProjectTo<TOutput>(IQueryable input)
        {
            return this.mapper.ProjectTo<TOutput>(input);
        }

        public void AssertConfigurationIsValid()
        {
            this.mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
