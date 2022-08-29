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

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
                    [FromBody] UpdateUsuarioCommand command,
                    [FromServices] UsuarioHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete(
            [FromBody] DeleteUsuarioCommand command,
            [FromServices] UsuarioHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
