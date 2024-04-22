using Microsoft.AspNetCore.Mvc;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;
using Microsoft.AspNetCore.Identity;
using KoboldPainting.Areas.Identity.Data;

namespace KoboldPainting.Controllers
{
    public class PaintController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PaintController> _logger;
        private readonly IPaintRepository _paintRepository;
        // IRepository<Paint> _paintepository;
        public PaintController(ILogger<PaintController> logger,
                               IPaintRepository paintRepository, 
                               UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _paintRepository = paintRepository;
            _userManager = userManager;
        }
        
        [HttpPost]
        public IActionResult AddPaint (PaintsViewModel paintToAdd)
        {
            // Attempt to add
            // verify paintToAdd name is not taken, then check if company exists, 
            // then check if paint type exists 
            //and or paintype exists
            // 3catch failure return error
            // success return success

            return RedirectToAction("MyPaints", "Home");
        }

        // Add more action methods as needed
    }
}