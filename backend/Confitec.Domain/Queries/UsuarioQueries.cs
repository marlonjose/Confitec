using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static Expression<Func<Usuario, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}
