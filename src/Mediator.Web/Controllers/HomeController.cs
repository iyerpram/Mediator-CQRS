using Mediator.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Mediator.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Mediator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            try
            {
                var response = await _mediator.Send(new GetOrdersQuery
                {
                    OrderId = Guid.NewGuid(),
                    OrderDate = DateTime.Now.AddDays(-10),
                    OrderStatus = "Shipped"
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
