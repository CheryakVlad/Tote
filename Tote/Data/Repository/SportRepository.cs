using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Data.Context;

namespace Data.Repository
{
    class SportRepository:IRepository<Sport>
    {
        private ToteContext db;

        public SportRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sport> GetAll()
        {
            return db.Sports;
        }

        public Sport Get(int id)
        {
            var selectedSport = from sport in db.Sports
                                where sport.SportId == id
                                select sport;
            return selectedSport.First();
        }

        public void Create(Sport sport)
        {
            db.Sports.Add(sport);
        }

        public void Update(Sport sport)
        {
            
        }

        public IEnumerable<Sport> Find(Func<Sport, Boolean> predicate)
        {
            return db.Sports.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            
        }
    }
}
