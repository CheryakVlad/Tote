using System.Collections.Generic;

using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;

using Common.Models;

namespace ToteBiz.Business.Providers
{
    class MatchProvider : IMatchProvider
    {
        IUnitOfWork db { get; set; }

        public MatchProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {

        }

        public Match GetMatch(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set Match id", "");
            var match = db.Matches.Get(id.Value);
            if (match == null)
                throw new ValidationException("Not found Match", "");

            
            return match;
        }

        public IEnumerable<Match> GetMatches()
        {            
            return db.Matches.GetAll();
        }
    }
}
