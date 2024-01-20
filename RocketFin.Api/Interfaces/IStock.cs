namespace RocketFin.Api.Interfaces
{
	public class IStock
	{
		 int Id { get;  }
		 string TransactionId { get;  }
		 string InstrumentName { get;  }
		 int NumberOfShares { get; }
		 double Price { get; }
		 DateTime TimestampUTC { get;  }
		 double Total { get; }
	}
}
