using RocketFin.Api.Interfaces;

namespace RocketFin.Api.Domain
{
	public class Stock: IStock
	{
        public int Id { get; private set; }
        public string TransactionId { get; private set; }
        public string InstrumentName { get; private set; }
        public int NumberOfShares { get; private set; }
        public double Price { get; private set; }
        public DateTime TimestampUTC { get; private set; }

        public double Total {   get => NumberOfShares * Price; }

        public Stock(int id,string transactionId,string instrumentName,int numberOfShares,double price,DateTime timestampUTC)
        {

            if (numberOfShares < 1)
                throw new StockException("Number of shares cannot be less than 1");

			if (price < 0)
				throw new StockException("Price cannot be less than 0");


			Id = id;
            TransactionId = transactionId;
            InstrumentName = instrumentName;
            NumberOfShares = numberOfShares;
            Price = price;
            TimestampUTC = timestampUTC;

        }

        public static Stock PurchaseStock(string instrumentName,int numberOfShares,double price)
        {
            string transactionId = Guid.NewGuid().ToString();
            return new Stock(0, transactionId, instrumentName, numberOfShares,price,DateTime.UtcNow);

		}

	}
}
