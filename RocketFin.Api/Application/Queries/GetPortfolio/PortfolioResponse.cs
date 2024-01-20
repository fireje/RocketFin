using Microsoft.VisualBasic;

namespace RocketFin.Api.Application.Queries.GetPortfolio
{
	public class PortfolioResponse
	{
        public string TransactionId { get; set; }
        public string InstrumentName { get; set; }
        public int NumberOfShares { get; set; }
		public double PricePerShare { get; set; }
		public double TotalPrice { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
