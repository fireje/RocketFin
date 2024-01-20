using MediatR;
using RocketFin.Api.Application.Queries.GetInstruments;

namespace RocketFin.Api.Application.Queries.GetPortfolio
{
	public record GetPortfolioQuery(string ticker) : IRequest<List<PortfolioResponse>>;
}
