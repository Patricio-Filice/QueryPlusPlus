using AutoMapper;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Services.Models.Responses.Gets.Lists;

namespace QueryPlusPlus.Mapping.Profiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            this.CreateMap<Company, ResponseGetListCompany>();
        }
    }
}
