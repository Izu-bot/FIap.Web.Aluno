using Fiap.Web.Aluno.Models;
using Microsoft.EntityFrameworkCore;

namespace FIap.Web.Aluno.Data.Repository
{
    public class RepresentanteRepository : IRepresentanteRepository
    {

        private readonly DataBaseContext _context;

        public RepresentanteRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public void Add(RepresentanteModel representante)
        {
            _context.Representantes.Add(representante);
            _context.SaveChanges();
        }

        public void Delete(RepresentanteModel representante)
        {
            _context.Representantes.Remove(representante);
            _context.SaveChanges();
        }

        public IEnumerable<RepresentanteModel> GetAll() => _context.Representantes.ToList();

        public RepresentanteModel GetById(int id) => _context.Representantes.Find(id);

        public void Update(RepresentanteModel representante)
        {
            _context.Representantes.Update(representante);
            _context.SaveChanges();
        }
    }
}
