using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Models;

namespace ToteBiz.Business.Providers
{
    public interface IMatchProvider
    {
        Match GetMatch(int? id);
        IEnumerable<Match> GetMatches();
        //void Dispose();
    }
}
