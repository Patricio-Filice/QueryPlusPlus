namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableIntContainsPropertyFilterAttribute : EnumerableContainsPropertyFilterAttribute
    {
        public EnumerableIntContainsPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(typeof(int), firstPropertyPath, nPropertyPath)
        {
        }
    }
}
