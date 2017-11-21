using System;
using System.Collections.Generic;
using System.Linq;

using StructureMap.Configuration.DSL;
using Data.Repository;



namespace Data.Container
{
    public class DataRegistry:Registry
    {
        public DataRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
        }
        
    }
}
