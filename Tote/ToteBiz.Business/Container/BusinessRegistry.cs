
using StructureMap.Configuration.DSL;
using ToteBiz.Business.Providers;



namespace ToteBiz.Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ICommandProvider>().Use<CommandProvider>();
            For<IMatchProvider>().Use<MatchProvider>();
            For<IRateProvider>().Use<RateProvider>();
            For<ITournamentProvider>().Use<TournamentProvider>();
            For<INavigationProvider>().Use<NavigationProvider>();
        }
    }
}
