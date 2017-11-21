using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Data.Context;

namespace Data.Repository
{
    class TournamentRepository : IRepository<Tournament>
    {
        private ToteContext db;

        public TournamentRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tournament> GetAll()
        {
            return db.Tournaments;
        }

        public Tournament Get(int id)
        {
            var selectedTournament = from Tournament in db.Tournaments
                                     where Tournament.TournamentId == id
                                  select Tournament;
            return selectedTournament.First();
        }

        public void Create(Tournament Tournament)
        {
            db.Tournaments.Add(Tournament);
        }

        public void Update(Tournament Tournament)
        {

        }

        public IEnumerable<Tournament> Find(Func<Tournament, Boolean> predicate)
        {
            return db.Tournaments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {

        }
    }
}
