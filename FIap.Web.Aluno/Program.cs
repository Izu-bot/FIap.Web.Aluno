using AutoMapper;
using Fiap.Web.Aluno.Data.Repository;
using Fiap.Web.Aluno.Models;
using Fiap.Web.Aluno.Services;
using Fiap.Web.Aluno.ViewModels;
using Fiap.Web.Alunos.Services;
using FIap.Web.Aluno.Data;
using FIap.Web.Aluno.Data.Repository;
using FIap.Web.Aluno.Logging;
using FIap.Web.Aluno.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

# region Configuração banco de dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataBaseContext>(

    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

#endregion

#region Registro IServiceColletion
builder.Services.AddSingleton<ICustomLogger, MockLogger>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
#endregion

#region AutoMapper

// Configuração do AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    // Permite que coleções nulas sejam mapeadas
    c.AllowNullCollections = true;

    // Permite que valores de destino nulos sejam mapeados
    c.AllowNullDestinationValues = true;

    // Define o mapeamento de ClienteModel para ClienteCreateViewModel
    c.CreateMap<ClienteModel, ClienteCreateViewModel>();

    // Define o mapeamento de ClienteCreateViewModel para ClienteModel
    c.CreateMap<ClienteCreateViewModel, ClienteModel>();

});

// Cria o mapper com base na configuração definida
IMapper mapper = mapperConfig.CreateMapper();

// Registra o IMapper como um serviço singleton no container DI do ASP.NET Core
builder.Services.AddSingleton(mapper);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
