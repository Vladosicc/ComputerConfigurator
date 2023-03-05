using ComputerConfigurator.Managers;
using ComputerConfigurator.Models;
using ComputerConfigurator.Models.Citilink;
using ComputerConfigurator.Models.NotDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ComputerConfigurator.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductCitilinkManager _productCitilinkManager;
        readonly IConfigurationCitilinkManager _configurationCitilinkManager;

        public ProductsController(IProductCitilinkManager manager, IConfigurationCitilinkManager configurationCitilinkManager) 
        {
            _productCitilinkManager = manager;
            _configurationCitilinkManager = configurationCitilinkManager;
        }

        [HttpGet("coolers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CoolerCitilink>>> GetCoolers()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Cooler);
            return Products.Cast<CoolerCitilink>().ToList();
        }

        [HttpGet("audiocards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AudiocardCitilink>>> GetAudiocards()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Audiocard);
            return Products.Cast<AudiocardCitilink>().ToList();
        }

        [HttpGet("casings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CasingCitilink>>> GetCasings()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Casing);
            return Products.Cast<CasingCitilink>().ToList();
        }

        [HttpGet("processors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CpuCitilink>>> GetProcessors()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Processor);
            return Products.Cast<CpuCitilink>().ToList();
        }

        [HttpGet("graphics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GpuCitilink>>> GetGpu()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Gpu);
            return Products.Cast<GpuCitilink>().ToList();
        }

        [HttpGet("hdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HddCitilink>>> GetHdd()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Hdd);
            return Products.Cast<HddCitilink>().ToList();
        }

        [HttpGet("motherboards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MotherboardCitilink>>> GetMotherboards()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Motherboard);
            return Products.Cast<MotherboardCitilink>().ToList();
        }

        [HttpGet("psu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PsuCitilink>>> GetPsu()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Psu);
            return Products.Cast<PsuCitilink>().ToList();
        }

        [HttpGet("ram")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RamCitilink>>> GetRam()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Ram);
            return Products.Cast<RamCitilink>().ToList();
        }

        [HttpGet("ssd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SsdCitilink>>> GetSsd()
        {
            var Products = await _productCitilinkManager.GetEnumerableAsync(PartCode.Ssd);
            return Products.Cast<SsdCitilink>().ToList();
        }

        [HttpGet("sockets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SocketModel>>> GetSockets()
        {
            return SocketModel.Sockets.Cast<SocketModel>().ToList();
        }

        [HttpGet("config")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConfigurationCitilink>> GetConfig(Guid id)
        {
            return await _configurationCitilinkManager.FindConfigurationAsync(id);
        }
    }
}
