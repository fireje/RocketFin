namespace RocketFin.Api.Application.Queries.GetInstruments
{
	public class InstrumentResponse
	{
        public string? Name { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double CurrentPrice { get; set; }
        public double ChangeInValueCurrentDay { get; set; }
		public double ChangeInPercentageCurrentDay { get; set; }
	}
}
