using Fiap.Web.Aluno.Data.Repository;
using Fiap.Web.Aluno.Models;
using FIap.Web.Aluno.Data;
using Microsoft.EntityFrameworkCore;
public class ClienteRepository : IClienteRepository
{
    private readonly DataBaseContext _context;
    public ClienteRepository(DataBaseContext context)
    {
        _context = context;
    }
    public IEnumerable<ClienteModel> GetAll() => _context.Cliente.Include(c => c.Representante).ToList();
    public ClienteModel GetById(int id) => _context.Cliente.Find(id);
    public void Add(ClienteModel cliente)
    {
        _context.Cliente.Add(cliente);
        _context.SaveChanges();
    }
    public void Update(ClienteModel cliente)
    {
        _context.Update(cliente);
        _context.SaveChanges();
    }
    public void Delete(ClienteModel cliente)
    {
        _context.Cliente.Remove(cliente);
        _context.SaveChanges();
    }
}