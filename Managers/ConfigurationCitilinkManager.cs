using ComputerConfigurator.Models;
using ComputerConfigurator.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComputerConfigurator.Managers
{
    public class ConfigurationCitilinkManager : IConfigurationCitilinkManager
    {
        private readonly AutoDataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ConfigurationCitilinkManager(AutoDataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ConfigurationCitilink> AddPartInConfigurationAsync(Guid idConfiguration, PartCode partCode, int partId, IProduct product)
        {
            var Configuration = await FindByIdAsync(idConfiguration);
            if (Configuration == null)
                return null;
            await Configuration.AddPartAsync(partCode, partId, product);
            await _dataContext.SaveChangesAsync();
            return await FindConfigurationAsync(Configuration.Id);
        }

        public async Task<ConfigurationCitilink> CreateNewConfigurationAsync()
        {
            var Configuration = ConfigurationCitilink.Create();
            await _dataContext.Configurations.AddAsync(Configuration);
            await _dataContext.SaveChangesAsync();
            return await FindConfigurationAsync(Configuration.Id);
        }

        public async Task<ConfigurationCitilink> DecrementCountRam(Guid idConfiguration)
        {
            var Configuration = await FindByIdAsync(idConfiguration);
            if (Configuration == null)
                return null;
            Configuration.DecrementRamCount();
            await _dataContext.SaveChangesAsync();
            return await FindConfigurationAsync(Configuration.Id);
        }

        public async Task<ConfigurationCitilink> FindConfigurationAsync(Guid idConfiguration)
        {
            var Configuration = await _dataContext.Configurations.FindAsync(idConfiguration);
            if (Configuration == null)
                return null;
            await Configuration.UpdateAsync();
            return Configuration;
        }

        public async Task<ConfigurationCitilink> IncrementCountRam(Guid idConfiguration)
        {
            var Configuration = await FindByIdAsync(idConfiguration);
            if (Configuration == null)
                return null;
            Configuration.IncrementRamCount();
            await _dataContext.SaveChangesAsync();
            return await FindConfigurationAsync(Configuration.Id);
        }

        public async Task<ConfigurationCitilink> RemoveConfigurationAsync(Guid idConfiguration)
        {
            var Configuration = await FindByIdAsync(idConfiguration);
            if (Configuration == null)
                return null;
            _dataContext.Configurations.Remove(Configuration);
            await _dataContext.SaveChangesAsync();
            return Configuration;
        }

        public async Task<ConfigurationCitilink> RemovePartInConfigurationAsync(Guid idConfiguration, PartCode partCode)
        {
            var Configuration = await FindByIdAsync(idConfiguration);
            if (Configuration == null)
                return null;
            await Configuration.RemovePartAsync(partCode);
            await _dataContext.SaveChangesAsync();
            return await FindConfigurationAsync(Configuration.Id);
        }

        /// <summary>
        /// Возвращает tracking конфигурацию
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Конфигурация</returns>
        private async Task<ConfigurationCitilink> FindByIdAsync(Guid id)
        {
            return await _dataContext.Configurations.FindAsync(id);
        }
    }
}
