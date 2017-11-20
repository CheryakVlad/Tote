using System.Collections.Generic;
using AutoMapper;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Data.Models;

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

        public CommandBusiness GetCommand(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set command id", "");
            var command = db.Commands.Get(id.Value);
            if (command == null)
                throw new ValidationException("Not found command", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Command, CommandBusiness>()).CreateMapper();

            var model = mapper.Map<Command, CommandBusiness>(command);
            return model;
        }

        public IEnumerable<CommandBusiness> GetCommands()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Command, CommandBusiness>()).CreateMapper();

            var model = mapper.Map<IEnumerable<Command>, List<CommandBusiness>>(db.Commands.GetAll());
            return model;
        }
    }
}
