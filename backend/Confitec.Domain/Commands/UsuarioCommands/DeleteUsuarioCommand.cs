using Confitec.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Commands.UsuarioCommands
{
    public class DeleteUsuarioCommand : ICommand
    {
        public DeleteUsuarioCommand(int id)
        {
            Id = id;
        }

        [Key]

        [Required(ErrorMessage = "O campo Id é obrigatório para exclusão")]
        public int Id { get; private set; }
    }
}
