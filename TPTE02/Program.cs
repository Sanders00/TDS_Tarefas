using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProdutoStore.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Produtos") ?? "Data Source=Produtos.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<ProdutoDb>(connectionString);
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
//GET
app.MapGet("/produtos", async (ProdutoDb db) => await db.Produtos.ToListAsync());

//POST
app.MapPost("/produtos", async (ProdutoDb db, Produto produto) =>
{
    await db.Produtos.AddAsync(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/produto/{produto.Id}", produto);
});

//GET SINGLE
app.MapGet("/produto/{id}", async (ProdutoDb db, int id) => await db.Produtos.FindAsync(id));

//PUT
app.MapPut("/produto/{id}", async (ProdutoDb db, Produto updateproduto, int id) =>
{
      var produto = await db.Produtos.FindAsync(id);
      if (produto is null) return Results.NotFound();
      produto.Name = updateproduto.Name;
      produto.Price = updateproduto.Price;
      produto.Quantity = updateproduto.Quantity;
      await db.SaveChangesAsync();
      return Results.NoContent();
});

//DELETE
app.MapDelete("/produto/{id}", async (ProdutoDb db, int id) =>
{
   var produto = await db.Produtos.FindAsync(id);
   if (produto is null)
   {
      return Results.NotFound();
   }
   db.Produtos.Remove(produto);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.Run();
