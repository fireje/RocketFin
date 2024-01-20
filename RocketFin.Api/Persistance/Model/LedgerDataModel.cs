using System.ComponentModel.DataAnnotations;

namespace RocketFin.Api.Persistance.Model
{
	public class LedgerDataModel
	{
        [Key]
        public int Id { get; set; }

		[MaxLength(50)]
		public string TransactionId { get; set; }
		public DateTime TransactionTimeStampUTC { get; set; }
		public string InstrumentName { get; set; }
		public int NumberOfShares { get; set; }
		public double Price { get; set; }
    }
}
