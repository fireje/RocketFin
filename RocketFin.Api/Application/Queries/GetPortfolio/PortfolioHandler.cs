using MediatR;
using RocketFin.Api.Infrastructure.Services;
using RocketFin.Api.Interfaces;

namespace RocketFin.Api.Application.Queries.GetPortfolio
{
	public class PortfolioHandler : IRequestHandler<GetPortfolioQuery, List<PortfolioResponse>>
	{
		private readonly IStockRepository _stockRepository;

		public PortfolioHandler(IStockRepository stockRepository) {
			_stockRepository = stockRepository;
		}

		public async Task<List<PortfolioResponse>> Handle(GetPortfolioQuery request, CancellationToken cancellationToken)
		{
			var stocks =  await _stockRepository.GetAllAsync();
			var portoflio = new List<PortfolioResponse>();
			
			foreach (var stock in stocks)
			{
				portoflio.Add(
					new PortfolioResponse() { InstrumentName = stock.InstrumentName,
						NumberOfShares = stock.NumberOfShares, 
						PricePerShare = stock.Price, 
						Timestamp = stock.TimestampUTC, 
						TotalPrice = stock.Total, 
						TransactionId = stock.TransactionId });
			}

			if(!string.IsNullOrEmpty(request.ticker))
			{
				portoflio = portoflio.Where(x => x.InstrumentName.ToLower().Contains(request.ticker.ToLower())).ToList();
			}

			return portoflio;
		}
	}
}
