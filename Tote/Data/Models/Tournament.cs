using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
