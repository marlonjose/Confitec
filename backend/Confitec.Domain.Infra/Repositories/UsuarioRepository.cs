using Confitec.Domain.Entities;
using Confitec.Domain.Infra.Contexts;
using Confitec.Domain.Queries;
using Confitec.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario
               .AsNoTracking()
               .OrderBy(x => x.Id);
        }

        public Usuario GetById(int id)
        {
            return _context
                .Usuario
                .FirstOrDefault(UsuarioQueries.GetById(id));
        }

        public void Update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context
                .Usuario
                .FirstOrDefault(UsuarioQueries.GetById(id));
            _context.Usuario.Remove(user);
            _context.SaveChanges();
        }
    }
}
