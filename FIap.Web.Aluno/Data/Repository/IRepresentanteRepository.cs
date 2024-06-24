using Fiap.Web.Aluno.Models;

namespace FIap.Web.Aluno.Data.Repository
{
    public interface IRepresentanteRepository
    {
        IEnumerable<RepresentanteModel> GetAll();
        RepresentanteModel GetById(int id);
        void Add(RepresentanteModel representante);
        void Update(RepresentanteModel representante);
        void Delete(RepresentanteModel representante);
    }
}
