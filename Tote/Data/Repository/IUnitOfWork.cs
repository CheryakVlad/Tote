using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Sport> Sports { get; }
        IRepository<Command> Commands { get; }
        IRepository<Tournament> Tournaments { get; }
        IRepository<Tour> Tours { get; }
        IRepository<Match> Matches { get; }
        IRepository<Rate> Rates { get; }
        void Save();
    }
}
