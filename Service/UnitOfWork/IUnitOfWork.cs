using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IKhoaHocService KhoaHocService { get; }
        public IMonHocService MonHocService { get; }
    }
}
