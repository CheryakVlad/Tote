using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int CommandIdHome { get; set; }
        public int CommandIdGuest { get; set; }
        public Command Command { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public ICollection<Rate> Rate{ get; set; }
    }
}
