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
    public class MotherboardCitilink : ProductCitilink, IProduct
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
        /// Гнездо процессора
        /// </summary>
        [Required]
        public int IdSocket { get; set; }
        [ForeignKey(nameof(IdSocket))]
        [Display(Name = "Гнездо процессора")]
        public virtual SocketModel Socket { get; set; }
        /// <summary>
        /// Чипсет (Производитель)
        /// </summary>
        [Required]
        [Display(Name = "Чипсет (Производитель)")]
        public string ChipsetBrand { get; set; }
        /// <summary>
        /// Чипсет (Модель)
        /// </summary>
        [Required]
        [Display(Name = "Чипсет (Модель)")]
        public string ChipsetModel { get; set; }
        /// <summary>
        /// Тип поддерживаемой памяти
        /// </summary>
        [Required]
        [Display(Name = "Тип поддерживаемой памяти")]
        public string RamType { get; set; }
        /// <summary>
        /// Частотная спецификация памяти (МГц)
        /// </summary>
        [Required]
        [Display(Name = "Частотная спецификация памяти (МГц)")]
        public int RamFrequencyMax { get; set; }
        /// <summary>
        /// Поддержка частот оперативной памяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддержка частот оперативной памяти")]
        public string RamFrequency { get; set; }
        /// <summary>
        /// Слотов памяти DDR5
        /// </summary>
        [Required]
        [Display(Name = "Слотов памяти DDR5")]
        public int RamCountDDR5 { get; set; }
        /// <summary>
        /// Слотов памяти DDR4
        /// </summary>
        [Required]
        [Display(Name = "Слотов памяти DDR4")]
        public int RamCountDDR4 { get; set; }
        /// <summary>
        /// Слотов памяти DDR3
        /// </summary>
        [Required]
        [Display(Name = "Слотов памяти DDR3")]
        public int RamCountDDR3 { get; set; }
        /// <summary>
        /// Слотов памяти DDR2
        /// </summary>
        [Required]
        [Display(Name = "Слотов памяти DDR2")]
        public int RamCountDDR2 { get; set; }
        /// <summary>
        /// Максимальный объем оперативной памяти (Гб)
        /// </summary>
        [Required]
        [Display(Name = "Максимальный объем оперативной памяти (Гб)")]
        public int RamAmountMax { get; set; }
        /// <summary>
        /// Режим работы оперативной памяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Режим работы оперативной памяти")]
        public string RamMode { get; set; }
        /// <summary>
        /// Слотов PCI-E x1
        /// </summary>
        [Required]
        [Display(Name = "Слотов PCI-E x1")]
        public int PCIe1Count { get; set; }
        /// <summary>
        /// Слотов PCI-E 2.0
        /// </summary>
        [Required]
        [Display(Name = "Слотов PCI-E 2.0")]
        public int PCIe2Count { get; set; }
        /// <summary>
        /// Слотов PCI-E 3.0 x16
        /// </summary>
        [Required]
        [Display(Name = "Слотов PCI-E 3.0 x16")]
        public int PCIe3Count { get; set; }
        /// <summary>
        /// Слотов PCI-E 4.0 x16
        /// </summary>
        [Required]
        [Display(Name = "Слотов PCI-E 4.0 x16")]
        public int PCIe4Count { get; set; }
        /// <summary>
        /// Слотов PCI-E 5.0 x16
        /// </summary>
        [Required]
        [Display(Name = "Слотов PCI-E 5.0 x16")]
        public int PCIe5Count { get; set; }
        /// <summary>
        /// Скорость работы слотов PCI-E x16 в многоканальном режиме
        /// </summary>
        [MaybeNull]
        [Display(Name = "Скорость работы слотов PCI-E x16 в многоканальном режиме")]
        public string PCIeX16Speed { get; set; }
        /// <summary>
        /// Разъемов SATA3
        /// </summary>
        [Required]
        [Display(Name = "Разъемов SATA3")]
        public int Sata3Count { get; set; }
        /// <summary>
        /// Разъемов SATA2
        /// </summary>
        [Required]
        [Display(Name = "Разъемов SATA2")]
        public int Sata2Count { get; set; }
        /// <summary>
        /// Разъемов M.2
        /// </summary>
        [Required]
        [Display(Name = "Разъемов M.2")]
        public int M2Count { get; set; }
        /// <summary>
        /// Поддержка Intel Optane
        /// </summary>
        [Required]
        [Display(Name = "Поддержка Intel Optane")]
        public bool IntelOptane { get; set; }
        /// <summary>
        /// Поддержка SATA RAID
        /// </summary>
        [Required]
        [Display(Name = "Поддержка SATA RAID")]
        public bool SataRaid { get; set; }
        /// <summary>
        /// Кол-во внешних USB 3.0
        /// </summary>
        [Required]
        [Display(Name = "Кол-во внешних USB 3.0")]
        public int Usb30Count { get; set; }
        /// <summary>
        /// Кол-во внешних USB 3.1
        /// </summary>
        [Required]
        [Display(Name = "Кол-во внешних USB 3.1")]
        public int Usb31Count { get; set; }
        /// <summary>
        /// Кол-во внешних USB 2.0
        /// </summary>
        [Required]
        [Display(Name = "Кол-во внешних USB 2.0")]
        public int Usb20Count { get; set; }
        /// <summary>
        /// Разъемов D-Sub (VGA)
        /// </summary>
        [Required]
        [Display(Name = "Разъемов D-Sub (VGA)")]
        public int VgaCount { get; set; }
        /// <summary>
        /// Разъемов Display Port
        /// </summary>
        [Required]
        [Display(Name = "Разъемов Display Port")]
        public int DisplayPortCount { get; set; }
        /// <summary>
        /// Разъемов HDMI
        /// </summary>
        [Required]
        [Display(Name = "Разъемов HDMI")]
        public int HdmiCount { get; set; }
        /// <summary>
        /// Разъемов Thunderbolt
        /// </summary>
        [Required]
        [Display(Name = "Разъемов Thunderbolt")]
        public int ThunderboltCount { get; set; }
        /// <summary>
        /// Сетевой интерфейс
        /// </summary>
        [Required]
        [Display(Name = "Сетевой интерфейс")]
        public string NetworkInterface { get; set; }
        /// <summary>
        /// WiFi в стандартной поставке
        /// </summary>
        [Required]
        [Display(Name = "WiFi в стандартной поставке")]
        public bool Wifi { get; set; }
        /// <summary>
        /// Bluetooth в стандартной поставке
        /// </summary>
        [Required]
        [Display(Name = "Bluetooth в стандартной поставке")]
        public bool Bluetooth { get; set; }
        /// <summary>
        /// Звук
        /// </summary>
        [Required]
        [Display(Name = "Звук")]
        public string AudioType { get; set; }
        /// <summary>
        /// Аудио контроллер
        /// </summary>
        [MaybeNull]
        [Display(Name = "Аудио контроллер")]
        public string AudioController { get; set; }
        /// <summary>
        /// Форм-фактор
        /// </summary>
        [Required]
        public int IdFormFactor { get; set; }
        [Display(Name = "Форм-фактор")]
        [ForeignKey(nameof(IdFormFactor))]
        public virtual MotherboardFormFactor FormFactor { get; set; }
        /// <summary>
        /// Питание материнской платы и процессора
        /// </summary>
        [Required]
        [Display(Name = "Питание материнской платы и процессора")]
        public string PowerConnector { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public MotherboardCitilink() { }

        public MotherboardCitilink(string Url)
        {
            Id = int.Parse(Url.GetLastInt());
            this.Url = Url.Replace("https", "http");
        }

        public override string ToString()
        {
            return Brand + " " + ChipsetBrand + " " + ChipsetModel;
        }
    }
}
