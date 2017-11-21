using System.Collections.Generic;
using Common.Models;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;

namespace ToteBiz.Business.Providers
{
    class CommandProvider : ICommandProvider
    {
        IUnitOfWork db { get; set; }

        public CommandProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {

        }

        public Command GetCommand(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set command id", "");
            var command = db.Commands.Get(id.Value);            
            return command;
        }

        public IEnumerable<Command> GetCommands()
        {
           
            return db.Commands.GetAll();
        }
    }
}
