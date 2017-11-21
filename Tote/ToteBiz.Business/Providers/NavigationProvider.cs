using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Common.Models;
using System;
using System.Linq;

namespace ToteBiz.Business.Providers
{
    public class NavigationProvider:INavigationProvider
    {
       IUnitOfWork db { get; set; }

        public NavigationProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {
           
        }

        public Sport GetSport(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set sports id", "");
            var sport = db.Sports.Get(id.Value);
            if (sport == null)
                throw new ValidationException("Not found sport", "");

            
            return sport;
            
        }

        public IEnumerable<Sport> GetSports()
        {            
            return db.Sports.GetAll();
            
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

        public Rate GetRate(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set rate id", "");
            var rate = db.Rates.Get(id.Value);
            if (rate == null)
                throw new ValidationException("Not found rate", "");            
            return rate;
        }

        public IList<RatesListProvider> GetRate(int? sportId,int? tournamentId)
        {          
           var rates = db.Rates.GetAll();

           
            var sports = db.Sports.GetAll();

            
            var commands = db.Commands.GetAll();

            var tournamentes = db.Tournaments.GetAll();

            
            var matches = db.Matches.GetAll();

            List<RatesListProvider> ratesList = new List<RatesListProvider>();

            if (sportId == null)
            {
                var models = from r in rates
                             join m in matches on r.MatchId equals m.MatchId
                             join cH in commands on m.CommandIdHome equals cH.CommandId
                             join cG in commands on m.CommandIdGuest equals cG.CommandId
                             join s in sports on cH.SporttId equals s.SportId
                             select new
                             {
                                 RateId = r.RateId,
                                 MatchId = r.MatchId,
                                 WinCommandHome = r.WinCommandHome,
                                 WinCommandGuest = r.WinCommandGuest,
                                 Draw = r.Draw,
                                 CommandHome = cH.Name,
                                 CommandGuest = cG.Name,
                                 Date = m.Date
                             };

                foreach (var model in models)
                {
                    ratesList.Add(new RatesListProvider
                    {
                        RateId = model.RateId,
                        MatchId = model.MatchId,
                        WinCommandGuest = model.WinCommandGuest,
                        WinCommandHome = model.WinCommandHome,
                        Date = model.Date,
                        Draw = model.Draw,
                        CommandHome = model.CommandHome,
                        CommandGuest = model.CommandGuest
                    });
                }
            }
            else
            {
                if (tournamentId == null)
                {
                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SporttId equals s.SportId
                                 where s.SportId == sportId
                                 select new
                                 {
                                     RateId = r.RateId,
                                     MatchId = r.MatchId,
                                     WinCommandHome = r.WinCommandHome,
                                     WinCommandGuest = r.WinCommandGuest,
                                     Draw = r.Draw,
                                     CommandHome = cH.Name,
                                     CommandGuest = cG.Name,
                                     Date = m.Date
                                 };

                    foreach (var model in models)
                    {
                        ratesList.Add(new RatesListProvider
                        {
                            RateId = model.RateId,
                            MatchId = model.MatchId,
                            WinCommandGuest = model.WinCommandGuest,
                            WinCommandHome = model.WinCommandHome,
                            Date = model.Date,
                            Draw = model.Draw,
                            CommandHome = model.CommandHome,
                            CommandGuest = model.CommandGuest
                        });
                    }
                }
                else
                {          
                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SporttId equals s.SportId
                                 join t in tournamentes on m.TournamentId equals t.TournamentId
                                 where t.TournamentId == tournamentId && s.SportId == sportId
                                 select new
                                 {
                                     RateId = r.RateId,
                                     MatchId = r.MatchId,
                                     WinCommandHome = r.WinCommandHome,
                                     WinCommandGuest = r.WinCommandGuest,
                                     Draw = r.Draw,
                                     CommandHome = cH.Name,
                                     CommandGuest = cG.Name,
                                     Date = m.Date
                                 };

                    foreach (var model in models)
                    {
                        ratesList.Add(new RatesListProvider
                        {
                            RateId = model.RateId,
                            MatchId = model.MatchId,
                            WinCommandGuest = model.WinCommandGuest,
                            WinCommandHome = model.WinCommandHome,
                            Date = model.Date,
                            Draw = model.Draw,
                            CommandHome = model.CommandHome,
                            CommandGuest = model.CommandGuest
                        });
                    }
                }
            }


            return ratesList;
        }

        public IEnumerable<Rate> GetRates()
        {
            var model = db.Rates.GetAll();
            return model;
        }

        public Command GetCommand(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set command id", "");
            var command = db.Commands.Get(id.Value);
            if (command == null)
                throw new ValidationException("Not found command", "");
           
            return command;
        }

        public IEnumerable<Command> GetCommands()
        {
            var model = db.Commands.GetAll();
            return model;
        }

        

    }
}
