using Microsoft.EntityFrameworkCore;
using RocketFin.Api.Domain;
using RocketFin.Api.Infrastructure.Services;
using RocketFin.Api.Interfaces;
using RocketFin.Api.Persistance.Context;
using RocketFin.Api.Persistance.Model;

namespace RocketFin.Api.Persistance.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly RocketFinDbContext _context;

		public StockRepository(RocketFinDbContext context)
		{
			_context = context;
		}

		public async Task<List<Stock>> GetAllAsync()
		{
			var stocks = await _context.Ledgers.ToListAsync();

			var returnList = new List<Stock>();
			stocks.ForEach(x => returnList.Add(new Stock(x.Id,x.TransactionId,x.InstrumentName,x.NumberOfShares,x.Price,x.TransactionTimeStampUTC)));

			return returnList;
		}

		public async Task<Stock> CreateAsync(Stock stockModel)
		{
			var dataModel = new LedgerDataModel()
			{
				InstrumentName = stockModel.InstrumentName,
				NumberOfShares = stockModel.NumberOfShares,
				TransactionId = stockModel.TransactionId,
				Id = stockModel.Id,
				Price = stockModel.Price,
				TransactionTimeStampUTC = stockModel.TimestampUTC
			};

			await _context.Ledgers.AddAsync(dataModel);
			await _context.SaveChangesAsync();
			return stockModel;
		}

	}
}
