using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newco.EmployeeDirectory.Core.Data;
using Newco.EmployeeDirectory.Web.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newco.EmployeeDirectory.Core.Interfaces;
using Newco.EmployeeDirectory.Web.Models.Home;

namespace Newco.EmployeeDirectory.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private readonly variables

        private readonly ApplicationDbContext _context;
        private readonly IViewRenderService _viewRenderService;

        #endregion

        #region Constructor
        public HomeController(ApplicationDbContext context, IViewRenderService viewRenderService)
        {
            _context = context;
            _viewRenderService = viewRenderService;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var normalisedSearchTerm = searchTerm.ToLowerInvariant().Replace(" ", "");

            var employees = _context.Employees.Where(x => x.NormalisedName.Contains(normalisedSearchTerm)).ToList();

            var results = new List<SearchResult>();

            foreach (var employee in employees)
            {
                var result = new SearchResult
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                    Country = employee.Country,
                    Id = employee.Id
                };
                results.Add(result);
            }

            if (results.Count == 1)
                return await GetEmployeeDetails(results.First().Id);

            var view = await _viewRenderService.RenderViewToStringAsync("Home/SearchResultsTable", new SearchResultsModel{Results = results});

            return Content(view);

        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeeDetails(string id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                var result = await _viewRenderService.RenderViewToStringAsync("Home/EmployeeDetail", new EmployeeDetail());
                return Content(result);
            }
            else
            {
                var model = EmployeeDetail.FromEmployeeObject(employee);
                var directReports = _context.Employees.Where(x => x.Manager == employee.Id).ToList();

                if (directReports.Any())
                {
                    foreach (var report in directReports)
                    {
                        var directReport = new SearchResult
                        {
                            FirstName = report.FirstName,
                            LastName = report.LastName,
                            PhoneNumber = report.PhoneNumber,
                            Country = report.Country,
                            Id = report.Id
                        };
                        model.DirectReports.Add(directReport);
                    }
                }

                var result = await _viewRenderService.RenderViewToStringAsync("Home/EmployeeDetail", model);

                return Content(result);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
