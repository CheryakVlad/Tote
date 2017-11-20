using System.Collections.Generic;
using AutoMapper;
using ToteBiz.Business.Models;
using Common.Validation;
using Data.Repository;
using Data.Models;

namespace ToteBiz.Business.Providers
{
    class RateProvider : IRateProvider
    {
        IUnitOfWork db { get; set; }

        public RateProvider(IUnitOfWork iUnitOfWork)
        {
            db = iUnitOfWork;
        }

        public void Dispose()
        {
            
        }

        public RateBusiness GetRate(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set rate id", "");
            var rate = db.Rates.Get(id.Value);
            if (rate == null)
                throw new ValidationException("Not found rate", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateBusiness>()).CreateMapper();

            var model = mapper.Map<Rate, RateBusiness>(rate);
            return model;
        }

        public IEnumerable<RateBusiness> GetRates()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateBusiness>()).CreateMapper();

            var model = mapper.Map<IEnumerable<Rate>, List<RateBusiness>>(db.Rates.GetAll());
            return model;
        }
    }
}
