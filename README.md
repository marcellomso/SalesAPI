# API Controle Vendas .net 6


Siga as instruções abaixo para compilar e executar o projeto


### Pré-requisitos
Baixar e instalar

SQLServer

[Git](https://git-scm.com/download/win)

[Dotnet SDK v6.0.302](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Instalar Tool Entity Core, via linha de comando:
```
dotnet tool install --global dotnet-ef
```


### Clonar repositório

Abra o terminal de comando, e selecione uma pasta para clonar o repositório como seguinte comando:
```
git clone https://github.com/marcellomso/SalesAPI.git
```


### Compilação
Ainda no terminal, acesse a pasta raiz do projeto e execute o build da aplicação com os seguintes comandos:
```
cd ./SalesApi
dotnet build
```

Aguarde enquanto são baixadas as dependências do projeto


### Executar a Migration para criação do banco de dados
```
dotnet-ef database update -s Sales.api
```
Caso haja algum problema, siga as demais configurações até rodar o projeto para configurar a string de conexão

### Executar a aplicação
Após baixar e instalar todas as dependências já é possível executar o projeto. Acesse a pasta do projeto Sales.Api e esecute o comando Run do CLI do DotNet

```
cd .\Sales.Api\
dotnet run
```

Assim que a aplicação iniciar a API que estára respondendo no endereço https://localhost:7265, e já pode receber chamadas, via postman, por exemplo.

### Chamadas utilizando Swagger
Para utilizar o Swawgger acesse o endereço:
```
https://localhost:7265/swagger/index.html
```

#### Atenção:
Caso não tenha conseguido configurar o banco de dados execute chamada ao endipoint de configuração, e depois excecute o migration novamente.


### Testes Unitário
Para executar os testes basta digitar o comando dotnet test dentro da pasta do projeto.

```
cd .\Sales.Tests\
dotnet test
```
