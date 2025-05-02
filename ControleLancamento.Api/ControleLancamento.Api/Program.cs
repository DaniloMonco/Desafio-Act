using ControleLancamento.Api.Request;
using ControleLancamento.Api.Response;
using ControleLancamento.Application.CreditoCommand;
using ControleLancamento.Application.DebitoCommand;
using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Repository;
using ControleLancamento.Infrastructure.EventBus;
using ControleLancamento.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("ControleLancamento.Application")));

//var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
builder.Services.AddSingleton(mongoDb =>
{
    var mongoDbUrl = builder.Configuration.GetConnectionString("MongoDB");
    var mongoClient = new MongoClient(mongoDbUrl);
    return mongoClient;
});



builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddSingleton<ILancamentoEfetuadoPublisher, LancamentoEfetuadoPublisher>();
builder.Services.AddSingleton(rabbitmq =>
{
    var rabbitMqUrl = builder.Configuration.GetConnectionString("RabbitMq");
    var factory = new ConnectionFactory() { HostName = rabbitMqUrl };

    return new RabbitMqConnector(factory);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/lancamento/credito", async (IMediator mediator, EfetuarLancamentoRequest request) =>
{
    var command = new LancarCreditoCommand(request.DataHora, request.Valor, request.Descricao);
    var result = await mediator.Send(command);
    return Results.Ok(new EfetuarLancamentoResponse(result));
})
.WithName("PostLancamentoCredito")
.WithOpenApi();

app.MapPost("/lancamento/debito", async (IMediator mediator, EfetuarLancamentoRequest request) =>
{
    var command = new LancarDebitoCommand(request.DataHora, request.Valor, request.Descricao);
    var result = await mediator.Send(command);
    return Results.Ok(new EfetuarLancamentoResponse(result));
})
.WithName("PostLancamentoDebito")
.WithOpenApi();

app.Run();
