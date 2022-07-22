using Sales.Domain.Commands.ConfiguracoesCommands;

namespace Sales.Domain.Contracts.Services
{
    public interface IConfigBancoDados : IServiceBase
    {
        int? AlterarConfiguracao(ConfiguracaoCommand command);

        string MontarStringConexao(ConfiguracaoCommand command);

        void ValidarConfiguracao(ConfiguracaoCommand command);

    }
}
