
using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Models;

namespace ToteBiz.Business.Providers
{
    public interface INavigationProvider:ITournamentProvider, IMatchProvider, IRateProvider,ICommandProvider
    {        
        Sport GetSport(int? id);
        IEnumerable<Sport> GetSports();
        void Dispose();

        /*TournamentBusiness GetTournament(int? id);
        IEnumerable<TournamentBusiness> GetTournamentes();*/
    }
}
