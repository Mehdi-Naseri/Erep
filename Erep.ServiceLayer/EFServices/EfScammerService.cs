using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Erep.DomainClasses.Models;
using Erep.DataAccessLayer.IUnitOfWork;
using Erep.ServiceLayer.Interfaces;

namespace Erep.ServiceLayer.EFServices
{
    public class EfScammerService : _EfGenericService<Scammer>, IScammerService
    {
        public EfScammerService(IUnitOfWorkErep uow)
            : base(uow)
        {

        }

        public bool Exist(string name)
        {
            return _tEntities.Any(r => r.Name == name);
        }
    }
}
