using Sales.Domain.Commands.ConfiguracoesCommands;

namespace Sales.Domain.Contracts.Services;

public interface IConfigBancoDados : IServiceBase
{
    Guid? AlterarConfiguracao(ConfiguracaoCommand command);

    string MontarStringConexao(ConfiguracaoCommand command);

    void ValidarConfiguracao(ConfiguracaoCommand command);

}
