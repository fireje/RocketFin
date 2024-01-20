using MediatR;

namespace RocketFin.Api.Application.Commands.PurchaseShare
{
	public record PurchaseShareCommand(PurchaseShareRequest PurchaseShareRequest) : IRequest<PurchaseShareResponse>;
}
