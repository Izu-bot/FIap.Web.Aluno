namespace FIap.Web.Aluno.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }

        // Relacionamento com o pedido
        public List<PedidoModel>? Pedidos { get; set; }
    }
}
