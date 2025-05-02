using ControleLancamento.Infrastructure.EventBus;
using FluentMigrator.Runner;
using FluxoCaixa.Application.Services;
using FluxoCaixa.Domain.Repository;
using FluxoCaixa.Infrastructure;
using FluxoCaixa.Infrastructure.Repository;
using FluxoCaixa.Migrations;
using FluxoCaixaBackground;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Data.Common;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<LancamentoTask>();

builder.Services.AddSingleton<LancamentoService>();

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<ILancamentoRepository, LancamentoRepository>();

builder.Services.AddSingleton(rabbitmq =>
{
    var rabbitMqUrl = builder.Configuration.GetConnectionString("RabbitMq");
    var factory = new ConnectionFactory() { HostName = rabbitMqUrl };

    return new RabbitMqConnector(factory);
});



var serviceCollection = builder.Services
        .AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c
            .AddPostgres15_0()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("PostgreSql"))
            .ScanIn(AppDomain.CurrentDomain.Load("FluxoCaixa.Migrations")).For.All());
var serviceProvider = serviceCollection.BuildServiceProvider(false);



IHost host = builder.Build();
host.Migrate(serviceProvider);
host.Run();
