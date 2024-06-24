using Fiap.Web.Aluno.Models;
namespace Fiap.Web.Aluno.Data.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<ClienteModel> GetAll();
        ClienteModel GetById(int id);
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(ClienteModel cliente);
    }
}