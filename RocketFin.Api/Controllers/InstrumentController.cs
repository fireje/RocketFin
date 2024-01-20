using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketFin.Api.Application.Queries.GetInstruments;
using RocketFin.Api.Infrastructure.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RocketFin.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InstrumentController : ControllerBase
	{
		private readonly ILogger<InstrumentController> _logger;
		private readonly IMediator _mediator;


		public InstrumentController(ILogger<InstrumentController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		
		[HttpGet]
		[ProducesResponseType(typeof(InstrumentResponse), StatusCodes.Status200OK)]
		[SwaggerOperation(Description = "Retreives the instrument details")]
		public async Task<IActionResult> GetInstrument(string ticker)
		{
			try
			{
				var response = await _mediator.Send(new GetInstrumentQuery(ticker));
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}
		}
	}
}
