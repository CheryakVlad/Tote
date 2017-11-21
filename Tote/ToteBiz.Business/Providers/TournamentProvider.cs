using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Common.Models;
namespace ToteBiz.Business.Providers
{
    class TournamentProvider : ITournamentProvider
    {
        IUnitOfWork db { get; set; }

        public TournamentProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {

        }

        public Tournament GetTournament(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set Tournament id", "");
            var tournament = db.Tournaments.Get(id.Value);
            if (tournament == null)
                throw new ValidationException("Not found Tournament", "");

            
            return tournament;
        }

        public IEnumerable<Tournament> GetTournamentes()
        {
            
            return db.Tournaments.GetAll();
        }

        
    }
}
