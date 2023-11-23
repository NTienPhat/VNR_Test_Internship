using Core.Models;
using Service.Repository;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IKhoaHocService KhoaHocService { get; private set; } = null!;
        public IMonHocService MonHocService { get; private set; } = null!;

        private readonly VNR_InternShipContext _context;

        public UnitOfWork()
        {
            _context = new VNR_InternShipContext();
            InitRepositories();
        }

        private void InitRepositories()
        {
            KhoaHocService = new KhoaHocRepository(_context, this);
            MonHocService = new MonHocRepository(_context, this);
        }
    }
}
