using System.Collections.Generic;
using AutoMapper;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Data.Models;
using System;

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

        public SportBusiness GetSport(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set sports id", "");
            var sport = db.Sports.Get(id.Value);
            if (sport == null)
                throw new ValidationException("Not found sport", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sport, SportBusiness>()).CreateMapper();

            var model = mapper.Map<Sport, SportBusiness>(sport);
            return model;
            
        }

        public IEnumerable<SportBusiness> GetSports()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sport, SportBusiness>()).CreateMapper();
            var model = mapper.Map<IEnumerable<Sport>, List<SportBusiness>>(db.Sports.GetAll());
            return model;
            
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

        public MatchBusiness GetMatch(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set Match id", "");
            var match = db.Matches.Get(id.Value);
            if (match == null)
                throw new ValidationException("Not found Match", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchBusiness>()).CreateMapper();

            var model = mapper.Map<Match, MatchBusiness>(match);
            return model;
        }

        public IEnumerable<MatchBusiness> GetMatches()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchBusiness>()).CreateMapper();
            var model = mapper.Map<IEnumerable<Match>, List<MatchBusiness>>(db.Matches.GetAll());
            return model;
        }

        public RateBusiness GetRate(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set rate id", "");
            var rate = db.Rates.Get(id.Value);
            if (rate == null)
                throw new ValidationException("Not found rate", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateBusiness>()).CreateMapper();

            var model = mapper.Map<Rate, RateBusiness>(rate);
            return model;
        }

        public IEnumerable<RateBusiness> GetRates()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateBusiness>()).CreateMapper();
            var model = mapper.Map<IEnumerable<Rate>, List<RateBusiness>>(db.Rates.GetAll());
            return model;
        }

        public CommandBusiness GetCommand(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set command id", "");
            var command = db.Commands.Get(id.Value);
            if (command == null)
                throw new ValidationException("Not found command", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Command, CommandBusiness>()).CreateMapper();

            var model = mapper.Map<Command, CommandBusiness>(command);
            return model;
        }

        public IEnumerable<CommandBusiness> GetCommands()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Command, CommandBusiness>()).CreateMapper();
            var model = mapper.Map<IEnumerable<Command>, List<CommandBusiness>>(db.Commands.GetAll());
            return model;
        }

        /*public IList<RatesListProvider> GetRatesList(int? id)
        {
            var rate = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateBusiness>()).CreateMapper();
            var rates = rate.Map<IEnumerable<Rate>, List<RateBusiness>>(db.Rates.GetAll());

            var sport = new MapperConfiguration(cfg => cfg.CreateMap<Sport, SportBusiness>()).CreateMapper();
            var sports = sport.Map<IEnumerable<Sport>, List<SportBusiness>>(db.Sports.GetAll());

            var command = new MapperConfiguration(cfg => cfg.CreateMap<Command, CommandBusiness>()).CreateMapper();
            var commands = command.Map<IEnumerable<Command>, List<CommandBusiness>>(db.Commands.GetAll());

            var match = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchBusiness>()).CreateMapper();
            var matches = match.Map<IEnumerable<Match>, List<MatchBusiness>>(db.Matches.GetAll());

            List<RatesListProvider> ratesList = new List<RatesListProvider>();

            if (id == null)
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
                var models = from r in rates
                             join m in matches on r.MatchId equals m.MatchId
                             join cH in commands on m.CommandIdHome equals cH.CommandId
                             join cG in commands on m.CommandIdGuest equals cG.CommandId
                             join s in sports on cH.SporttId equals s.SportId
                             where s.SportId == id
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


            return ratesList;
        }*/

    }
}
