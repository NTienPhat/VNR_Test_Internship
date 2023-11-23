using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System.Diagnostics;
using VNR_Web.Models;

namespace VNR_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int? khoaHocId)
        {
            if(khoaHocId == null)
            {
                var khoaHocList = await _unitOfWork.KhoaHocService.Get();
                if (khoaHocList == null)
                {
                    ViewBag.Message = "Không có khóa học nào!";
                }
                return View(khoaHocList);
            }
            else
            {
                var khoaHocList = await _unitOfWork.KhoaHocService.Get();
                if (khoaHocList == null)
                {
                    ViewBag.Message = "Không có khóa học nào!";
                }
                var monHoc = await _unitOfWork.MonHocService.Get(x => x.KhoaHocId == khoaHocId);
                var khoaHocName = await _unitOfWork.KhoaHocService.GetFirst(x => x.Id == khoaHocId);
                if (monHoc == null)
                {
                    ViewBag.Message = "Không có môn học nào!";
                }
                ViewBag.MonHoc = monHoc;
                ViewBag.KhoaHoc = khoaHocName.TenKhoaHoc;
                return View(khoaHocList);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}