using KoboldPainting.Areas.Identity.Data;
using KoboldPainting.DAL.Abstract;
using KoboldPainting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KoboldPainting.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPaintRepository _paintRepository;
        private readonly IPaintTypeRepository _paintTypeRepository;
        private readonly ICompanyRepository _companyRepository;
        public SearchController(IPaintRepository paintRepository, IPaintTypeRepository paintTypeRepository, ICompanyRepository companyRepository)
        {
            _paintRepository = paintRepository;
            _paintTypeRepository = paintTypeRepository;
            _companyRepository = companyRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            PaintsViewModel pv = new PaintsViewModel();
            pv.Companies = _companyRepository.GetAll().ToList();
            return View("Index", pv);
        }

        [Authorize]
        public IActionResult PaintSearch(PaintsViewModel pv)
        {
            var paintsViewModel = new PaintsViewModel
            {
                Paints = _paintRepository.searchPaints(pv.Paint, pv.SelectedCompany),
                Companies = _companyRepository.GetAll().ToList(),
                PaintTypes = _paintTypeRepository.GetAll().ToList()
            };
            return View("SearchResults", paintsViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SearchResults(PaintsViewModel paintToAddVM)
        {
            // * form has been submitted and therefore is always true
            paintToAddVM.IsFormSubmitted = true;
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
            // * Model is valid, proceed
            // * Trim whitespace from input
            paintToAddVM.Paint = paintToAddVM.Paint.Trim();
            // * check if paint already exists
            bool paintExists = _paintRepository.GetAll().Any(p => p.PaintName == paintToAddVM.Paint);
            if (paintExists)
            {
                paintToAddVM.ResultMessage = "Paint already exists";
                paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                return View(paintToAddVM);
            }

            // * Exact match not found, check for fuzzy match
            if (!paintExists)
            {
                var paintNameMatches = _paintRepository.FuzzySearch(paintToAddVM.Paint, 90);
                if (paintNameMatches.Count > 0)
                {
                    paintToAddVM.ResultMessage = "Paint already exists";
                    paintToAddVM.Companies = _companyRepository.GetAll().ToList();
                    paintToAddVM.PaintTypes = _paintTypeRepository.GetAll().ToList();
                }
                //* no fuzzy match found, add paint to db
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
                    paintToAddVM.IsSuccess = true;
                }

            }
            return View(paintToAddVM);

        }
    }
}
