using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        public string Name { get; set; }
        public int SporttId { get; set; }
        public Sport Sport { get; set; }
        public ICollection<Match> Matches { get; set; }

    }
}
