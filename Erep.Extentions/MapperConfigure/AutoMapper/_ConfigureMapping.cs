using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace Erep.Extentions.MapperConfigure.AutoMapper
{
    public class _ConfigureMapping
    {
        public static void Configure()
        {
            Mapper.Configuration.AddProfile(new ConfigureScammerMapping());
        }
    }
}
