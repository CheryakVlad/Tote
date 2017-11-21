using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Models;

namespace ToteBiz.Business.Providers
{
    public interface ITournamentProvider
    {
        Tournament GetTournament(int? id);
        IEnumerable<Tournament> GetTournamentes();
        //void Dispose();
    }
}
