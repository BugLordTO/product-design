using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Queries;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductQuery productQuery;

        public ProductController(ProductQuery productQuery)
        {
            this.productQuery = productQuery.Build();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var schema = new Schema { Query = productQuery };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query;
                //x.Inputs = JsonConvert.DeserializeObject<Inputs>(variables);
            });
            return Ok(result);
        }
    }
}