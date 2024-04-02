using Microsoft.OpenApi.Models;
using Produtos.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/produtos/{id}", (int id) => ProdutoDB.GetProduto(id));
app.MapGet("/produtos", () => ProdutoDB.GetProdutos());
app.MapPost("/produtos", (Produto produto) => ProdutoDB.CreateProduto(produto));
app.MapPut("/produtos", (Produto produto) => ProdutoDB.UpdateProduto(produto));
app.MapDelete("/produtos/{id}", (int id) => ProdutoDB.RemoveProduto(id));

app.Run();



