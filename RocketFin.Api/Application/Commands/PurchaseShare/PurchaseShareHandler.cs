using MediatR;
using RocketFin.Api.Application.Queries.GetInstruments;
using RocketFin.Api.Domain;
using RocketFin.Api.Interfaces;

namespace RocketFin.Api.Application.Commands.PurchaseShare
{
	public class PurchaseShareHandler : IRequestHandler<PurchaseShareCommand, PurchaseShareResponse>
	{
		private readonly IStockRepository _stockRepository;
		public PurchaseShareHandler(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
		}

		public async Task<PurchaseShareResponse> Handle(PurchaseShareCommand request, CancellationToken cancellationToken)
		{
			var stock = Stock.PurchaseStock(request.PurchaseShareRequest.InstrumentName, request.PurchaseShareRequest.NumberOfShares, request.PurchaseShareRequest.Price);
			await _stockRepository.CreateAsync(stock);

			return new PurchaseShareResponse
			{
				TransactionNumber = stock.TransactionId
			};
			
		}
	}
}
