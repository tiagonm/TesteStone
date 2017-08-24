using Stone.Imobilizado.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Stone.Imobilizado.Repository;
using Stone.Imobilizado.Service.Base;

namespace Stone.Imobilizado.Service
{
    public class ImobilizadoService : ServiceBase<ImobilizadoModel>,IImobilizadoService
    {        
        public ImobilizadoService(IImobilizadoRepository repository)
            : base (repository)
        {
            
        }
      
    }
}
