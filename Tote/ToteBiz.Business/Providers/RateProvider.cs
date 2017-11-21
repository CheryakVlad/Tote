using System.Collections.Generic;

using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Common.Models;
using System;

namespace ToteBiz.Business.Providers
{
    class RateProvider : IRateProvider
    {
        IUnitOfWork db { get; set; }

        public RateProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {
            
        }

        public Rate GetRate(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set rate id", "");
            var rate = db.Rates.Get(id.Value);
            if (rate == null)
                throw new ValidationException("Not found rate", "");

            
            return rate;
        }

        public IEnumerable<Rate> GetRates()
        {
            
            return db.Rates.GetAll();
        }

        public IList<RatesListProvider> GetRate(int? sportId, int? tournamentId)
        {
            throw new NotImplementedException();
        }
    }
}
