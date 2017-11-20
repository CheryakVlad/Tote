using System.Collections.Generic;

namespace Data.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Name { get; set; }
        public ICollection<Command> Commands;
        public ICollection<Tournament> Tournaments;
    }
}
