using System.Collections.Generic;
using ToteBiz.Business.Models;

namespace ToteBiz.Business.Providers
{
    public interface IRateProvider
    {
        RateBusiness GetRate(int? id);
        IEnumerable<RateBusiness> GetRates();
       // void Dispose();
    }
}
