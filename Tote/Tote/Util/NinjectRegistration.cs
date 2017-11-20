using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToteBiz.Business.Providers;
using Ninject.Modules;

namespace Tote.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<INavigationProvider>().To<NavigationProvider>();
        }
    }
}