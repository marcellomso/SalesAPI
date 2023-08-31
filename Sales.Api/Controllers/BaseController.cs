using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationService;

namespace Sales.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult RetornarResposta(BaseService service, object? objData)
        {
            if (objData == null)
                return RespostaNaoEncontrado(service.Notificacoes());

            if (!service.EstaValido())
                return RespostaErro(objData, service.Notificacoes());

            return RespostaSucesso(objData);
        }

        protected IActionResult RetornarResposta(Exception ex)
        {
            var erros = new List<string>
            {
                $"{nameof(ex.Message)}: {ex.Message}",
                $"{nameof(ex.InnerException)}: {ex.InnerException}"
            };
            return RespostaErro("Falha ao execular a requisição.", erros);
        }

        private IActionResult RespostaErro(object objData, List<string> listaErros)
           => BadRequest(new
                {
                    success = false,
                    data = objData,
                    errors = listaErros
           });

        private IActionResult RespostaNaoEncontrado(List<string> listaErros)
           => NotFound(new
                {
                    success = false,
                    errors = listaErros
           });

        private IActionResult RespostaSucesso(object objData)
            => Ok(new { success = true, data = objData});
    }
}
