namespace QueryPlusPlus.Services.Models.Responses.Gets.Lists
{
    public class ResponseGetListProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ResponseGetListProductReview> Reviews { get; set; }

        public ResponseGetListCompany Company { get; set; }
    }
}
