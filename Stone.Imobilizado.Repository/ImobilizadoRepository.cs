using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Stone.Imobilizado.Repository.Model;
using MongoDB.Driver;
using Stone.Imobilizado.Repository.Base;

namespace Stone.Imobilizado.Repository
{
    public class ImobilizadoRepository : RepositoryBase<ImobilizadoModel>, IImobilizadoRepository
    {     

        public ImobilizadoRepository():
            base ("Imobilizados")
        {
          
        }

    }
}
