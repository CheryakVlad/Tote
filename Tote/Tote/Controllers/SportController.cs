using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToteBiz.Business.Providers;
using Common.Models;
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
        
       
        public ActionResult Index()
        {
            IEnumerable<Sport> sports = navigationProvider.GetSports();            
            
            return View(sports);           
        }
        public ActionResult Sport()
        {
            IEnumerable<Sport> sport = navigationProvider.GetSports();
            
            return View(sport);
        }

        public ActionResult Rate(int id)
        {
            IEnumerable<Rate> rates = navigationProvider.GetRates();
            
            IEnumerable<Sport> sports = navigationProvider.GetSports();            

            IEnumerable<Command> commands = navigationProvider.GetCommands();

            IEnumerable<Match> matches = navigationProvider.GetMatches();

            

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
            
            IList<RatesListProvider> rates = navigationProvider.GetRate(SportId, TournamentId);         
            
            return View(rates);
        }

        public PartialViewResult Menu(int category=0)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<Sport> sports = navigationProvider.GetSports();            
            
            return PartialView(sports);
        }

        public PartialViewResult ChildTournament(int id=0)
        {
            IEnumerable<Tournament> tournamentes = navigationProvider.GetTournamentes();           

            var model = from t in tournamentes
                        where t.SportId == id
                        select t;
            return PartialView(model);
        }
    }
}