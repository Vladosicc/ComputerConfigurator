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
    public class MotherboardCitilinkController : Controller
    {
        readonly IProductCitilinkManager _productCitilinkManager;

        public MotherboardCitilinkController(IProductCitilinkManager manager)
        {
            _productCitilinkManager = manager;
        }

        // GET:
        public async Task<IActionResult> Index()
        {
            var products = await _productCitilinkManager.GetEnumerableAsync(Models.PartCode.Motherboard);

            if(products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: ./Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCitilink = await _productCitilinkManager.FindAsync(Models.PartCode.Motherboard, id.Value);

            if (productCitilink == null)
            {
                return NotFound();
            }

            return View(productCitilink);
        }
    }
}
