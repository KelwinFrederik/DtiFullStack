using MediatR;
using Microsoft.AspNetCore.Mvc;
using FullStack.Application.Commands;
using FullStack.Application.Queries;

namespace FullStack.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtém uma lista de ordens filtradas pelo status (Pendente, Aceito, Recusado).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetOrdersByStatus([FromQuery] int status)
        {
            var query = new GetOrdersByStatusQuery(status);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        /// <summary>
        /// Altera o status de uma ordem existente.
        /// </summary>
        [HttpPut("status")]
        public async Task<IActionResult> ChangeOrderStatus([FromBody] ChangeOrderStatusCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest(new { Message = "Erro ao processar a alteração do status da ordem." });

            return Ok(new { Message = "Status da ordem atualizado com sucesso!" });
        }
    }
}
