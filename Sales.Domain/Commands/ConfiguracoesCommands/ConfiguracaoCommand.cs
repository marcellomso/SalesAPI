namespace Sales.Domain.Commands.ConfiguracoesCommands;

public class ConfiguracaoCommand
{
    public string Servidor { get; set; } = string.Empty;
    public string Banco { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
