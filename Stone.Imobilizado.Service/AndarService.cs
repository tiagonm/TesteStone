using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Stone.Imobilizado.Repository.Model;
using Stone.Imobilizado.Repository;
using Stone.Imobilizado.Service.Base;

namespace Stone.Imobilizado.Service
{
    public class AndarService : ServiceBase<AndarModel>, IAndarService
    {

        public AndarService(IAndarRepository repository)
            : base(repository)
        {
        }

    }
}
