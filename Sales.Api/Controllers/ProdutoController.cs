using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Contracts.Services;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IProdutoServico servico)
        {
            var produtos = await servico.ObterAsync();
            return Ok(produtos);
        }
    }
}
