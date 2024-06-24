using Fiap.Web.Aluno.Models;

namespace FIap.Web.Aluno.Services
{
    public interface IRepresentanteService
    {
        IEnumerable<RepresentanteModel> GetAll();
        RepresentanteModel GetId(int id);
        void Add(RepresentanteModel representante);
        void Update(RepresentanteModel representante);
        void Delete(int id);
    }
}
