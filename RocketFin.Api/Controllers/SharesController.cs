using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketFin.Api.Application.Commands.PurchaseShare;
using RocketFin.Api.Application.Queries.GetPortfolio;
using RocketFin.Api.Domain;
using RocketFin.Api.Persistance.Context;
using RocketFin.Api.Persistance.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace RocketFin.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SharesController : ControllerBase
	{

		private readonly ILogger<InstrumentController> _logger;
		private readonly IMediator _mediator;
		private readonly RocketFinDbContext _context;

		public SharesController(ILogger<InstrumentController> logger, IMediator mediator, RocketFinDbContext rocketFinDbContext)
		{
			_logger = logger;
			_mediator = mediator;
			_context = rocketFinDbContext;
		}

		[HttpGet]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		[SwaggerOperation(Description = "Retreives the portfolio details")]
		public async Task<IActionResult> GetPortfolio(string? ticker)
		{
			try
			{
				var response = await _mediator.Send(new GetPortfolioQuery(ticker));
				return Ok(response);
			}
			catch (Exception ex)
			{

				return StatusCode(500);
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		[SwaggerOperation(Description = "Purchase a stock")]
		public async Task<IActionResult> PurchaseStock([FromBody] PurchaseShareRequest purchaseShareRequest )
		{
			try
			{
				var response = await _mediator.Send(new PurchaseShareCommand(purchaseShareRequest));
				return Ok(response);
			}catch(StockException ex) 
			{
				return BadRequest(ex.Message);
			}
			catch(Exception ex)
			{
				return StatusCode(500);
			}
			
		}


	}
}
