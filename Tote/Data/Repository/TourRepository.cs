using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Data.Context;

namespace Data.Repository
{
    class TourRepository : IRepository<Tour>
    {
        private ToteContext db;

        public TourRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tour> GetAll()
        {
            return db.Tours;
        }

        public Tour Get(int id)
        {
            var selectedTour = from Tour in db.Tours
                                     where Tour.TourId == id
                                     select Tour;
            return selectedTour.First();
        }

        public void Create(Tour Tour)
        {
            db.Tours.Add(Tour);
        }

        public void Update(Tour Tour)
        {

        }

        public IEnumerable<Tour> Find(Func<Tour, Boolean> predicate)
        {
            return db.Tours.Where(predicate).ToList();
        }

        public void Delete(int id)
        {

        }
    }
}
