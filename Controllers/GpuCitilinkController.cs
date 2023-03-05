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
    public class GpuCitilinkController : Controller
    {
        readonly IProductCitilinkManager _productCitilinkManager;

        public GpuCitilinkController(IProductCitilinkManager manager)
        {
            _productCitilinkManager = manager;
        }

        // GET: GpuCitilinks
        public async Task<IActionResult> Index()
        {
            var products = await _productCitilinkManager.GetEnumerableAsync(Models.PartCode.Gpu);

            if(products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: GpuCitilinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpuCitilink = await _productCitilinkManager.FindAsync(Models.PartCode.Gpu, id.Value);

            if (gpuCitilink == null)
            {
                return NotFound();
            }

            return View(gpuCitilink);
        }
    }
}
