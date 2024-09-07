using Microsoft.AspNetCore.Mvc;
using WebApplication1333333.Models;

namespace WebApplication1333333.Controllers
{
    public class CompanyController : Controller
    {
        private   XmlService _xmlService;
        private JsonService _jsonService;
        private  IniService _iniService;
        private  IWebHostEnvironment _env;
        
        public CompanyController(XmlService xmlService, JsonService jsonService, IniService iniService, IWebHostEnvironment env)
        {
            _xmlService = xmlService;
            _jsonService = jsonService;
            _iniService = iniService;
            _env = env;
        }

        public IActionResult Index()
        {
            var xmlPath = Path.Combine(_env.ContentRootPath, "config.xml");
            var jsonPath = Path.Combine(_env.ContentRootPath, "config.json");
            var iniPath = Path.Combine(_env.ContentRootPath, "config.ini");

            var xmlCompanies = _xmlService.GetCompaniesFromXml(xmlPath);
            var jsonCompanies = _jsonService.GetCompaniesFromJson(jsonPath);
            var iniCompanies = _iniService.GetCompaniesFromIni(iniPath);

            var allCompanies = xmlCompanies.Concat(jsonCompanies).Concat(iniCompanies).ToList();
            var topCompany = allCompanies.OrderByDescending(c => c.Employees).FirstOrDefault();


            return View(topCompany); 
        }
        
    }
}
