using AutoMapper;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Services.Models.Responses.Gets.Lists;

namespace QueryPlusPlus.Mapping.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            this.CreateMap<Product, ResponseGetListProduct>();
        }
    }
}
