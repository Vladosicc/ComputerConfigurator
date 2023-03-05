using ComputerConfigurator.Managers;
using ComputerConfigurator.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerConfigurator.Controllers
{
    public class ComputerConfigController : Controller
    {
        readonly IProductCitilinkManager _productCitilinkManager;
        readonly IConfigurationCitilinkManager _configurationCitilinkManager;

        public ComputerConfigController(IProductCitilinkManager manager, IConfigurationCitilinkManager configurationCitilinkManager)
        {
            _productCitilinkManager = manager;
            _configurationCitilinkManager = configurationCitilinkManager;
        }

        // GET:
        public async Task<IActionResult> Index()
        {
            if(!Request.Cookies.TryGetValue("config", out var idConfig))
                idConfig = Guid.NewGuid().ToString();

            var config = await _configurationCitilinkManager.FindConfigurationAsync(Guid.Parse(idConfig));

            if (config == null)
            {
                config = await _configurationCitilinkManager.CreateNewConfigurationAsync();
                Response.Cookies.Delete("config");
                Response.Cookies.Append("config", config.Id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Path = "/",
                    Expires = DateTime.Now.AddDays(14),
                    IsEssential = true
                });
            }
            return View(config);
        }

        // GET: ./Details/{guid}
        public async Task<IActionResult> Details(string guid)
        {
            if(!Guid.TryParse(guid, out var id))
            {
                return BadRequest();
            }

            var config = _configurationCitilinkManager.FindConfigurationAsync(id);

            if (config == null)
            {
                return NotFound();
            }

            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(PartCode codeComponent, int idComponent)
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.AddPartInConfigurationAsync(Guid.Parse(idConfig), codeComponent, idComponent, await _productCitilinkManager.FindAsync(codeComponent, idComponent));

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }

        [HttpPost]
        public async Task<IActionResult> AddComponentFromConfig(PartCode codeComponent, int idComponent)
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.AddPartInConfigurationAsync(Guid.Parse(idConfig), codeComponent, idComponent, await _productCitilinkManager.FindAsync(codeComponent, idComponent));

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteComponent(PartCode codeComponent)
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.RemovePartInConfigurationAsync(Guid.Parse(idConfig), codeComponent);

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }

        [HttpPost]
        public async Task<IActionResult> IncrementRamComponent(PartCode codeComponent)
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.IncrementCountRam(Guid.Parse(idConfig));

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }

        [HttpPost]
        public async Task<IActionResult> DecrementRamComponent(PartCode codeComponent)
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.DecrementCountRam(Guid.Parse(idConfig));

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }

        [HttpPost]
        public async Task<IActionResult> ClearConfig()
        {
            if (!Request.Cookies.TryGetValue("config", out var idConfig))
                return BadRequest("Cookie not found");

            var config = await _configurationCitilinkManager.RemoveConfigurationAsync(Guid.Parse(idConfig));

            if (config == null)
                return BadRequest("Config not found");
            else
                return Ok("Success");

        }
    }
}
