using MediatR;
using RocketFin.Api.Infrastructure.Services;

namespace RocketFin.Api.Application.Queries.GetInstruments
{
	public class InstrumentHandler : IRequestHandler<GetInstrumentQuery, InstrumentResponse>
	{
		private readonly IYHFinanceAPI _yHFinanceAPI;

		public InstrumentHandler(IYHFinanceAPI yHFinanceAPI)
		{
			_yHFinanceAPI = yHFinanceAPI;
		}

		public async Task<InstrumentResponse> Handle(GetInstrumentQuery request, CancellationToken cancellationToken)
		{
		   var apiQuoteResult = await _yHFinanceAPI.GetQuote("US", "en", request.ticker);
		   var filteredResult =  apiQuoteResult.quoteResponse.result.FirstOrDefault();

			var marketOpenPrice = filteredResult.regularMarketOpen;

			var changeInPerc = (filteredResult.regularMarketPrice - marketOpenPrice) / marketOpenPrice * 100;
			var changeInvalue = filteredResult.regularMarketPrice - marketOpenPrice;

		   var instrument = new InstrumentResponse()
		   {
			   Name = filteredResult.shortName,
			   Bid = filteredResult.bid,
			   Ask = filteredResult.ask,
			   CurrentPrice = filteredResult.regularMarketPrice,
			   ChangeInPercentageCurrentDay = changeInPerc,
			   ChangeInValueCurrentDay = changeInvalue
		   };


			return instrument;
		}
	}
}
