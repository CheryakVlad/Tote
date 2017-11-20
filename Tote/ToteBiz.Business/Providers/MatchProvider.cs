using System.Collections.Generic;
using AutoMapper;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Data.Models;

namespace ToteBiz.Business.Providers
{
    class MatchProvider : IMatchProvider
    {
        IUnitOfWork db { get; set; }

        public MatchProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {

        }

        public MatchBusiness GetMatch(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set Match id", "");
            var match = db.Matches.Get(id.Value);
            if (match == null)
                throw new ValidationException("Not found Match", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchBusiness>()).CreateMapper();

            var model = mapper.Map<Match, MatchBusiness>(match);
            return model;
        }

        public IEnumerable<MatchBusiness> GetMatches()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchBusiness>()).CreateMapper();

            var model = mapper.Map<IEnumerable<Match>, List<MatchBusiness>>(db.Matches.GetAll());
            return model;
        }
    }
}
