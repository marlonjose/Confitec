using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        Usuario GetById(int id);
        IEnumerable<Usuario> GetAll();
        void Delete(Usuario usuario);
    }
}
