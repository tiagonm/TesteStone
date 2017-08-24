using Stone.Imobilizado.Repository.Model;
using Stone.Imobilizado.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Imobilizado.Service
{
    public interface IImobilizadoService: IServiceBase<ImobilizadoModel>
    {
        List<T> ObterLivres<T>();
    }
}
