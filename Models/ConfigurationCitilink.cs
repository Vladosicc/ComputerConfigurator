using ComputerConfigurator.Models;
using ComputerConfigurator.Models.Citilink;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using ComputerConfigurator.Helpers;
using ComputerConfigurator.Models.NotDetail;

namespace ComputerConfigurator.Models
{
    public class ConfigurationCitilink : ComputerConfigurator.Models.IConfiguration
    {
        public ConfigurationCitilink() { }

        public static ConfigurationCitilink Create()
        { return new ConfigurationCitilink() { Id = Guid.NewGuid() }; }

        public static ConfigurationCitilink Create(Guid guid)
        { return new ConfigurationCitilink() { Id = guid}; }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [MaybeNull]
        public System.Nullable<int> ProcessorId { get; set; }
        [ForeignKey(nameof(ProcessorId))]
        public virtual CpuCitilink Processor { get; set; }

        [MaybeNull]
        public System.Nullable<int> GraphicCardId { get; set; }
        [ForeignKey(nameof(GraphicCardId))]
        public virtual GpuCitilink GraphicCard { get; set; }

        [MaybeNull]
        public System.Nullable<int> MotherboardId { get; set; }
        [ForeignKey(nameof(MotherboardId))]
        public virtual MotherboardCitilink Motherboard { get; set; }

        [MaybeNull]
        public System.Nullable<int> HddId { get; set; }
        [ForeignKey(nameof(HddId))]
        public virtual HddCitilink Hdd { get; set; }

        [MaybeNull]
        public System.Nullable<int> SsdId { get; set; }
        [ForeignKey(nameof(SsdId))]
        public virtual SsdCitilink Ssd { get; set; }

        [MaybeNull]
        public System.Nullable<int> CasingId { get; set; }
        [ForeignKey(nameof(CasingId))]
        public virtual CasingCitilink Casing { get; set; }

        [MaybeNull]
        public System.Nullable<int> CoolerId { get; set; }
        [ForeignKey(nameof(CoolerId))]
        public virtual CoolerCitilink Cooler { get; set; }

        [MaybeNull]
        public System.Nullable<int> PsuId { get; set; }
        [ForeignKey(nameof(PsuId))]
        public virtual PsuCitilink Psu { get; set; }

        [MaybeNull]
        public System.Nullable<int> RamId { get; set; }
        [ForeignKey(nameof(RamId))]
        public virtual RamCitilink Ram { get; set; }

        [Required]
        public int RamCount { get; set; }

        [MaybeNull]
        public System.Nullable<int> AudiocardId { get; set; }
        [ForeignKey(nameof(AudiocardId))]
        public virtual AudiocardCitilink Audiocard { get; set; }

        [Required]
        public DateTime LastAccessTime { get; set; }

        //Errors
        private Dictionary<ErrorCode, Error> _errors = new Dictionary<ErrorCode, Error>();
        public IReadOnlyDictionary<ErrorCode, Error> Errors { get { return _errors; } }

        //Local properties
        private double _powerConsumption = 0;
        [NotMapped]
        public double PowerConsumption { get { return _powerConsumption; } }

        private SocketModel _socket;
        [NotMapped]
        public SocketModel Socket { get { return _socket; } }

        private decimal _price = 0;
        [NotMapped]
        public decimal Price { get { return _price; } }

        private int _memoryAmount;
        [NotMapped]
        public int MemoryAmount { get { return _memoryAmount; } }

        private int _sataDeviceCount;
        [NotMapped]
        public int SataDeviceCount { get { return _sataDeviceCount; } }

        private int _m2DeviceCount;
        [NotMapped]
        public int M2DeviceCount { get { return _m2DeviceCount; } }

        private string _motherboardRamType;
        [NotMapped]
        public string MotherboardRamType { get { return _motherboardRamType; } }

        public async Task AddPartAsync(PartCode code, int id, IProduct part)
        {
            await Task.Run(() =>
            {
                switch (code)
                {
                    case (PartCode.Processor):
                        {
                            ProcessorId = part.Id;
                            CpuError(part as CpuCitilink);
                            break;
                        }
                    case (PartCode.Audiocard):
                        {
                            AudiocardId = part.Id;
                            AudiocardError(part as AudiocardCitilink);
                            break;
                        }
                    case PartCode.Casing:
                        {
                            CasingId = part.Id;
                            CasingError(part as CasingCitilink);
                            //Если в корпусе уже установлен Бп, удаляем из сборки старый
                            if ((part as CasingCitilink).PsuPower > 0)
                            {
                                PsuId = null;
                            }
                            break;
                        }
                    case PartCode.Cooler:
                        {
                            CoolerId = part.Id;
                            CoolerError(part as CoolerCitilink);
                            break;
                        }
                    case PartCode.Gpu:
                        {
                            GraphicCardId = part.Id;
                            GpuError(part as GpuCitilink);
                            break;
                        }
                    case PartCode.Hdd:
                        {
                            HddId = part.Id;
                            HddError(part as HddCitilink);
                            break;
                        }
                    case PartCode.Motherboard:
                        {
                            MotherboardId = part.Id;
                            MotherboardError(part as MotherboardCitilink);
                            break;
                        }
                    case PartCode.Psu:
                        {
                            PsuId = part.Id;
                            PsuError(part as PsuCitilink);
                            //Если в корпусе уже установлен Бп, удаляем из сборки старый
                            if (CasingId != null && Casing.PsuPower > 0)
                            {
                                PsuId = null;
                            }
                            break;
                        }
                    case PartCode.Ram:
                        {
                            RamId = part.Id;
                            RamCount = 1;
                            RamError(part as RamCitilink);
                            break;
                        }
                    case PartCode.Ssd:
                        {
                            SsdId = part.Id;
                            SsdError(part as SsdCitilink);
                            break;
                        }
                }
            });
        }

        public async Task RemovePartAsync(PartCode code)
        {
            switch (code)
            {
                case (PartCode.Processor):
                    {
                        ProcessorId = null;
                        break;
                    }
                case (PartCode.Audiocard):
                    {
                        AudiocardId = null;
                        break;
                    }
                case PartCode.Casing:
                    {
                        CasingId = null;
                        break;
                    }
                case PartCode.Cooler:
                    {
                        CoolerId = null;
                        break;
                    }
                case PartCode.Gpu:
                    {
                        GraphicCardId = null;
                        break;
                    }
                case PartCode.Hdd:
                    {
                        HddId = null;
                        break;
                    }
                case PartCode.Motherboard:
                    {
                        MotherboardId = null;
                        break;
                    }
                case PartCode.Psu:
                    {
                        PsuId = null;
                        break;
                    }
                case PartCode.Ram:
                    {
                        RamId = null;
                        RamCount = 0;
                        break;
                    }
                case PartCode.Ssd:
                    {
                        SsdId = null;
                        break;
                    }
            }
            await UpdateAsync();
        }

        public void IncrementRamCount()
        {
            RamCount++;
            RamCountError();
        }

        public void DecrementRamCount()
        {
            RamCount--;
            if (RamCount < 1)
                RamCount = 1;
            RamCountError();
        }

        private void CpuError(CpuCitilink cpu)
        {
            //Crit. Не подходит сокет
            _errors.Remove(ErrorCode.SocketError);
            if (MotherboardId != null && Motherboard.IdSocket != cpu.IdSocket)
            {
                _errors.Add(ErrorCode.SocketError, Error.CreateByCode(ErrorCode.SocketError));
            }
            //Warn.TDP меньше чем у кулера
            _errors.Remove(ErrorCode.TdpWarn);
            if (CoolerId != null && Cooler.TdpMax != 0 && Cooler.TdpMax < cpu.Heat)
            {
                _errors.Add(ErrorCode.TdpWarn, Error.CreateByCode(ErrorCode.TdpWarn));
            }
            //Warn. Нет разъема видеовыхода на мат.плате
            _errors.Remove(ErrorCode.MotherboardGraphicIntefaceWarn);
            if (MotherboardId != null && cpu.GpuExist)
            {
                if (!(Motherboard.HdmiCount > 0 || Motherboard.DisplayPortCount > 0 || Motherboard.VgaCount > 0))
                {
                    _errors.Add(ErrorCode.MotherboardGraphicIntefaceWarn, Error.CreateByCode(ErrorCode.MotherboardGraphicIntefaceWarn));
                }
            }
        }

        private void AudiocardError(AudiocardCitilink audiocard)
        {
            //Crit. Нет PCI-E интерфейсов на мат.плате
            _errors.Remove(ErrorCode.PciInterfaceCount);
            if (MotherboardId != null && audiocard.Interface.StartsWith("PCI-E") && Motherboard.PCIe1Count < 1)
            {
                _errors.Add(ErrorCode.PciInterfaceCount, Error.CreateByCode(ErrorCode.PciInterfaceCount));
            }
        }

        private void CasingError(CasingCitilink casing)
        {
            try
            {
                //Crit. Форм фактор не подходит для мат.платы
                _errors.Remove(ErrorCode.FormFactorMotherboardError);
                if (MotherboardId != null && casing.IdFormFactor > Motherboard.IdFormFactor)
                {
                    _errors.Add(ErrorCode.FormFactorMotherboardError, Error.CreateByCode(ErrorCode.FormFactorMotherboardError));
                }
            }
            catch { }
            try
            {
                //Crit. Превышено кол-во слотов расширения (для видеокарты)
                _errors.Remove(ErrorCode.ExtensionSlotsError);
                if (GraphicCardId != null)
                {
                    int CountInGpu = 0;
                    if (GraphicCard.Width == null)
                        throw new Exception();
                    if (GraphicCard.Width.StartsWith("о")) //однослотовая система охлаждения
                        CountInGpu = 1;
                    if (GraphicCard.Width.StartsWith("д")) //двухслотовая система охлаждения
                        CountInGpu = 2;
                    if (GraphicCard.Width.StartsWith("т")) //трехслотовая система охлаждения
                        CountInGpu = 3;
                    if (GraphicCard.Width.StartsWith("ч"))
                        CountInGpu = 4;
                    if (GraphicCard.Width.StartsWith("п"))
                        CountInGpu = 5;

                    if (casing.CountSlotsExtension < CountInGpu)
                        _errors.Add(ErrorCode.ExtensionSlotsError, Error.CreateByCode(ErrorCode.ExtensionSlotsError));
                }
            }
            catch { }
            try
            {
                //Crit. Длинна видеокарты превышает допустимую
                _errors.Remove(ErrorCode.GpuLenghtError);
                if (GraphicCardId != null && casing.GraphicCardMaxLenght > 0 && casing.GraphicCardMaxLenght < GraphicCard.Lenght)
                {
                    _errors.Add(ErrorCode.GpuLenghtError, Error.CreateByCode(ErrorCode.GpuLenghtError));
                }
            }
            catch { }
            try
            {
                //Crit. Высота кулера превышает допустимую
                _errors.Remove(ErrorCode.HeightCoolerError);
                if (CoolerId != null && casing.CoolerHeightMax > 0 && casing.CoolerHeightMax < Cooler.Height)
                {
                    _errors.Add(ErrorCode.HeightCoolerError, Error.CreateByCode(ErrorCode.HeightCoolerError));
                }
            }
            catch { }
            try
            {
                //Crit. Длинна БП превышает допустимую
                _errors.Remove(ErrorCode.PsuLenghtError);
                if (PsuId != null && casing.PsuLenghtMax > 0 && casing.PsuLenghtMax < int.Parse(Psu.Size.GetFirstInt()))
                {
                    _errors.Add(ErrorCode.PsuLenghtError, Error.CreateByCode(ErrorCode.PsuLenghtError));
                }
            }
            catch { }
            try
            {
                //Warn. Бп в корпусе
                _errors.Remove(ErrorCode.PsuExistsWarn);
                if (casing.PsuPower > 0)
                {
                    _errors.Add(ErrorCode.PsuExistsWarn, Error.CreateByCode(ErrorCode.PsuExistsWarn));
                }
            }
            catch { }
            try
            {
                //Warn. Корпус не поддерживает установку СВО
                _errors.Remove(ErrorCode.CasingNotSupportWaterWarn);
                if (CoolerId != null && Cooler.Type.StartsWith("жидкостное") && !casing.CanWater)
                {
                    _errors.Add(ErrorCode.CasingNotSupportWaterWarn, Error.CreateByCode(ErrorCode.CasingNotSupportWaterWarn));
                }
            }
            catch { }
            try
            {
                //Info. У корпуса нет информации о высоте Кулера
                _errors.Remove(ErrorCode.NotCoolerHeightInfo);
                if (casing.CoolerHeightMax < 1)
                {
                    _errors.Add(ErrorCode.NotCoolerHeightInfo, Error.CreateByCode(ErrorCode.NotCoolerHeightInfo));
                }
            }
            catch { }
            try
            {
                //Info. У корпуса нет информации о длине БП
                _errors.Remove(ErrorCode.NotPsuLenghtInfo);
                if (casing.PsuLenghtMax < 1)
                {
                    _errors.Add(ErrorCode.NotPsuLenghtInfo, Error.CreateByCode(ErrorCode.NotPsuLenghtInfo));
                }
            }
            catch { }
            try
            {
                //Info. У корпуса нет информации о длине БП
                _errors.Remove(ErrorCode.NotGpuLenghtInfo);
                if (casing.GraphicCardMaxLenght < 1)
                {
                    _errors.Add(ErrorCode.NotGpuLenghtInfo, Error.CreateByCode(ErrorCode.NotGpuLenghtInfo));
                }
            }
            catch { }
        }

        private void CoolerError(CoolerCitilink cooler)
        {
            try
            {
                //Crit. Кулер не подходит для сокета
                _errors.Remove(ErrorCode.CoolerSocketError);
                if (ProcessorId != null && !cooler.SocketSupport.Exists(s => s.Id == Processor.IdSocket))
                {
                    _errors.Add(ErrorCode.CoolerSocketError, Error.CreateByCode(ErrorCode.CoolerSocketError));
                }
            }
            catch { }
            try
            {
                //Crit. Высота кулера превышает допустимую
                _errors.Remove(ErrorCode.HeightCoolerError);
                if (CasingId != null && Casing.CoolerHeightMax > 0 && Casing.CoolerHeightMax < cooler.Height)
                {
                    _errors.Add(ErrorCode.HeightCoolerError, Error.CreateByCode(ErrorCode.HeightCoolerError));
                }
            }
            catch { }
            try
            {
                //Warn. Tdp Процессора превышает кулер
                _errors.Remove(ErrorCode.TdpWarn);
                if (ProcessorId != null && Processor.Heat > cooler.TdpMax)
                {
                    _errors.Add(ErrorCode.TdpWarn, Error.CreateByCode(ErrorCode.TdpWarn));
                }
            }
            catch { }
            try
            {
                //Info. У кулера нет информации о максимальном TDP
                _errors.Remove(ErrorCode.NotCoolerHeightInfo);
                if (cooler.Height < 1)
                {
                    _errors.Add(ErrorCode.NotCoolerHeightInfo, Error.CreateByCode(ErrorCode.NotCoolerHeightInfo));
                }
            }
            catch { }
        }

        private void GpuError(GpuCitilink gpu)
        {
            try
            {
                //Crit. Превышено кол-во слотов расширения (для видеокарты)
                _errors.Remove(ErrorCode.ExtensionSlotsError);
                if (CasingId != null)
                {
                    int CountInGpu = 0;
                    if (gpu.Width == null)
                        throw new Exception();
                    if (gpu.Width.StartsWith("о")) //однослотовая система охлаждения
                        CountInGpu = 1;
                    if (gpu.Width.StartsWith("д")) //двухслотовая система охлаждения
                        CountInGpu = 2;
                    if (gpu.Width.StartsWith("т")) //трехслотовая система охлаждения
                        CountInGpu = 3;
                    if (gpu.Width.StartsWith("ч"))
                        CountInGpu = 4;
                    if (gpu.Width.StartsWith("п"))
                        CountInGpu = 5;

                    if (Casing.CountSlotsExtension < CountInGpu)
                        _errors.Add(ErrorCode.ExtensionSlotsError, Error.CreateByCode(ErrorCode.ExtensionSlotsError));
                }
            }
            catch { }
            try
            {
                //Crit. Длинна видеокарты превышает допустимую
                _errors.Remove(ErrorCode.GpuLenghtError);
                if (CasingId != null && Casing.GraphicCardMaxLenght > 0 && Casing.GraphicCardMaxLenght < gpu.Lenght)
                {
                    _errors.Add(ErrorCode.GpuLenghtError, Error.CreateByCode(ErrorCode.GpuLenghtError));
                }
            }
            catch { }
            try
            {
                //Crit. Не доступный интерфейс
                _errors.Remove(ErrorCode.GpuInterfaceError);
                if (MotherboardId != null)
                {
                    if (gpu.Interface.StartsWith("PCI-E"))
                    {
                        if (Motherboard.PCIe2Count + Motherboard.PCIe3Count + Motherboard.PCIe4Count + Motherboard.PCIe5Count < 1)
                            _errors.Add(ErrorCode.GpuInterfaceError, Error.CreateByCode(ErrorCode.GpuInterfaceError));
                    }
                }
            }
            catch { }
            try
            {
                //Warn. У Видеокарты более новый интерфейс, чем у мат.платы
                _errors.Remove(ErrorCode.GpuInterfaceWarn);
                if (MotherboardId != null)
                {
                    if (gpu.Interface.StartsWith("PCI-E"))
                    {
                        int PciVer = int.Parse(gpu.Interface.GetFirstInt());

                        if (PciVer == 5)
                            if (Motherboard.PCIe5Count < 1)
                                _errors.Add(ErrorCode.GpuInterfaceWarn, Error.CreateByCode(ErrorCode.GpuInterfaceWarn));

                        if (PciVer == 4)
                            if (Motherboard.PCIe5Count + Motherboard.PCIe4Count < 1)
                                _errors.Add(ErrorCode.GpuInterfaceWarn, Error.CreateByCode(ErrorCode.GpuInterfaceWarn));

                        if (PciVer == 3)
                            if (Motherboard.PCIe5Count + Motherboard.PCIe4Count + Motherboard.PCIe3Count < 1)
                                _errors.Add(ErrorCode.GpuInterfaceWarn, Error.CreateByCode(ErrorCode.GpuInterfaceWarn));
                    }
                }
            }
            catch { }
        }

        private void HddError(HddCitilink hdd)
        {
            try
            {
                //Warn. Количество жестких жисков больше
                _errors.Remove(ErrorCode.SataCountWarn);
                if (MotherboardId != null)
                {
                    if (Motherboard.Sata2Count + Motherboard.Sata3Count - _sataDeviceCount < 1 && hdd.IntefaceType.StartsWith("SATA"))
                        _errors.Add(ErrorCode.SataCountWarn, Error.CreateByCode(ErrorCode.SataCountWarn));
                }
            }
            catch { }
        }

        private void MotherboardError(MotherboardCitilink motherboard)
        {
            try
            {
                //Crit. Не подходит сокет
                _errors.Remove(ErrorCode.SocketError);
                if (ProcessorId != null && motherboard.IdSocket != Processor.IdSocket)
                {
                    _errors.Add(ErrorCode.SocketError, Error.CreateByCode(ErrorCode.SocketError));
                }
            }
            catch { }
            try
            {
                //Crit. Не подходит разъем ОЗУ
                _errors.Remove(ErrorCode.RamSocketError);
                if (RamId != null)
                {
                    //Если у нас DIMM и SO-DIMM
                    if (!motherboard.RamType.StartsWith(Ram.FormFactor))
                    {
                        _errors.Add(ErrorCode.RamSocketError, Error.CreateByCode(ErrorCode.RamSocketError));
                        throw new Exception();
                    }
                    string TypeMemory = "DDR";
                    if (motherboard.RamCountDDR5 > 0)
                        TypeMemory = "DDR5";
                    if (motherboard.RamCountDDR4 > 0)
                        TypeMemory = "DDR4";
                    if (motherboard.RamCountDDR3 > 0)
                        TypeMemory = "DDR3";
                    if (motherboard.RamCountDDR2 > 0)
                        TypeMemory = "DDR2";

                    if (!Ram.Type.StartsWith(TypeMemory))
                    {
                        _errors.Add(ErrorCode.RamSocketError, Error.CreateByCode(ErrorCode.RamSocketError));
                    }
                }
            }
            catch { }
            try
            {
                //Crit. Нет m2 разъема
                _errors.Remove(ErrorCode.NotFoundM2Error);
                if (SsdId != null && Ssd.FormFactor.StartsWith("M.2") && motherboard.M2Count < 1)
                {
                    _errors.Add(ErrorCode.NotFoundM2Error, Error.CreateByCode(ErrorCode.NotFoundM2Error));
                }
            }
            catch { }
            try
            {
                //Crit. Форм фактор не подходит для мат.платы
                _errors.Remove(ErrorCode.FormFactorMotherboardError);
                if (CasingId != null && Casing.IdFormFactor > motherboard.IdFormFactor)
                {
                    _errors.Add(ErrorCode.FormFactorMotherboardError, Error.CreateByCode(ErrorCode.FormFactorMotherboardError));
                }
            }
            catch { }
            try
            {
                //Warn. Превышено кол-во sata устр-в
                _errors.Remove(ErrorCode.SataCountWarn);
                if (motherboard.Sata2Count + motherboard.Sata3Count < _sataDeviceCount)
                {
                    _errors.Add(ErrorCode.SataCountWarn, Error.CreateByCode(ErrorCode.SataCountWarn));
                }
            }
            catch { }
            try
            {
                //Warn. Превышено кол-во m2 устр-в
                _errors.Remove(ErrorCode.M2CountWarn);
                if (motherboard.M2Count < _m2DeviceCount)
                {
                    _errors.Add(ErrorCode.M2CountWarn, Error.CreateByCode(ErrorCode.M2CountWarn));
                }
            }
            catch { }
            try
            {
                //Warn. Нет разъема видеовыхода
                _errors.Remove(ErrorCode.MotherboardGraphicIntefaceWarn);
                if (ProcessorId != null && Processor.GpuExist)
                {
                    if (!(motherboard.HdmiCount > 0 || motherboard.DisplayPortCount > 0 || motherboard.VgaCount > 0))
                    {
                        _errors.Add(ErrorCode.MotherboardGraphicIntefaceWarn, Error.CreateByCode(ErrorCode.MotherboardGraphicIntefaceWarn));
                    }
                }
            }
            catch { }
        }

        private void PsuError(PsuCitilink psu)
        {
            try
            {
                //Warn
                _errors.Remove(ErrorCode.PsuExistsWarn);
                if (CasingId != null && Casing.PsuPower > 0)
                {
                    _errors.Add(ErrorCode.PsuExistsWarn, Error.CreateByCode(ErrorCode.PsuExistsWarn));
                }
                return;
            }
            catch { }
            try
            {
                //Crit. Длинна БП превышает допустимую
                _errors.Remove(ErrorCode.PsuLenghtError);
                if (CasingId != null && Casing.PsuLenghtMax > 0 && Casing.PsuPower < 1 && Casing.PsuLenghtMax < int.Parse(psu.Size.GetFirstInt()))
                {
                    _errors.Add(ErrorCode.PsuLenghtError, Error.CreateByCode(ErrorCode.PsuLenghtError));
                }
            }
            catch { }
        }

        private void RamError(RamCitilink ram)
        {
            try
            {
                //Crit. Не подходит разъем ОЗУ
                _errors.Remove(ErrorCode.RamSocketError);
                if (MotherboardId != null && !ram.Type.StartsWith(MotherboardRamType))
                {
                    _errors.Add(ErrorCode.RamSocketError, Error.CreateByCode(ErrorCode.RamSocketError));
                }
                //Конфликт Dimm и So-Dimm
                if (MotherboardId != null && !ram.FormFactor.StartsWith(Motherboard.RamType))
                {
                    _errors.Add(ErrorCode.RamSocketError, Error.CreateByCode(ErrorCode.RamSocketError));
                }
            }
            catch { }
        }

        private void SsdError(SsdCitilink ssd)
        {
            try
            {
                //Warn. Количество жестких жисков больше
                _errors.Remove(ErrorCode.SataCountWarn);
                if (MotherboardId != null)
                {
                    if (Motherboard.Sata2Count + Motherboard.Sata3Count - _sataDeviceCount < 1 && !ssd.FormFactor.StartsWith("M.2"))
                        _errors.Add(ErrorCode.SataCountWarn, Error.CreateByCode(ErrorCode.SataCountWarn));
                }
            }
            catch { }
            try
            {
                //ErrorCode.NotFoundM2Error
                _errors.Remove(ErrorCode.NotFoundM2Error);
                if (MotherboardId != null)
                {
                    if (Motherboard.M2Count < 1 && ssd.FormFactor.StartsWith("M.2"))
                        _errors.Add(ErrorCode.NotFoundM2Error, Error.CreateByCode(ErrorCode.NotFoundM2Error));
                }
            }
            catch { }
            try
            {
                //ErrorCode.M2CountWarn
                _errors.Remove(ErrorCode.M2CountWarn);
                if (MotherboardId != null)
                {
                    if (Motherboard.M2Count > 0 && Motherboard.M2Count - _m2DeviceCount < 1 && ssd.FormFactor.StartsWith("M.2"))
                        _errors.Add(ErrorCode.M2CountWarn, Error.CreateByCode(ErrorCode.M2CountWarn));
                }
            }
            catch { }
        }

        private void RamCountError()
        {
            _errors.Remove(ErrorCode.RamCountError);
            if (MotherboardId != null && Motherboard.RamCountDDR2 + Motherboard.RamCountDDR3 + Motherboard.RamCountDDR4 + Motherboard.RamCountDDR5 < RamCount)
            {
                _errors.Add(ErrorCode.RamCountError, Error.CreateByCode(ErrorCode.RamCountError));
            }
        }

        public async Task UpdateAsync()
        {
            await Task.Run(() =>
            {
                if (HddId != null && Hdd.IntefaceType.StartsWith("SATA")) { _sataDeviceCount++; }
                if (SsdId != null && !Ssd.FormFactor.StartsWith("M.2")) { _sataDeviceCount++; }
                if (SsdId != null && Ssd.FormFactor.StartsWith("M.2")) { _m2DeviceCount++; }
                if (MotherboardId != null)
                {
                    if (Motherboard.RamCountDDR5 > 0)
                        _motherboardRamType = "DDR5";
                    if (Motherboard.RamCountDDR4 > 0)
                        _motherboardRamType = "DDR4";
                    if (Motherboard.RamCountDDR3 > 0)
                        _motherboardRamType = "DDR3";
                    if (Motherboard.RamCountDDR2 > 0)
                        _motherboardRamType = "DDR2";
                }
                //Детектим ошибки по существующим комплектующим
                if (AudiocardId.HasValue)
                {
                    AudiocardError(Audiocard);
                    _price += Audiocard.Price;
                }
                if (CasingId.HasValue)
                {
                    CasingError(Casing);
                    _price += Casing.Price;
                }
                if (CoolerId.HasValue)
                {
                    CoolerError(Cooler);
                    _price += Cooler.Price;
                    _powerConsumption += Cooler.PowerMax;
                }
                if (MotherboardId.HasValue)
                {
                    MotherboardError(Motherboard);
                    _price += Motherboard.Price;
                    _socket = Motherboard.Socket;
                }
                if (ProcessorId.HasValue)
                {
                    CpuError(Processor);
                    _price += Processor.Price;
                    _socket = Processor.Socket;
                    _powerConsumption += Processor.Heat;
                }
                if (GraphicCardId.HasValue) 
                { 
                    GpuError(GraphicCard);
                    _price += GraphicCard.Price;
                    _powerConsumption += GraphicCard.PowerMax;
                }
                if (HddId.HasValue)
                {
                    HddError(Hdd);
                    _price += Hdd.Price;
                    _powerConsumption += Hdd.PowerMax;
                }
                if (PsuId.HasValue)
                {
                    PsuError(Psu);
                    _price += Psu.Price;
                }
                if (RamId.HasValue)
                {
                    RamError(Ram);
                    RamCountError();
                    _price += Ram.Price * RamCount;
                    _memoryAmount = Ram.ModulCount * Ram.Capacity * RamCount;
                }
                if (SsdId.HasValue)
                {
                    SsdError(Ssd);
                    _price += Ssd.Price;
                    _powerConsumption += Ssd.PowerMax;
                }
            });
        }
    }

    public enum PartCode
    {
        Processor = 0,
        Audiocard = 1,
        Casing = 2,
        Cooler = 3,
        Gpu = 4,
        Hdd = 5,
        Motherboard = 6,
        Psu = 7,
        Ram = 8,
        Ssd = 9
    }

    public struct Error
    {
        public ErrorType Type { get; }
        public ErrorCode Code { get; }
        public string Message { get; }

        private Error(ErrorType type, ErrorCode code, string message)
        {
            Type = type;
            Code = code;
            Message = message;
        }

        public static Error CreateByCode(ErrorCode code)
        {
            return new Error(GetType(code), code, GetMessage(code));
        }

        private static ErrorType GetType(ErrorCode code)
        {
            if ((int)code < 1000)
            {
                return ErrorType.Critical;
            }
            if ((int)code < 10000)
            {
                return ErrorType.Warn;
            }
            return ErrorType.Info;
        }

        private static string GetMessage(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.SocketError:
                    {
                        return "Сокет процессора и материнской платы не совместим";
                    }
                case ErrorCode.RamSocketError:
                    {
                        return "Выбранная оперативная память не подходит к материнской плате";
                    }
                case ErrorCode.RamCountError:
                    {
                        return "Превышено возможное для установки количество модулей ОЗУ";
                    }
                case ErrorCode.NotFoundM2Error:
                    {
                        return "Материнская плата не имеет m.2 разъема для установки SSD";
                    }
                case ErrorCode.FormFactorMotherboardError:
                    {
                        return "Размер материнской платы больше, чем поддерживает корпус";
                    }
                case ErrorCode.ExtensionSlotsError:
                    {
                        return "Превышено количество слотов расширения корпуса (Система охлаждения видеокарты слишком большая)";
                    }
                case ErrorCode.GpuLenghtError:
                    {
                        return "Длинна видеокарты превышает допустимую корпусом";
                    }
                case ErrorCode.HeightCoolerError:
                    {
                        return "Высота кулера превышает допустимую корпусом";
                    }
                case ErrorCode.PsuLenghtError:
                    {
                        return "Длинна БП превышает допустимую корпусом";
                    }
                case ErrorCode.CoolerSocketError:
                    {
                        return "Кулер не подходит для сокета";
                    }
                case ErrorCode.GpuInterfaceError:
                    {
                        return "Нет доступных интерфейсов для установки видеокарты";
                    }
                case ErrorCode.PciInterfaceCount:
                    {
                        return "Нет доступных PCI интерфейсов";
                    }
                case ErrorCode.PowerConsumptionWarn:
                    {
                        return "Общая потребляемая мощность больше выдаваемой блоком питания";
                    }
                case ErrorCode.TdpWarn:
                    {
                        return "Tdp Процессора превышает возможности Кулера";
                    }
                case ErrorCode.MotherboardGraphicIntefaceWarn:
                    {
                        return "Нет разъема видеовыхода на материнской плате";
                    }
                case ErrorCode.SataCountWarn:
                    {
                        return "Превышено кол-во sata устройств";
                    }
                case ErrorCode.M2CountWarn:
                    {
                        return "Превышено кол-во m.2 устройств";
                    }
                case ErrorCode.CasingNotSupportWaterWarn:
                    {
                        return "Корпус не поддерживает установку СВО";
                    }
                case ErrorCode.GpuInterfaceWarn:
                    {
                        return "У Видеокарты более новый интерфейс, чем у материнской платы";
                    }
                case ErrorCode.PsuExistsWarn:
                    {
                        return "В корпусе уже установлен блок питания. Выбор нового блока питания невозможен";
                    }
                case ErrorCode.NotGpuLenghtInfo:
                    {
                        return "У корпуса нет информации о возможной длине Видеокарты";
                    }
                case ErrorCode.NotPsuLenghtInfo:
                    {
                        return "У корпуса нет информации о возможной длине БП";
                    }
                case ErrorCode.NotCoolerHeightInfo:
                    {
                        return "У корпуса нет информации о возможной высоте Кулера";
                    }
                case ErrorCode.NotTdpCoolerInfo:
                    {
                        return "У кулера нет информации о максимальном TDP";
                    }
                default:
                    {
                        return "Code not found";
                    }
            }
        }
    }

    public enum ErrorType
    {
        Critical = 0,
        Warn = 1000,
        Info = 10000
    }

    public enum ErrorCode
    {
        #region Critical Errors
        /// <summary>
        /// Crit. Не подходит сокет
        /// </summary>
        SocketError = 0,
        /// <summary>
        /// Crit. Не подходит разъем ОЗУ
        /// </summary>
        RamSocketError,
        /// <summary>
        /// Crit. Превышено количество плашек ОЗУ
        /// </summary>
        RamCountError,
        /// <summary>
        /// Crit. Нет m2 разъема
        /// </summary>
        NotFoundM2Error,
        /// <summary>
        /// Crit. Форм фактор не подходит для мат.платы
        /// </summary>
        FormFactorMotherboardError,
        /// <summary>
        /// Crit. Превышено кол-во слотов расширения (для видеокарты)
        /// </summary>
        ExtensionSlotsError,
        /// <summary>
        /// Crit. Длинна видеокарты превышает допустимую
        /// </summary>
        GpuLenghtError,
        /// <summary>
        /// Crit. Высота кулера превышает допустимую
        /// </summary>
        HeightCoolerError,
        /// <summary>
        /// Crit. Длинна БП превышает допустимую
        /// </summary>
        PsuLenghtError,
        /// <summary>
        /// Crit. Кулер не подходит для сокета
        /// </summary>
        CoolerSocketError,
        /// <summary>
        /// Crit. Не доступный интерфейс
        /// </summary>
        GpuInterfaceError,
        /// <summary>
        /// Crit. Нет доступных интерфейсов Pci
        /// </summary>
        PciInterfaceCount,
        #endregion

        #region Warns
        /// <summary>
        /// Warn. Общая потребляемая мощность больше блока питания
        /// </summary>
        PowerConsumptionWarn = 1000,
        /// <summary>
        /// Warn. Tdp Процессора превышает возможности Кулера
        /// </summary>
        TdpWarn,
        /// <summary>
        /// Warn. Нет разъема видеовыхода на мат.плате
        /// </summary>
        MotherboardGraphicIntefaceWarn,
        /// <summary>
        /// Warn. Превышено кол-во sata устр-в
        /// </summary>
        SataCountWarn,
        /// <summary>
        /// Warn. Превышено кол-во m2 устр-в
        /// </summary>
        M2CountWarn,
        /// <summary>
        /// Warn. Корпус не поддерживает установку СВО
        /// </summary>
        CasingNotSupportWaterWarn,
        /// <summary>
        /// Warn. У Видеокарты более новый интерфейс, чем у мат.платы
        /// </summary>
        GpuInterfaceWarn,
        /// <summary>
        /// Warn. Блок питание есть в корпусе
        /// </summary>
        PsuExistsWarn,
        #endregion

        #region Info
        /// <summary>
        /// Info. У корпуса нет информации о высоте Кулера
        /// </summary>
        NotCoolerHeightInfo = 10000,
        /// <summary>
        /// Info. У корпуса нет информации о длине БП
        /// </summary>
        NotPsuLenghtInfo,
        /// <summary>
        /// Info. У корпуса нет информации о длине Видеокарты
        /// </summary>
        NotGpuLenghtInfo,
        /// <summary>
        /// Info. У кулера нет информации о максимальном TDP
        /// </summary>
        NotTdpCoolerInfo
        #endregion
    }
}
