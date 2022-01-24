using Microsoft.AspNetCore.Mvc;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Domain.Repository.Interfaces;
using QueryPlusPlus.Domain.Utils.Interfaces;
using QueryPlusPlus.ExtensionMethods;
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
            var responsesGetListProduct = this.productRepository.ListAll()
                                                                .Where(requestGetListProductWithQueryPlusPlus)
                                                                .ProjectToPagedList<Product, ResponseGetListProduct>(this.mapper, requestGetListProductWithQueryPlusPlus);

            return this.Ok(responsesGetListProduct);
        }
    }
}
