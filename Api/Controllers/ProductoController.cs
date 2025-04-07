using Application.Common;
using Application.UseCases.ProductoCreate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controlador de Usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductoController(ISender _sender)
        {
            this._sender = _sender;
        }


        /// <summary>
        /// Metodo para la creacion asignacion de la tarea      
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductoRequest request)
        {            var user = await _sender.Send(request);
            return Ok(user);
        }



    }
}
