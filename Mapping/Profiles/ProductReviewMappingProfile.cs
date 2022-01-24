using AutoMapper;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Services.Models.Responses.Gets.Lists;

namespace QueryPlusPlus.Mapping.Profiles
{
    public class ProductReviewMappingProfile : Profile
    {
        public ProductReviewMappingProfile()
        {
            this.CreateMap<ProductReview, ResponseGetListProductReview>();
        }
    }
}
