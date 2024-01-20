namespace RocketFin.Api.Domain
{
	public class StockException : Exception
	{
		public StockException()
		{
		}

		public StockException(string message)
			: base(message)
		{
		}
	}
}
