﻿using Core.Models;
using Service.Generic;
using Service.Service;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class KhoaHocRepository : GenericRepository<KhoaHoc>, IKhoaHocService
    {
        public KhoaHocRepository(VNR_InternShipContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
