using MediatR;
using Microsoft.AspNetCore.Mvc;
using FullStack.Application.Commands;
using FullStack.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            if (orders == null || orders.Count == 0)
                return NotFound(new { Message = "Nenhuma ordem encontrada com o status especificado." });

            return Ok(orders);
        }

        /// <summary>
        /// Altera o status de uma ordem existente.
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeOrderStatus(Guid id, [FromBody] ChangeOrderStatusCommand command)
        {
            if (id != command.OrderId)
                return BadRequest(new { Message = "O ID da URL não corresponde ao ID da ordem no corpo da requisição." });

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(new { Message = "Erro ao processar a alteração do status da ordem." });

            return Ok(new { Message = "Status da ordem atualizado com sucesso!" });
        }
    }
}
