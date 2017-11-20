using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Context;

namespace Data.Repository
{
    class CommandRepository : IRepository<Command>
    {
        private ToteContext db;

        public CommandRepository(ToteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Command> GetAll()
        {
            return db.Commands;
        }

        public Command Get(int id)
        {
            var selectedCommand = from Command in db.Commands
                                where Command.CommandId == id
                                select Command;
            return selectedCommand.First();
        }

        public void Create(Command command)
        {
            db.Commands.Add(command);
        }

        public void Update(Command Command)
        {

        }

        public IEnumerable<Command> Find(Func<Command, Boolean> predicate)
        {
            return db.Commands.Where(predicate).ToList();
        }

        public void Delete(int id)
        {

        }
    }
}
