using Fiap.Web.Aluno.Models;

namespace FIap.Web.Aluno.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        
        // Relacionamento com cliente
        public int ClienteId { get; set; }
        public ClienteModel? Cliente { get; set; }

        // Relacionamento com loja
        public int LojaId { get; set; }
        public LojaModel? Loja { get; set; }

        // Relacionamento com produto
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }

    }
}
