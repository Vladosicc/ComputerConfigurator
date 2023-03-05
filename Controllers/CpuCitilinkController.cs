using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerConfigurator.Models.Citilink;
using ComputerConfigurator.Storage;
using ComputerConfigurator.Managers;

namespace ComputerConfigurator.Controllers
{
    public class CpuCitilinkController : Controller
    {
        readonly IProductCitilinkManager _productCitilinkManager;

        public CpuCitilinkController(IProductCitilinkManager manager)
        {
            _productCitilinkManager = manager;
        }

        // GET: CpuCitilinks
        public async Task<IActionResult> Index()
        {
            var cpus = await _productCitilinkManager.GetEnumerableAsync(Models.PartCode.Processor);

            if(cpus == null)
            {
                return NotFound();
            }

            return View(cpus);
        }

        // GET: CpuCitilinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpuCitilink = await _productCitilinkManager.FindAsync(Models.PartCode.Processor, id.Value);

            if (cpuCitilink == null)
            {
                return NotFound();
            }

            return View(cpuCitilink);
        }
    }
}
