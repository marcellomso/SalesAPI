using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationService;
using Sales.Domain.Commands.ConfiguracoesCommands;
using Sales.Domain.Contracts.Services;

namespace Sales.Api.Controllers
{
    [Route("v1/confguracoes")]
    public class ConfiguracaoController : BaseController
    {
        private readonly IConfigBancoDados _servico;

        public ConfiguracaoController(IConfigBancoDados servico)
        {
            _servico = servico;
        }

        [HttpPut]
        public IActionResult Put(ConfiguracaoCommand command)
        {
            try
            {
                var retorno = _servico.AlterarConfiguracao(command);
                return RetornarResposta((BaseService)_servico, retorno);
            }
            catch (Exception ex)
            {
                return RetornarResposta(ex);
            }
        }
    }
}
