using Microsoft.AspNetCore.Mvc;
using WebApplication1333333.Models;
using WebApplication1333333.Service;

namespace WebApplication1333333.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var company = _companyService.GetCompanyWithMostEmployees();
            return View(company);
        }
    }
}
