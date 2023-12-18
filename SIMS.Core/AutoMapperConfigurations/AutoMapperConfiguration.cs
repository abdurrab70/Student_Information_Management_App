using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using SIMS.Core.AutoMapperConfigurations;

namespace SIMS.Core.AutoMapperConfigurations
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config: x =>
            {
                x.AddProfile<MappingsProfile>();
            });
        }
    }
}
