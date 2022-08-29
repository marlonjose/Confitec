using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Entities
{
    public class Usuario
    {
        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public enum EscolaridadeEnum
        {
            Infantil = 1,
            Fundamental = 2,
            medio = 3,
            Superior = 4
        }

        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string Sobrenome { get; private set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; private set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; private set; }
        public EscolaridadeEnum Escolaridade { get; private set; }

        public void UpdateUsuario(string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }
    }
}
