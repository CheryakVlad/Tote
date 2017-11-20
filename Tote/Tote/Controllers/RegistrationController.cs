
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Interfaces;
using Tote.Models;
using ToteBiz.Business;

namespace Tote.Controllers
{




    public class RegistrationController : Controller
    {        
        List<SportViewModel> sports = new List<SportViewModel>() { new SportViewModel() { SportId = 1, Name = "Football" },
        new SportViewModel() { SportId = 2, Name = "Hockey" }, new SportViewModel() { SportId = 3, Name = "Basketball" }};

        private readonly IMessage message;
        //private string _message;

        private UserRegister register = new UserRegister();

        public RegistrationController(IMessage message)
        {
            this.message = message;            
        }
        public RegistrationController()
        {
            
        }

        public ActionResult Startup()
        {
            return View(sports);
        }

        public ActionResult Messages()
        {
            string _message = TempData["ErrorMessage"] as string;
            ViewBag.Message = message.Send(_message);            
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User userReg)
        {
            string message = string.Empty;    
            try
            {
                this.register.Registration(userReg);
            }
            catch(UserException e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message+" "+e.TargetSite+" "+e.Source);
                message = e.Message;
            }
            if(message ==null)
            {
                message = "do not find";
            }
            TempData["ErrorMessage"] = message;
            return RedirectToAction("Messages");
        }

    }
}