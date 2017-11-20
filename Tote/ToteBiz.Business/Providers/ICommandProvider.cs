using System.Collections.Generic;
using ToteBiz.Business.Models;

namespace ToteBiz.Business.Providers
{
    public interface ICommandProvider
    {
        CommandBusiness GetCommand(int? id);
        IEnumerable<CommandBusiness> GetCommands();
        //void Dispose();
    }
}
