using System;

namespace ToteBiz.Business.Providers
{
    public class RatesListProvider
    {
        public int RateId { get; set; }
        public double WinCommandHome { get; set; }
        public double WinCommandGuest { get; set; }
        public double Draw { get; set; }
        public int MatchId { get; set; }
        public string CommandHome { get; set; }
        public string CommandGuest { get; set; }
        public DateTime Date { get; set; }
    }
}
