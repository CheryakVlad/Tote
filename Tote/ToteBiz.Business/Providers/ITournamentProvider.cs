using System.Collections.Generic;
using ToteBiz.Business.Models;

namespace ToteBiz.Business.Providers
{
    public interface ITournamentProvider
    {
        TournamentBusiness GetTournament(int? id);
        IEnumerable<TournamentBusiness> GetTournamentes();
        //void Dispose();
    }
}
