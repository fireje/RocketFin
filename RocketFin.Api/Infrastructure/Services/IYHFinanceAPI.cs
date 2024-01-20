using Refit;
using RocketFin.Api.Infrastructure.Services.Models;

namespace RocketFin.Api.Infrastructure.Services
{
	public interface IYHFinanceAPI
	{
		[Get("/v6/finance/quote")]
		Task<QuoteRootResponse> GetQuote([Query] string region, [Query] string lang, [Query] string symbols);
	}
}
