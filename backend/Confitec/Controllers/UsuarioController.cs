using Confitec.Domain.Commands;
using Confitec.Domain.Commands.UsuarioCommands;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers;
using Confitec.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Domain.API.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
                            [FromBody] CreateUsuarioCommand command,
                            [FromServices] UsuarioHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Usuario> GetAll(
                [FromServices] IUsuarioRepository repository
)
        {
            return repository.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public Usuario GetById(
            int id,
            [FromServices] IUsuarioRepository repository
)
        {
            return repository.GetById(id);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
                    [FromBody] UpdateUsuarioCommand command,
                    [FromServices] UsuarioHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(
            int id,
            [FromServices] IUsuarioRepository repository
)
        {
            repository.Delete(id);
        }
    }
}
