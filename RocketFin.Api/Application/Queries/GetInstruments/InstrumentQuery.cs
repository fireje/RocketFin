using MediatR;

namespace RocketFin.Api.Application.Queries.GetInstruments
{
	public record GetInstrumentQuery(string ticker) : IRequest<InstrumentResponse>;
}
