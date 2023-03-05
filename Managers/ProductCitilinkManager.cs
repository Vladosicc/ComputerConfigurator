using ComputerConfigurator.Models;
using ComputerConfigurator.Models.Citilink;
using ComputerConfigurator.Storage;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Managers
{
    public class ProductCitilinkManager : IProductCitilinkManager
    {
        private readonly AutoDataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductCitilinkManager(AutoDataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IProduct> FindAsync(PartCode partCode, int id)
        {
            switch (partCode)
            {
                case (PartCode.Processor):
                    {
                        return await _dataContext.Processors
                            .FindAsync(id);
                    }
                case (PartCode.Audiocard):
                    {
                        return await _dataContext.Audiocards
                            .FindAsync(id);
                    }
                case PartCode.Casing:
                    {
                        return await _dataContext.Casings
                            .FindAsync(id);
                    }
                case PartCode.Cooler:
                    {
                        return await _dataContext.Coolers
                            .FindAsync(id);
                    }
                case PartCode.Gpu:
                    {
                        return await _dataContext.GraphicCards
                            .FindAsync(id);
                    }
                case PartCode.Hdd:
                    {
                        return await _dataContext.HardDisks
                            .FindAsync(id);
                    }
                case PartCode.Motherboard:
                    {
                        return await _dataContext.Motherboards
                            .FindAsync(id);
                    }
                case PartCode.Psu:
                    {
                        return await _dataContext.Psu
                            .FindAsync(id);
                    }
                case PartCode.Ram:
                    {
                        return await _dataContext.Ram
                            .FindAsync(id);
                    }
                case PartCode.Ssd:
                    {
                        return await _dataContext.SsdDisks
                            .FindAsync(id);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public async Task<IEnumerable<IProduct>> GetEnumerableAsync(PartCode partCode)
        {
            return await GetEnumByCode(partCode);
        }

        public async Task<IEnumerable<T>> GetEnumerableAsync<T>() where T : class, new()
        {
            var ObjType = new T();
            IEnumerable<IProduct> Response = null;
            if (ObjType is AudiocardCitilink)
                Response = await GetEnumByCode(PartCode.Audiocard);
            
            if (ObjType is CasingCitilink)
                Response = await GetEnumByCode(PartCode.Casing);

            if (ObjType is CoolerCitilink)
                Response = await GetEnumByCode(PartCode.Cooler);

            if (ObjType is CpuCitilink)
                Response = await GetEnumByCode(PartCode.Processor);

            if (ObjType is GpuCitilink)
                Response = await GetEnumByCode(PartCode.Gpu);

            if (ObjType is HddCitilink)
                Response = await GetEnumByCode(PartCode.Hdd);

            if (ObjType is MotherboardCitilink)
                Response = await GetEnumByCode(PartCode.Motherboard);

            if (ObjType is PsuCitilink)
                Response = await GetEnumByCode(PartCode.Psu);

            if (ObjType is RamCitilink)
                Response = await GetEnumByCode(PartCode.Ram);

            if (ObjType is SsdCitilink)
                Response = await GetEnumByCode(PartCode.Ssd);

            if (Response != null)
                return Response.Cast<T>();
            else
                return new List<T>();
        }

        private async Task<IEnumerable<IProduct>> GetEnumByCode(PartCode partCode)
        {
            switch (partCode)
            {
                case (PartCode.Processor):
                    {
                        return await _dataContext.Processors
                            .ToListAsync();
                    }
                case (PartCode.Audiocard):
                    {
                        return await _dataContext.Audiocards
                            .ToListAsync();
                    }
                case PartCode.Casing:
                    {
                        return await _dataContext.Casings
                            .ToListAsync();
                    }
                case PartCode.Cooler:
                    {
                        return await _dataContext.Coolers
                            .ToListAsync();
                    }
                case PartCode.Gpu:
                    {
                        return await _dataContext.GraphicCards
                            .ToListAsync();
                    }
                case PartCode.Hdd:
                    {
                        return await _dataContext.HardDisks
                            .ToListAsync();
                    }
                case PartCode.Motherboard:
                    {
                        return await _dataContext.Motherboards
                            .ToListAsync();
                    }
                case PartCode.Psu:
                    {
                        return await _dataContext.Psu
                            .ToListAsync();
                    }
                case PartCode.Ram:
                    {
                        return await _dataContext.Ram
                            .ToListAsync();
                    }
                case PartCode.Ssd:
                    {
                        return await _dataContext.SsdDisks
                            .ToListAsync();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
