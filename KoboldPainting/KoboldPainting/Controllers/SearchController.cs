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
        private readonly ICompanyRepository _companyRepository;
        public SearchController(IPaintRepository paintRepository, ICompanyRepository companyRepository)
        {
            _paintRepository = paintRepository;
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
            List<Paint> paintsToDisplay = _paintRepository.searchPaints(pv.Paint, pv.SelectedCompany);
            return View("SearchResults", paintsToDisplay);
        }
    }
}
