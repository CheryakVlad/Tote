﻿using System;

namespace ToteBiz.Business.Models
{
    public  class MatchBusiness
    {
        public int MatchId { get; set; }
        public int CommandIdHome { get; set; }
        public int CommandIdGuest { get; set; }        
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int TournamentId { get; set; }        
        public int TourId { get; set; }
        
    }
}
