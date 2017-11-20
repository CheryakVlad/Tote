using Ninject.Modules;
using Data.Repository;

namespace ToteBiz.Business.Providers
{
    public class ModuleProvider : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
