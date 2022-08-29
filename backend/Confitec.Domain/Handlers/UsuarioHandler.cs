using Confitec.Domain.Commands;
using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Commands.UsuarioCommands;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Handlers
{
    public class UsuarioHandler : 
        IHandler<CreateUsuarioCommand>,
        IHandler<UpdateUsuarioCommand>,
        IHandler<DeleteUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUsuarioCommand command)
        {
            var usuario = new Usuario(command.Id, command.Nome, command.Sobrenome, command.Email, command.DataNascimento, command.Escolaridade);

            _repository.Create(usuario);

            return new GenericCommandResult(true, "Usuário salvo", usuario);
        }

        public ICommandResult Handle(UpdateUsuarioCommand command)
        {
            var usuario = _repository.GetById(command.Id);

            usuario.UpdateUsuario(command.Nome, command.Sobrenome, command.Email, command.DataNascimento, command.Escolaridade);

            _repository.Update(usuario);

            return new GenericCommandResult(true, "Usuário alterado com sucesso", usuario);
        }

        public ICommandResult Handle(DeleteUsuarioCommand command)
        {
            var usuario = _repository.GetById(command.Id);

            _repository.Delete(usuario);

            return new GenericCommandResult(true, "Usuário removido com sucesso");
        }
    }
}
