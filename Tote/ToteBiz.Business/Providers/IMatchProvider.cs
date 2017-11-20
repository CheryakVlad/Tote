using System.Collections.Generic;
using ToteBiz.Business.Models;

namespace ToteBiz.Business.Providers
{
    public interface IMatchProvider
    {
        MatchBusiness GetMatch(int? id);
        IEnumerable<MatchBusiness> GetMatches();
        //void Dispose();
    }
}
