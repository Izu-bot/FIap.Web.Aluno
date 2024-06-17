namespace FIap.Web.Aluno.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public String? Nome { get; set; }
        public decimal Preco {  get; set; }
        public string? Descricao { get; set; }

        // Relacionamento com fornecedor 
        public int FornecedorId { get; set; }
        public FornecerdorModel? Fornecedor { get; set; }

        // Relacionamento com pedido
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }
    }
}
