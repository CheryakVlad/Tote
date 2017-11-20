using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToteBiz.Business.Providers;
using ToteBiz.Business.Models;
using AutoMapper;
using Tote.Models;

namespace Tote.Controllers
{
    public class SportController : Controller
    {
        private INavigationProvider navigationProvider;
        public SportController(INavigationProvider navigationProvider)
        {
            this.navigationProvider = navigationProvider;
        }
        
        // GET: Sport
        public ActionResult Index()
        {
            IEnumerable<SportBusiness> sport = navigationProvider.GetSports();            
            var sports = Mapper.Map<IEnumerable<SportBusiness>, List<SportViewModel>>(sport);
            return View(sports);           
        }
        public ActionResult Sport()
        {
            IEnumerable<SportBusiness> sport = navigationProvider.GetSports();
            var sports = Mapper.Map<IEnumerable<SportBusiness>, List<SportViewModel>>(sport);
            return View(sports);
        }

        public ActionResult Rate(int id)
        {
            IEnumerable<RateBusiness> rate = navigationProvider.GetRates();
            var rates = Mapper.Map<IEnumerable<RateBusiness>, List<RateViewModel>>(rate);

            IEnumerable<SportBusiness> sport = navigationProvider.GetSports();
            var sports = Mapper.Map<IEnumerable<SportBusiness>, List<SportViewModel>>(sport);

            IEnumerable<CommandBusiness> command = navigationProvider.GetCommands();
            var commands = Mapper.Map<IEnumerable<CommandBusiness>, List<CommandViewModel>>(command);

            IEnumerable<MatchBusiness> match = navigationProvider.GetMatches();
            var matches = Mapper.Map<IEnumerable<MatchBusiness>, List<MatchViewModel>>(match);

            RateListViewModel ratesList = new RateListViewModel();

            var models = from r in rates                         
                         join m in matches on r.MatchId equals m.MatchId
                         join cH in commands on m.CommandIdHome equals cH.CommandId
                         join cG in commands on m.CommandIdGuest equals cG.CommandId
                         join s in sports on cH.SporttId equals s.SportId     
                         where r.RateId == id                    
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


            ratesList.RateId = models.First().RateId;
            ratesList.MatchId = models.First().MatchId;
            ratesList.WinCommandGuest = models.First().WinCommandGuest;
            ratesList.WinCommandHome = models.First().WinCommandHome;
            ratesList.Date = models.First().Date;
            ratesList.Draw = models.First().Draw;
            ratesList.CommandHome = models.First().CommandHome;
            ratesList.CommandGuest = models.First().CommandGuest;          
            
            

            return View(ratesList);
        }

            
        public ViewResult List(int? SportId,int? TournamentId=null)
        {
            
            IEnumerable<RateBusiness> rate = navigationProvider.GetRates();
            var rates = Mapper.Map<IEnumerable<RateBusiness>, List<RateViewModel>>(rate);

            IEnumerable<SportBusiness> sport = navigationProvider.GetSports();
            var sports = Mapper.Map<IEnumerable<SportBusiness>, List<SportViewModel>>(sport);

            IEnumerable<CommandBusiness> command = navigationProvider.GetCommands();
            var commands = Mapper.Map<IEnumerable<CommandBusiness>, List<CommandViewModel>>(command);

            IEnumerable<MatchBusiness> match = navigationProvider.GetMatches();
            var matches = Mapper.Map<IEnumerable<MatchBusiness>, List<MatchViewModel>>(match);
            
            List<RateListViewModel> ratesList = new List<RateListViewModel>();

            if (SportId == null)
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
                    ratesList.Add(new RateListViewModel
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
                if (TournamentId == null)
                {
                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SporttId equals s.SportId
                                 where s.SportId == SportId
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
                        ratesList.Add(new RateListViewModel
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
                    IEnumerable<TournamentBusiness> tournament = navigationProvider.GetTournamentes();
                    var tournamentes = Mapper.Map<IEnumerable<TournamentBusiness>, List<TournamentViewModel>>(tournament);

                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SporttId equals s.SportId
                                 join t in tournamentes on m.TournamentId equals t.TournamentId
                                 where t.TournamentId == TournamentId && s.SportId==SportId
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
                        ratesList.Add(new RateListViewModel
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
           

           
            return View(ratesList);
        }

        public PartialViewResult Menu(int category=0)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<SportBusiness> sport = navigationProvider.GetSports();
            var sports = Mapper.Map<IEnumerable<SportBusiness>, List<SportViewModel>>(sport); 
            
            return PartialView(sports);
        }

        public PartialViewResult ChildTournament(int id=0)
        {
            IEnumerable<TournamentBusiness> tournament = navigationProvider.GetTournamentes();
            var tournamentes = Mapper.Map<IEnumerable<TournamentBusiness>, List<TournamentViewModel>>(tournament);

            var model = from t in tournamentes
                        where t.SportId == id
                        select t;
            return PartialView(model);
        }
    }
}