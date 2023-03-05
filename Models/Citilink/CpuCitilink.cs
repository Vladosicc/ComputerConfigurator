using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ComputerConfigurator.Helpers;
using ComputerConfigurator.Models.NotDetail;
using ComputerConfigurator.Models;

namespace ComputerConfigurator.Models.Citilink
{
    public class CpuCitilink : ProductCitilink, IProduct
    {
        /// <summary>
        /// Бренд
        /// </summary>
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; } = string.Empty;
        /// <summary>
        /// Модель
        /// </summary>
        [MaybeNull]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        /// <summary>
        /// Имя ядра
        /// </summary>
        [Required]
        [Display(Name = "Имя ядра")]
        public string CoreName { get; set; }
        /// <summary>
        /// Сокет
        /// </summary>
        [Required]
        public int IdSocket { get; set; }
        [ForeignKey(nameof(IdSocket))]
        [Display(Name = "Сокет")]
        public virtual SocketModel Socket { get; set; }
        /// <summary>
        /// Количество ядер
        /// </summary>
        [Required]
        [Display(Name = "Количество ядер")]
        public int CountOfCores { get; set; }
        /// <summary>
        /// Количество потоков
        /// </summary>
        [Required]
        [Display(Name = "Количество потоков")]
        public int CountOfThreads { get; set; }
        /// <summary>
        /// Частота
        /// </summary>
        [Required]
        [Display(Name = "Частота")]
        public string Frequency { get; set; }
        /// <summary>
        /// L3 кэш
        /// </summary>
        [MaybeNull]
        [Display(Name = "L3 кэш")]
        public string L3cache { get; set; }
        /// <summary>
        /// Разрядность
        /// </summary>
        [Required]
        [Display(Name = "Разрядность")]
        public int Bit { get; set; }
        /// <summary>
        /// Техпроцесс (нм)
        /// </summary>
        [Required]
        [Display(Name = "Техпроцесс (нм)")]
        public int TechProc { get; set; }
        /// <summary>
        /// Множитель.
        /// True - Разблокирован.
        /// False - Заблокирован.
        /// </summary>
        [Required]
        [Display(Name = "Множитель")]
        public bool Multiplier { get; set; }
        /// <summary>
        /// Пропускная способность шины (GT/s)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Пропускная способность шины (GT/s)")]
        public string BusCapacity { get; set; }
        /// <summary>
        /// Тепловыделение (Вт)
        /// </summary>
        [Required]
        [Display(Name = "Тепловыделение (Вт)")]
        public int Heat { get; set; }
        /// <summary>
        /// Максимальная температура
        /// </summary>
        [Required]
        [Display(Name = "Максимальная температура")]
        public int MaxTemperature { get; set; }
        /// <summary>
        /// Тип поставки
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип поставки")]
        public string Package { get; set; }

        //Спецификации памяти--------------------------------------------------        

        /// <summary>
        /// Максимальный объем памяти (Гб)
        /// </summary>
        [Required]
        [Display(Name = "Максимальный объем памяти (Гб)")]
        public int RamMax { get; set; }
        /// <summary>
        /// Тип памяти
        /// </summary>
        [Required]
        [Display(Name = "Тип памяти")]
        public string RamType { get; set; }
        /// <summary>
        /// Поддержка частот памяти (МГц)
        /// </summary>
        [Required]
        [Display(Name = "Поддержка частот памяти (МГц)")]
        public int RamFreq { get; set; }
        /// <summary>
        /// Количество каналов памяти
        /// </summary>
        [Required]
        [Display(Name = "Количество каналов памяти")]
        public int RamCountOfChannels { get; set; }
        /// <summary>
        /// Пропускная способность памяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Пропускная способность памяти")]
        public string RamBusCapacity { get; set; }
        /// <summary>
        /// Поддержка памяти ECC
        /// </summary>
        [Required]
        [Display(Name = "Поддержка памяти ECC")]
        public bool RamEccReg { get; set; }

        //Спецификации PCI--------------------------------------------------

        /// <summary>
        /// Версия PCI Express
        /// </summary>
        [MaybeNull]
        [Display(Name = "Версия PCI Express")]
        public string PciVer { get; set; }
        /// <summary>
        /// Количество каналов PCI Express
        /// </summary>
        [Required]
        [Display(Name = "Количество каналов PCI Express")]
        public int PciCountOfChannels { get; set; }
        /// <summary>
        /// Конфигурация PCI Express
        /// </summary>
        [MaybeNull]
        [Display(Name = "Конфигурация PCI Express")]
        public string PciConfiguration { get; set; }

        //Спецификации Видеоядра--------------------------------------------------

        /// <summary>
        /// Встроенное графическое ядро
        /// </summary>
        [Required]
        [Display(Name = "Встроенное графическое ядро")]
        public bool GpuExist { get; set; }
        /// <summary>
        /// Модель графического ядра
        /// </summary>
        [MaybeNull]
        [Display(Name = "Модель графического ядра")]
        public string GpuModel { get; set; }
        /// <summary>
        /// Частота графического ядра
        /// </summary>
        [MaybeNull]
        [Display(Name = "Частота графического ядра")]
        public string GpuFreq { get; set; }
        /// <summary>
        /// Максимальный объем видеопамяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Максимальный объем видеопамяти")]
        public int GpuMemory { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public CpuCitilink() { BusCapacity = string.Empty; }

        public CpuCitilink(string Url)
        {
            Id = int.Parse(Url.GetLastInt());
            this.Url = Url.Replace("https", "http");
        }

        public override string ToString()
        {
            return Brand + " " + Model;
        }
    }
}
