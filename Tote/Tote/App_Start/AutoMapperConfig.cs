using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Tote.Models;
using ToteBiz.Business.Models;

namespace Tote.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SportBusiness, SportViewModel>();
            
        });
        }
    }
}