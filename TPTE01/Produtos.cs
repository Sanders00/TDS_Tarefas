namespace Produtos.DB; 

 public record Produto 
 {
   public int Id {get; set;} 
   public string ? Nome { get; set; }
   public string ? Descricao { get; set; }
   public int ? Quantidade { get; set; }
   public float ? Preco { get; set; }
   public string ? CodigoBarras { get; set; }
 }

 public class ProdutoDB
 {
   private static List<Produto> _produtos = new List<Produto>()
   {
     new Produto {Id = 0, Nome="Pizza Calabresa", Descricao="Pizza recheada com calabresa", Quantidade=1, Preco=25.00f, CodigoBarras="1234567890"},
     new Produto {Id = 1, Nome="Sabonete", Descricao="Sabonete liquido de lavanda", Quantidade=5, Preco=15.00f, CodigoBarras="0987654321"}
   };

   public static List<Produto> GetProdutos() 
   {
     return _produtos;
   } 

   public static Produto ? GetProduto(int id) 
   {
     return _produtos.SingleOrDefault(produto => produto.Id == id);
   } 

   public static Produto CreateProduto(Produto produto) 
   {
     _produtos.Add(produto);
     return produto;
   }

   public static Produto UpdateProduto(Produto update) 
   {
     _produtos = _produtos.Select(produto =>
     {
       if (produto.Id == update.Id)
       {
         produto.Nome = update.Nome;
         produto.Descricao = update.Descricao;
         produto.Quantidade = update.Quantidade;
         produto.Preco = update.Preco;
         produto.CodigoBarras = update.CodigoBarras;
       }
       return produto;
     }).ToList();
     return update;
   }

   public static void RemoveProduto(int id)
   {
     _produtos = _produtos.FindAll(produto => produto.Id != id).ToList();
   }
 }