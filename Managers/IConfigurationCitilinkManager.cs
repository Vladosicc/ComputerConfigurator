using ComputerConfigurator.Models;

namespace ComputerConfigurator.Managers
{
    public interface IConfigurationCitilinkManager
    {
        /// <summary>
        /// Возвращает конфигурацию из БД
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> FindConfigurationAsync(Guid idConfiguration);

        /// <summary>
        /// Удаляет конфигурацию из БД
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> RemoveConfigurationAsync(Guid idConfiguration);

        /// <summary>
        /// Создает новую конфигурацию в БД
        /// </summary>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> CreateNewConfigurationAsync();

        /// <summary>
        /// Добавляет элемент в сборку (если элемент уже есть, то заменяет)
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <param name="partCode">Код элемента, который нужно добавить</param>
        /// <param name="partId">Id элемента, который нужно добавить</param>
        /// <param name="product">элемент, который нужно добавить</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> AddPartInConfigurationAsync(Guid idConfiguration, PartCode partCode, int partId, IProduct product);

        /// <summary>
        /// Удаляет элемент из сборки
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <param name="partCode">Код элемента, который нужно удалить</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> RemovePartInConfigurationAsync(Guid idConfiguration, PartCode partCode);

        /// <summary>
        /// Добавляет один модуль ОЗУ
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> IncrementCountRam(Guid idConfiguration);

        /// <summary>
        /// Удаляет один модуль ОЗУ
        /// </summary>
        /// <param name="idConfiguration">Id сборки</param>
        /// <returns>Конфигурация компьютера</returns>
        public Task<ConfigurationCitilink> DecrementCountRam(Guid idConfiguration);
    }
}
