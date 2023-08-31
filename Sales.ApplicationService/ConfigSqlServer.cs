using Flunt.Validations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sales.Domain.Commands.ConfiguracoesCommands;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.SharedKernel.Helpers;
using System.Dynamic;

namespace Sales.ApplicationService;

public class ConfigSqlServer : BaseService, IConfigBancoDados
{
    public ConfigSqlServer(
        IUnitOfWork uow) : base(uow) { }

    public Guid? AlterarConfiguracao(ConfiguracaoCommand command)
    {
        var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        var json = File.ReadAllText(appSettingsPath);

        var jsonSettings = new JsonSerializerSettings();
        jsonSettings.Converters.Add(new ExpandoObjectConverter());
        jsonSettings.Converters.Add(new StringEnumConverter());

        dynamic? config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);

        if (config == null)
            return null;

        var stringConnexao = MontarStringConexao(command);

        if (!EstaValido())
            return null;

        config.ConnectionStrings.DefaultConnection = stringConnexao;

        var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);

        File.WriteAllText(appSettingsPath, newJson);

        return null;
    }

    public string MontarStringConexao(ConfiguracaoCommand command)
    {
        ValidarConfiguracao(command);

        if (!EstaValido())
            return string.Empty;

        var str = $"Data Source={command.Servidor};Initial Catalog={command.Banco};";

        if (!string.IsNullOrEmpty(command.Usuario))
            str += $"Password={command.Usuario};";

        if (!string.IsNullOrEmpty(command.Senha))
            str += $"Password={command.Senha};";

        str += $"Trusted_Connection=True;";
        return CryptographyHelper.Encrypt(str);
    }

    public void ValidarConfiguracao(ConfiguracaoCommand command)
    {
        AddNotifications(new Contract<ConfiguracaoCommand>()
            .Requires()
            .IsNotNull(command, "Configuracao", "Objeto de configuração inválido")
            .IsNotNullOrEmpty(command?.Servidor, "Servidor", "Nome do servidor obrigatório")
            .IsNotNullOrEmpty(command?.Banco, "Banco", "Nome do banco de dados obrigatório."));
    }
}