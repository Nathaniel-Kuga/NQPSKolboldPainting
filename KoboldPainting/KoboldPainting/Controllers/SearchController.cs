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
        public SearchController(IPaintRepository paintRepository)
        {
            _paintRepository = paintRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult PaintSearch(string PaintName, string SelectedCompany)
        {
            List<Paint> paintsToDisplay = _paintRepository.searchPaints(PaintName);
            return View("SearchResults", paintsToDisplay);
        }
    }
}
