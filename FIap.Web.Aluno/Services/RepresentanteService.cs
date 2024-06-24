using Fiap.Web.Aluno.Models;
using FIap.Web.Aluno.Data.Repository;

namespace FIap.Web.Aluno.Services
{
    public class RepresentanteService : IRepresentanteService
    {

        private readonly IRepresentanteRepository _repository;

        public RepresentanteService(IRepresentanteRepository representante)
        {
            _repository = representante;
        }

        public void Add(RepresentanteModel representante) => _repository.Add(representante);

        public void Delete(int id)
        {
            var cliente = _repository.GetById(id);
            if(cliente != null)
            {
                _repository.Delete(cliente);
            }
        }

        public IEnumerable<RepresentanteModel> GetAll() => _repository.GetAll();

        public RepresentanteModel GetId(int id) => _repository.GetById(id);

        public void Update(RepresentanteModel representante) => _repository?.Update(representante);
    }
}
