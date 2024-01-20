namespace RocketFin.Api.Application.Commands.PurchaseShare
{
	public class PurchaseShareRequest
	{
        public int NumberOfShares { get; set; }
		public string InstrumentName { get; set; }
		public double Price { get; set; }

    }
}
