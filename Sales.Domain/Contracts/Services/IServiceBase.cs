namespace Sales.Domain.Contracts.Services;

public interface IServiceBase
{
    bool EstaValido();
    List<string> Notificacoes();

    void ValidarCommandEntrada(object command, string mensagemRetorno);
}
