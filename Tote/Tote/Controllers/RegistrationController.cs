using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tote.Models;

namespace Tote.Controllers
{

    
   

    public class RegistrationController : Controller
    {        
        List<Sport> sports = new List<Sport>() { new Sport() { Id = 1, Name = "Football" },
        new Sport() { Id = 2, Name = "Hockey" }, new Sport() { Id = 3, Name = "Basketball" }};

        public ActionResult Index()
        {
            return View(sports);
        }
    }
}