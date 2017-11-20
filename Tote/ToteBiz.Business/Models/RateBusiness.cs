using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToteBiz.Business.Models
{
    public class RateBusiness
    {
        public int RateId { get; set; }
        public double WinCommandHome { get; set; }
        public double WinCommandGuest { get; set; }
        public double Draw { get; set; }
        public int MatchId { get; set; }
       
    }
}
