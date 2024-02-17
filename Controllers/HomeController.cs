using FilteringData.Context;
using FilteringData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilteringData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext _context;

        public HomeController(ILogger<HomeController> logger,StudentContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddData()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddData(StudentData Data)
        {
            _context.Students.Add(Data);
            _context.SaveChanges(); 

            return View();
        }
        public IActionResult ShowData()
        {
            var res = _context.Students.ToList();
            return View("ShowData", res);
        }
        
        public IActionResult MonthData(string smonth)
        {
            var res = _context.Students.ToList();
            var requiredmonth = Convert.ToInt32(smonth);
            //var months = res.Select(item => item.DOB.Month).ToString();
            var filtereddata = res.Where(item => item.DOB.Month == requiredmonth).ToList();
            return View(filtereddata);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
