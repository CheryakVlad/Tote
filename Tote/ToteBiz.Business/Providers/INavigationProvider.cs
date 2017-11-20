
using System.Collections.Generic;
using ToteBiz.Business.Models;

namespace ToteBiz.Business.Providers
{
    public interface INavigationProvider:ITournamentProvider, IMatchProvider, IRateProvider,ICommandProvider
    {        
        SportBusiness GetSport(int? id);
        IEnumerable<SportBusiness> GetSports();
        void Dispose();

        /*TournamentBusiness GetTournament(int? id);
        IEnumerable<TournamentBusiness> GetTournamentes();*/
    }
}
