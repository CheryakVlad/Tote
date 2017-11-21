using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Models;

namespace ToteBiz.Business.Providers
{
    public interface IRateProvider
    {
        Rate GetRate(int? id);
        IEnumerable<Rate> GetRates();

        IList<RatesListProvider> GetRate(int? sportId, int? tournamentId);
       // void Dispose();
    }
}
