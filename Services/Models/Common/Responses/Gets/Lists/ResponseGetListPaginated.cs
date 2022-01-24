namespace QueryPlusPlus.Services.Models.Common.Responses.Gets.Lists
{
    public class ResponseGetListPaginated<TResponseGetList>
        where TResponseGetList : class
    {
        public int PageCount { get; set; }

        public List<TResponseGetList> PageItems { get; set; }

        public int TotalCount { get; set; }
    }
}
