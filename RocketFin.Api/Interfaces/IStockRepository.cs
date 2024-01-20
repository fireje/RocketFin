using RocketFin.Api.Domain;

namespace RocketFin.Api.Interfaces
{
	public interface IStockRepository
	{
		Task<List<Stock>> GetAllAsync();
		Task<Stock> CreateAsync(Stock stockModel);
	}
}
