using Microsoft.AspNetCore.Mvc;
using WebApplication1333333.Models;

namespace WebApplication1333333.Controllers
{
    public class CompanyController : Controller
    {
        private static readonly Random _random = new Random();
        public IActionResult Index()
        {
            int randomNumber = _random.Next(0, 101);
            ViewBag.RandomNumber = randomNumber;
            return View();
        }
        //private static List<Company> companies = new List<Company>
        //{
        //    new Company { Name = "Company A", Discription = "Description A", Adress = "Address A", Email = "emailA@example.com", NamberGroup = 1 },
        //    new Company { Name = "Company B", Discription = "Description B", Adress = "Address B", Email = "emailB@example.com", NamberGroup = 2 }
        //};
    }
}
