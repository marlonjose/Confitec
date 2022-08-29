using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Confitec.Domain.Entities.Usuario;

namespace Confitec.Domain.Commands.UsuarioCommands
{
    public class UpdateUsuarioCommand : ICommand
    {
        public UpdateUsuarioCommand(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; private set; }

        [DataType(DataType.Date)]
        [BirthdateValidator(ErrorMessage = "Data de nascimento maior que a data atual")]
        public DateTime DataNascimento { get; private set; }
        public EscolaridadeEnum Escolaridade { get; private set; }
    }
}
