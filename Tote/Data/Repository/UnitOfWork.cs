using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Common.Models;

namespace Data.Repository
{
   public class UnitOfWork:IUnitOfWork
    {
        private ToteContext db;
        private SportRepository sportRepository;
        private CommandRepository commandRepository;
        private TournamentRepository tournamentRepository;
        private TourRepository tourRepository;
        private MatchRepository matchRepository;
        private RateRepository rateRepository;

        public UnitOfWork()
        {
            db = new ToteContext();
        }
        public IRepository<Sport> Sports
        {
            get
            {
                if (sportRepository == null)
                    sportRepository = new SportRepository(db);
                return sportRepository;
            }
        }

        public IRepository<Command> Commands
        {
            get
            {
                if (commandRepository == null)
                    commandRepository = new CommandRepository(db);
                return commandRepository;
            }
        }

        public IRepository<Tournament> Tournaments
        {
            get
            {
                if (tournamentRepository == null)
                    tournamentRepository = new TournamentRepository(db);
                return tournamentRepository;
            }
        }

        public IRepository<Tour> Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new TourRepository(db);
                return tourRepository;
            }
        }

        public IRepository<Match> Matches
        {
            get
            {
                if (matchRepository == null)
                    matchRepository = new MatchRepository(db);
                return matchRepository;
            }
        }

        public IRepository<Rate> Rates
        {
            get
            {
                if (rateRepository == null)
                    rateRepository = new RateRepository(db);
                return rateRepository;
            }
        }

        public void Save()
        {
           
        }

        public virtual void Dispose(bool disposing)
        {
            
        }

        public void Dispose()
        {
            /*Dispose(true);
            GC.SuppressFinalize(this);*/
        }
    }
}
