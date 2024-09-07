using Microsoft.AspNetCore.Mvc;
using WebApplication1333333.Models;

namespace WebApplication1333333.Controllers
{
    public class MyinfoController : Controller
    {
        private JsonMyService _jsonMyService;
        private  IWebHostEnvironment _env;

        public MyinfoController(JsonMyService jsonMyService, IWebHostEnvironment env)
        {
            _jsonMyService = jsonMyService;
            _env = env;
        }
        public IActionResult Index()
        {
            var jsonPath = Path.Combine(_env.ContentRootPath, "myinfromation.json");
            var configData = _jsonMyService.GetConfigData(jsonPath);
            return View(configData);
        }
    }
}
