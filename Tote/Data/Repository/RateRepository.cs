using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Data.Context;

namespace Data.Repository
{
    class RateRepository : IRepository<Rate>
    {
        private ToteContext db;

        public RateRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Rate> GetAll()
        {
            return db.Rates;
        }

        public Rate Get(int id)
        {
            var selectedRate = from Rate in db.Rates
                                where Rate.MatchId == id
                                select Rate;
            return selectedRate.First();
        }

        public void Create(Rate Rate)
        {
            db.Rates.Add(Rate);
        }

        public void Update(Rate Rate)
        {

        }

        public IEnumerable<Rate> Find(Func<Rate, Boolean> predicate)
        {
            return db.Rates.Where(predicate).ToList();
        }

        public void Delete(int id)
        {

        }

    }
}
