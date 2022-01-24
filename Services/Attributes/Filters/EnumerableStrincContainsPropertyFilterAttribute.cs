namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableStrincContainsPropertyFilterAttribute : EnumerableContainsPropertyFilterAttribute
    {
        public EnumerableStrincContainsPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(typeof(string), firstPropertyPath, nPropertyPath)
        {
        }
    }
}
