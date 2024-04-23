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

        public PaintController(ILogger<PaintController> logger,
                               IPaintRepository paintRepository,
                               UserManager<ApplicationUser> userManager,
                               ICompanyRepository companyRepository,
                               IPaintTypeRepository paintTypeRepository)
        {
            _logger = logger;
            _paintRepository = paintRepository;
            _userManager = userManager;
            _companyRepository = companyRepository;
            _paintTypeRepository = paintTypeRepository;
        }
        [Authorize]
        public IActionResult MyPaints()
        {
            var paintsVM = new PaintsViewModel
            {
                Companies = _companyRepository.GetAll().ToList(),
                PaintTypes = _paintTypeRepository.GetAll().ToList()
            };
            return View(paintsVM);
        }

        [HttpPost]
        public IActionResult MyPaints(PaintsViewModel paintToAddVM)
        {
            // Attempt to add
            if (!ModelState.IsValid)
            {
                // foreach (var modelState in ModelState.Values)
                // {
                //     foreach (var error in modelState.Errors)
                //     {
                //         Debug.WriteLine(error.ErrorMessage);
                //     }
                // }
                paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                return View(paintToAddVM);
            }

            bool paintExists = _paintRepository.GetAll().Any(p => p.PaintName == paintToAddVM.Paint);
            if (paintExists)
            {
                paintToAddVM.ResultMessage = "Paint already exists";
                paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                return View(paintToAddVM);
            }

            if (!paintExists)
            {
                // verify paintToAddVM name is not taken using fuzzy search
                var paintNameMatches = _paintRepository.FuzzySearch(paintToAddVM.Paint);
                if (paintNameMatches.Count > 0)
                {
                    paintToAddVM.ResultMessage = "Paint already exists";
                    paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                    paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                    return View(paintToAddVM);
                }
                if (paintNameMatches.Count == 0)
                {
                    var paintToAddToDb = new Paint
                    {
                        PaintName = paintToAddVM.Paint,
                        CompanyId = paintToAddVM.SelectedCompany,
                        PaintTypeId = paintToAddVM.SelectedPaintType
                    };
                    _paintRepository.AddOrUpdate(paintToAddToDb);
                    paintToAddVM.ResultMessage = "Success! Paint added!";
                    paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                    paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                    return View(paintToAddVM);
                }

            }
            return View(paintToAddVM);

        }

        // Add more action methods as needed
    }
}