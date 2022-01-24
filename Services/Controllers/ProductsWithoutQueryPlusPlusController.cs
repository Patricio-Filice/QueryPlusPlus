using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Domain.Repository.Interfaces;
using QueryPlusPlus.Domain.Utils.Interfaces;
using QueryPlusPlus.ExtensionMethods;
using QueryPlusPlus.Services.Models.Common.Responses.Gets.Lists;
using QueryPlusPlus.Services.Models.Requests.Gets.Lists;
using QueryPlusPlus.Services.Models.Responses.Gets.Lists;

namespace QueryPlusPlus.Services.Controllers
{
    [Route("api/companies/products")]
    public class ProductsWithoutQueryPlusPlusController : ControllerBase
    {
        private readonly IReadOnlyRepository<Product> productRepository;
        private readonly IMapper mapper;

        public ProductsWithoutQueryPlusPlusController(IReadOnlyRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetListPaginated<ResponseGetListProduct>), StatusCodes.Status200OK)]
        public OkObjectResult List(RequestGetListProductWithoutQueryPlusPlus requestGetListProductWithoutQueryPlusPlus)
        {
            var restrictions = new List<Expression<Func<Product, bool>>>();

            if (requestGetListProductWithoutQueryPlusPlus.Ids?.Any() == true)
            {
                restrictions.Add(p => requestGetListProductWithoutQueryPlusPlus.Ids.Contains(p.Id));
            }

            if (requestGetListProductWithoutQueryPlusPlus.ExcludeIds?.Any() == true)
            {
                restrictions.Add(p => !requestGetListProductWithoutQueryPlusPlus.ExcludeIds.Contains(p.Id));
            }

            if (requestGetListProductWithoutQueryPlusPlus.CompanyIds?.Any() == true)
            {
                restrictions.Add(p => requestGetListProductWithoutQueryPlusPlus.CompanyIds.Contains(p.CompanyId));
            }

            if (requestGetListProductWithoutQueryPlusPlus.ExcludeCompanyIds?.Any() == true)
            {
                restrictions.Add(p => !requestGetListProductWithoutQueryPlusPlus.ExcludeCompanyIds.Contains(p.CompanyId));
            }

            if (requestGetListProductWithoutQueryPlusPlus.Description != null)
            {
                restrictions.Add(p => p.Description.Contains(requestGetListProductWithoutQueryPlusPlus.Description));
            }

            if (requestGetListProductWithoutQueryPlusPlus.CompanyName != null)
            {
                restrictions.Add(p => p.Company.Name.Contains(requestGetListProductWithoutQueryPlusPlus.CompanyName));
            }

            if (requestGetListProductWithoutQueryPlusPlus.Name != null)
            {
                restrictions.Add(p => p.Name.Contains(requestGetListProductWithoutQueryPlusPlus.Name));
            }

            var responsesGetListProduct = this.productRepository.ListAll()
                                                                .Where(restrictions)
                                                                .OrderBy(requestGetListProductWithoutQueryPlusPlus.GetOrderByExpression(), requestGetListProductWithoutQueryPlusPlus.SortDirection)
                                                                .ProjectToPagedList<Product, ResponseGetListProduct>(this.mapper, requestGetListProductWithoutQueryPlusPlus);

            return this.Ok(responsesGetListProduct);
        }
    }
}
