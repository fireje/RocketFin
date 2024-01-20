using Microsoft.AspNetCore.Cors.Infrastructure;
using RocketFin.Api.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RocketFin.Test
{
	public class StockTest
	{
		public Stock _stock { get; private set; }
		public StockTest() { 
			_stock = new Stock(1,"123456","APPL",3,20,DateTime.Now);
		}



		[Fact]
		public void TotalPriceIsWorkingCorrect()
		{
			var totalPrice = _stock.Total;
			Assert.Equal(60, totalPrice);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		[InlineData(-100)]
		public void ThrowExceptionIfNumberOfSharesIsLessThanOne(int numberOfShares)
		{

			var action = () => new Stock(1, "123456", "APPL", numberOfShares, 20, DateTime.Now);
			var exception = Assert.Throws<StockException>(action);
			Assert.Equal("Number of shares cannot be less than 1", exception.Message);
		}


		[Theory]
		[InlineData(-0.1)]
		[InlineData(-1)]
		[InlineData(-100)]
		[InlineData(-0.5)]
		public void ThrowExceptionIfPriceIsLessThan0(double price)
		{

			var action = () => new Stock(1, "123456", "APPL", 2, price, DateTime.Now);
			var exception = Assert.Throws<StockException>(action);
			Assert.Equal("Price cannot be less than 0", exception.Message);
		}
	}

}