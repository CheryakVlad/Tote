using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Data.Context;


namespace Data.Repository
{
    class MatchRepository : IRepository<Match>
    {
        private ToteContext db;

        public MatchRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Match> GetAll()
        {
            return db.Matches;
        }

        public Match Get(int id)
        {
            var selectedMatch = from Match in db.Matches
                                where Match.MatchId == id
                               select Match;
            return selectedMatch.First();
        }

        public void Create(Match Match)
        {
            db.Matches.Add(Match);
        }

        public void Update(Match Match)
        {

        }

        public IEnumerable<Match> Find(Func<Match, Boolean> predicate)
        {
            return db.Matches.Where(predicate).ToList();
        }

        public void Delete(int id)
        {

        }
    }
}
