using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordsService;

        public SalesRecordsController(SalesRecordService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            System.Collections.Generic.List<Models.SalesRecord> result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }


    }
}