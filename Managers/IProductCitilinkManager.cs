using ComputerConfigurator.Models;

namespace ComputerConfigurator.Managers
{
    public interface IProductCitilinkManager
    {
        /// <summary>
        /// Возвращает No tracking продукт
        /// </summary>
        /// <param name="partCode">Код продукта</param>
        /// <param name="id">id продукта</param>
        /// <returns>Продукт с заданным id, или null, если найти не удалось</returns>
        public Task<IProduct> FindAsync(PartCode partCode, int id);

        /// <summary>
        /// Возвращает все продукты из БД
        /// </summary>
        /// <param name="partCode">Код продукта</param>
        /// <returns>Коллекция продуктов</returns>
        public Task<IEnumerable<IProduct>> GetEnumerableAsync(PartCode partCode);

        /// <summary>
        /// Возвращает все продукты из БД
        /// </summary>
        /// <returns>Коллекция продуктов</returns>
        public Task<IEnumerable<T>> GetEnumerableAsync<T>() where T : class, new();
    }
}
