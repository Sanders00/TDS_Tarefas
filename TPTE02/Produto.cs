using Microsoft.EntityFrameworkCore;

namespace ProdutoStore.Models 
{
    public class Produto
    {
          public int Id { get; set; }
          public string? Name { get; set; }
          public float? Price { get; set; }
          public int? Quantity { get; set; }
    }

    class ProdutoDb : DbContext
    {
        public ProdutoDb(DbContextOptions options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; } = null!;
    }
}