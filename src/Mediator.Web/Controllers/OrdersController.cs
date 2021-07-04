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
        [Route("Orders")]
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

        [Route("Orders/{id}")]
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
        #endregion Orders
    }
}
