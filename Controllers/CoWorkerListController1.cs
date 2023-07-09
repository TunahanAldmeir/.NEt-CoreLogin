using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using İnsanKaynaklarıPT.DbContextS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace İnsanKaynaklarıPT.Controllers
{
    public class CoWorkerListController1 : Controller
    {
        private readonly DbContextQ _context;

        public CoWorkerListController1(DbContextQ context)
        {
            _context = context;
        }
        public IActionResult CoWorkers()
        {
            return View();
        }
        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            var departments = _context.Departs.ToList();

            return Request.CreateResponse(DataSourceLoader.Load(departments, loadOptions));
        }

    }
}
