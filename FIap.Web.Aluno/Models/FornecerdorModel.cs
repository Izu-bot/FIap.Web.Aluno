using System.Runtime.InteropServices.Marshalling;

namespace FIap.Web.Aluno.Models
{
    public class FornecerdorModel
    {
        public int FornecedorId { get; set; }
        public string? Nome { get; set; }

        // Relacionamento com o produto
        public List<ProdutoModel>? Produtos { get; set; }
    }
}
