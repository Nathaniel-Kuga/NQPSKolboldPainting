using Microsoft.AspNetCore.Mvc;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;
using Microsoft.AspNetCore.Identity;
using KoboldPainting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace KoboldPainting.Controllers
{
    public class PaintController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PaintController> _logger;
        private readonly IPaintRepository _paintRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IPaintTypeRepository _paintTypeRepository;
        private readonly IKoboldUserRepository _koboldUserRepository;

        public PaintController(ILogger<PaintController> logger,
                               IPaintRepository paintRepository,
                               UserManager<ApplicationUser> userManager,
                               ICompanyRepository companyRepository,
                               IPaintTypeRepository paintTypeRepository,
                               IKoboldUserRepository koboldUserRepository)
        {
            _logger = logger;
            _paintRepository = paintRepository;
            _userManager = userManager;
            _companyRepository = companyRepository;
            _paintTypeRepository = paintTypeRepository;
            _koboldUserRepository = koboldUserRepository;
        }
        [Authorize]
        public async Task<IActionResult> MyPaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var koboldUser = _koboldUserRepository.GetAll().FirstOrDefault(u => u.AspNetUserId == currentUser.Id);
            if (koboldUser != null)
            {
                var myPaintsVM = new MyPaintsViewModel
                {
                    OwnedPaints = _paintRepository.GetUserOwnedPaints(koboldUser.Id).ToList(),
                    WantedPaints = _paintRepository.GetUserWantedPaints(koboldUser.Id).ToList(),
                    RefillPaints = _paintRepository.GetUserRefillPaints(koboldUser.Id).ToList()
                };
                return View(myPaintsVM);
            }
            return RedirectToAction("Index", "Home");

        }

        // [HttpPost]
        // public IActionResult MyPaints(PaintsViewModel paintToAddVM)
        // {
        //     // * form has been submitted and therefore is always true
        //     paintToAddVM.IsFormSubmitted = true;
        //     if (!ModelState.IsValid)
        //     {
        //         // foreach (var modelState in ModelState.Values)
        //         // {
        //         //     foreach (var error in modelState.Errors)
        //         //     {
        //         //         Debug.WriteLine(error.ErrorMessage);
        //         //     }
        //         // }
        //         paintToAddVM.Companies = _companyRepository.GetAll().ToList();
        //         paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
        //         return View(paintToAddVM);
        //     }
        //     // * Model is valid, proceed
        //     // * Trim whitespace from input
        //     paintToAddVM.Paint = paintToAddVM.Paint.Trim();
        //     // * check if paint already exists
        //     bool paintExists = _paintRepository.GetAll().Any(p => p.PaintName == paintToAddVM.Paint);
        //     if (paintExists)
        //     {
        //         paintToAddVM.ResultMessage = "Paint already exists";
        //         paintToAddVM.Companies = _companyRepository.GetAll().ToList();
        //         paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
        //         return View(paintToAddVM);
        //     }

        //     // * Exact match not found, check for fuzzy match
        //     if (!paintExists)
        //     {
        //         var paintNameMatches = _paintRepository.FuzzySearch(paintToAddVM.Paint, 90);
        //         if (paintNameMatches.Count > 0)
        //         {
        //             paintToAddVM.ResultMessage = "Paint already exists";
        //             paintToAddVM.Companies = _companyRepository.GetAll().ToList();
        //             paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
        //         }
        //         //* no fuzzy match found, add paint to db
        //         if (paintNameMatches.Count == 0)
        //         {
        //             var paintToAddToDb = new Paint
        //             {
        //                 PaintName = paintToAddVM.Paint,
        //                 CompanyId = paintToAddVM.SelectedCompany,
        //                 PaintTypeId = paintToAddVM.SelectedPaintType
        //             };
        //             _paintRepository.AddOrUpdate(paintToAddToDb);
        //             paintToAddVM.ResultMessage = "Success! Paint added!";
        //             paintToAddVM.Companies = _companyRepository.GetAll().ToList();
        //             paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
        //             paintToAddVM.IsSuccess = true;
        //         }

        //     }
        //     return View(paintToAddVM);

        // }

        // Add more action methods as needed
    }
}