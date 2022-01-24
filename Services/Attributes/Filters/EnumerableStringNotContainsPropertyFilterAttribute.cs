namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableStringNotContainsPropertyFilterAttribute : EnumerableNotContainsPropertyFilterAttribute
    {
        public EnumerableStringNotContainsPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(typeof(string), firstPropertyPath, nPropertyPath)
        {
        }
    }
}
