using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate1.Models;
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
        public IActionResult EditSocieties(int id)
        {

            var item = _adminService.GetSocietyById(id);
            if(item == null)
            {
                TempData["error"] = "Society Not found!";
                return RedirectToAction(nameof(Societies));
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult EditSocieties(Society society)
        {
            var result = _adminService.SaveEditedSociety(society);
            if(result)
            {
                TempData["success"] = "Society Updated Sucessfully";
                return RedirectToAction(nameof(Societies));
            }
            return View(society);
        }

        public IActionResult DeleteSociety(int id)
        {

            var item = _adminService.GetSocietyById(id);
            if (item == null)
            {
                TempData["error"] = "Society Not found!";
                return RedirectToAction(nameof(Societies));
            }
            return View(item);
        }
        [HttpPost]
        [ActionName("DeleteSociety")]
        public IActionResult DeleteSocietyPOST(int id)
        {

            var result = _adminService.DeleteSocietyById(id);
            if (result)
            {
                TempData["success"] = "Society Deleted Successfully";
                return RedirectToAction(nameof(Societies));
            }
            return RedirectToAction(nameof(Societies));
        }



        public IActionResult Blocks(int societyId, string  societyname)
        {
            ViewBag.society = societyId;
            ViewBag.societyname = societyname;
            var list = _adminService.GetBlocksBySocietyId(societyId);
            return View(list);
        }

        public IActionResult CreateBlock(int societyId)
        {

            var block = new Block()
            {
                SocietyId = societyId
            };
            return View(block);
        }
        [HttpPost]
        public IActionResult CreateBlock(Block block)
        {
            var result = _adminService.AddNewBlock(block);
            if(result)
            {
                TempData["success"] = "Block Created Successfully";
                return RedirectToAction(nameof(Societies));
            }
            return View(block);
        }


        public IActionResult EditBlock(int id)
        {

            var item = _adminService.GetBlockById(id);
            if (item == null)
            {
                TempData["error"] = "Society Not found!";
                return RedirectToAction(nameof(Societies));
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult EditBlock(Block block)
        {
            var result = _adminService.UpdateBlock(block);
            if (result)
            {
                TempData["success"] = "Society Updated Sucessfully";
                return RedirectToAction(nameof(Societies));
            }
            return View(block);
        }

        public IActionResult DeleteBlock(int id)
        {

            var item = _adminService.GetBlockById(id);
            if (item == null)
            {
                TempData["error"] = "Society Not found!";
                return RedirectToAction(nameof(Societies));
            }
            return View(item);
        }
        [HttpPost]
        [ActionName("DeleteBlock")]
        public IActionResult DeleteBlockPOST(int id)
        {

            var result = _adminService.DeleteLockById(id);
            if (result)
            {
                TempData["success"] = "Block Deleted Successfully";
                return RedirectToAction(nameof(Societies));
            }
            return RedirectToAction(nameof(DeleteBlock), new {Id = id});
        }
    }
}
