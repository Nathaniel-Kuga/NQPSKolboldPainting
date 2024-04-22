using Microsoft.AspNetCore.Mvc;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;


namespace KoboldPainting.Controllers
{
    public class PaintController : Controller
    {
        public IActionResult Index()
        {
            // Action logic goes here
            return View();
        }

        public IActionResult Details(int id)
        {
            // Action logic goes here
            return View();
        }

        // Add more action methods as needed
    }
}