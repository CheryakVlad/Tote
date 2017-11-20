using System.Collections.Generic;
using AutoMapper;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Data.Models;

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

        public TournamentBusiness GetTournament(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set Tournament id", "");
            var tournament = db.Tournaments.Get(id.Value);
            if (tournament == null)
                throw new ValidationException("Not found Tournament", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tournament, TournamentBusiness>()).CreateMapper();

            var model = mapper.Map<Tournament, TournamentBusiness>(tournament);
            return model;
        }

        public IEnumerable<TournamentBusiness> GetTournamentes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tournament, TournamentBusiness>()).CreateMapper();

            var model = mapper.Map<IEnumerable<Tournament>, List<TournamentBusiness>>(db.Tournaments.GetAll());
            return model;
        }

        
    }
}
