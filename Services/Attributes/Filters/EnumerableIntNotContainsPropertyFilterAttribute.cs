namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableIntNotContainsPropertyFilterAttribute : EnumerableNotContainsPropertyFilterAttribute
    {
        public EnumerableIntNotContainsPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(typeof(int), firstPropertyPath, nPropertyPath)
        {
        }
    }
}
