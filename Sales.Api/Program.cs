using Microsoft.EntityFrameworkCore;
using Sales.ApplicationService;
using Sales.Data.Persistence;
using Sales.Data.Repositories;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.SharedKernel.Helpers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SalesDataContext>(options =>
{
    options.UseSqlServer(!string.IsNullOrEmpty(builder.Configuration.GetConnectionString("DefaultConnection")) ?
        CryptographyHelper.Dencrypt(builder.Configuration.GetConnectionString("DefaultConnection")) :
        "Server=;Database=;Trusted_Connection=True;");
});

builder.Services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddTransient<IProdutoServico, ProdutoServico>();
builder.Services.AddTransient<IVendaRepositorio, VendaRepositorio>();
builder.Services.AddTransient<IVendaServico, VendaSevico>();
builder.Services.AddTransient<IConfigBancoDados, ConfigSqlServer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
