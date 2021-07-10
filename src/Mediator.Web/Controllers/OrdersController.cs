using Mapster;
using Mediator.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator.Web.Controllers
{
    [Route("Orders")]
    public class OrdersController : Controller
    {
        #region Properties
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        #endregion Properties

        #region Constructor
        public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion Constructor

        #region Orders        
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetOrdersQuery
                {
                    StartDate = DateTime.Parse("01/01/2021"),
                    EndDate = DateTime.Parse("03/01/2021"),
                    OrderStatuses = new List<string> { "Shipped", "Delivered" }
                });

                if (response == null || !response.Any())
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured fetching orders");
                return StatusCode(500, "Error occurred fetching orders");
            }
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOrdersByIdQuery
                {
                    OrderId = id
                });

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured fetching orders");
                return StatusCode(500, "Error occurred fetching orders");
            }
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Order order)
        {
            try
            {
                if (order == null)
                    return BadRequest();

                var command = order.Adapt<AddOrderCommand>();
                await _mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding order");
                return StatusCode(500, "Error adding order");
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]OrderInfo order)
        {
            try
            {
                if (order == null)
                    return BadRequest();

                var command = order.Adapt<UpdateOrderCommand>();
                await _mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding order");
                return StatusCode(500, "Error adding order");
            }
        }
        #endregion Orders
    }
}
