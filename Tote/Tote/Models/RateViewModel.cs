namespace Tote.Models
{
    public class RateViewModel
    {
        public int RateId { get; set; }
        public double WinCommandHome { get; set; }
        public double WinCommandGuest { get; set; }
        public double Draw { get; set; }
        public int MatchId { get; set; }        
    }
}