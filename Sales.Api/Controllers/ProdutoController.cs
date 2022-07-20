using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationService;
using Sales.Domain.Commands.ProdutoCommand;
using Sales.Domain.Contracts.Services;

namespace Sales.Api.Controllers
{
    [Route("v1/produtos")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoServico _servico;

        public ProdutoController(IProdutoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _servico.ObterAsync();
                return RetornarResposta((ServicoBase)_servico, produtos);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var produto = await _servico.ObterPorIdAsync(id);
                return RetornarResposta((ServicoBase)_servico, produto);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpGet]
        [Route("{descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var produtos = await _servico.ObterAsync(descricao);
                return RetornarResposta((ServicoBase)_servico, produtos);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoCommand command)
        {
            try
            {
                var retorno = await _servico.AdicionarAsync(command);
                return RetornarResposta((ServicoBase)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProdutoCommand command)
        {
            try
            {
                var retorno = await _servico.AtualizarAsync(id, command);
                return RetornarResposta((ServicoBase)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var retorno = await _servico.ExcluirAsync(id);
                return RetornarResposta((ServicoBase)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }
    }
}
