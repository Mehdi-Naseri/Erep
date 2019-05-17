using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Erep.DomainClasses.Models;

namespace Erep.ServiceLayer.Interfaces
{
    public interface IScammerService : _IGenericService<Scammer>
    {
        bool Exist(string Name);
    }
}
