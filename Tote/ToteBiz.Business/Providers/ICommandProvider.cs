using System.Collections.Generic;
using ToteBiz.Business.Models;
using Common.Models;

namespace ToteBiz.Business.Providers
{
    public interface ICommandProvider
    {
        Command GetCommand(int? id);
        IEnumerable<Command> GetCommands();
        //void Dispose();
    }
}
