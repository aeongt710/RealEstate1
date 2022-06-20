using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate1.Models.ViewModels;
using RealEstate1.Services.IService;

namespace RealEstate1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult CreateSociety()
        {
            return View();
        }
        [ActionName("CreateSociety")]
        [HttpPost]
        public IActionResult CreateSocietyPOST(SocietyCreateVM societyCreateVM)
        {
            if(ModelState.IsValid)
            {
                var result = _adminService.CreateNewSociety(societyCreateVM);
                if(result)
                {
                    TempData["success"] = "Society Created Sucessfully";
                    return RedirectToAction(nameof(Index));
                }
            }
                
            return View(societyCreateVM);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Societies()
        {
            var list = _adminService.GetScoieties();
            return View(list);
        }
    }
}
