using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationService;
using Sales.Domain.Commands.VendaCommands;
using Sales.Domain.Contracts.Services;

namespace Sales.Api.Controllers
{
    [Route("v1/vendas")]
    public class VendaController : BaseController
    {
        private readonly IVendaServico _servico;

        public VendaController(IVendaServico servico)
        {
            _servico = servico;

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venda = await _servico.ObterPorIdAsync(id);
                return RetornarResposta((ServicoBase)_servico, venda);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var retorno = await _servico.NovaVendaAsync();
                return RetornarResposta((ServicoBase)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] AdicionarItemComand command)
        {
            try
            {
                var retorno = await _servico.AdicionarItemAsync(id, command);
                return RetornarResposta((ServicoBase)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }
    }
}
