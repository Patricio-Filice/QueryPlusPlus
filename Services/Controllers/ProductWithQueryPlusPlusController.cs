using Microsoft.AspNetCore.Mvc;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Domain.Repository.Interfaces;
using QueryPlusPlus.Domain.Utils.Interfaces;
using QueryPlusPlus.ExtensionMethods;
using QueryPlusPlus.ExtensionMethods.Controllers.Models.Common.Requests.Gets.Lists;
using QueryPlusPlus.Services.Models.Requests.Gets.Lists;
using QueryPlusPlus.Services.Models.Responses.Gets.Lists;

namespace QueryPlusPlus.Services.Controllers
{
    [Route("api/frameworks/query-plus-plus/companies/products")]
    public class ProductWithQueryPlusPlusController : ControllerBase
    {
        private readonly IReadOnlyRepository<Product> productRepository;
        private readonly IMapper mapper;

        public ProductWithQueryPlusPlusController(IReadOnlyRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public OkObjectResult List(RequestGetListProductWithQueryPlusPlus requestGetListProductWithQueryPlusPlus)
        {
            var restrictions = requestGetListProductWithQueryPlusPlus.ListRestrictions();

            if (requestGetListProductWithQueryPlusPlus.HotSell)
            {
                restrictions.Add(p => p.Reviews.All(p => p.Score > 3) && p.Reviews.Any(pr => pr.Description.Contains("Important reviewer")));
            }

            var orderCriteria = requestGetListProductWithQueryPlusPlus.GetOrderCriteria();

            var responsesGetListProduct = this.productRepository.ListAll()
                                                                .Where(restrictions)
                                                                .OrderBy(orderCriteria)
                                                                .ProjectToPagedList<Product, ResponseGetListProduct>(this.mapper, requestGetListProductWithQueryPlusPlus);

            return this.Ok(responsesGetListProduct);
        }
    }
}
