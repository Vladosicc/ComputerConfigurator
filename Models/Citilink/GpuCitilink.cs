using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ComputerConfigurator.Helpers;
using ComputerConfigurator.Models;

namespace ComputerConfigurator.Models.Citilink
{
    public class GpuCitilink : ProductCitilink, IProduct
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
        /// Интерфейс
        /// </summary>
        [Required]
        [Display(Name = "Интерфейс")]
        public string Interface { get; set; }

        /// <summary>
        /// Производитель чипа
        /// </summary>
        [MaybeNull]
        [Display(Name = "Производитель чипсета")]
        public string ChipsetBrand { get; set; }

        /// <summary>
        /// Модель чипа
        /// </summary>
        [MaybeNull]
        [Display(Name = "Модель чипсета")]
        public string ChipsetModel { get; set; }

        /// <summary>
        /// Частота графического процессора
        /// </summary>
        [MaybeNull]
        [Display(Name = "Частота")]
        public string Frequency { get; set; }

        /// <summary>
        /// Техпроцесс (нм)
        /// </summary>
        [Required]
        [Display(Name = "Тех. процесс (нм)")]
        public int TechProc { get; set; }

        /// <summary>
        /// Объем видеопамяти (Гб)
        /// </summary>
        [Required]
        [Display(Name = "Объем видеопамяти")]
        public int MemoryAmount { get; set; }

        /// <summary>
        /// Тип видеопамяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип видеопамяти")]
        public string MemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        [MaybeNull]
        [Display(Name = "Частота видеопамяти")]
        public string MemoryFreq { get; set; }

        /// <summary>
        /// Разрядность шины видеопамяти (bit)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Разрядность шины видеопамяти (bit)")]
        public string MemoryBusBit { get; set; }

        /// <summary>
        /// Максимальное разрешение
        /// </summary>
        [MaybeNull]
        [Display(Name = "Максимальное разрешение")]
        public string ResolutionMax { get; set; }

        /// <summary>
        /// Поддержка технологий
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддержка технологий")]
        public string DirectXOpenGlVer { get; set; }

        /// <summary>
        /// Поддержка трассировки лучей
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддержка трассировки лучей")]
        public string RayTracing { get; set; }

        /// <summary>
        /// Поддержка технологий NVIDIA
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддержка технологий NVIDIA")]
        public string NvidiaSupport { get; set; }

        /// <summary>
        /// Поддержка DLSS
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддержка DLSS")]
        public string DlssSupport { get; set; }

        //Разъемы-------------------------------------------------------------------

        /// <summary>
        /// Разъемы DVI
        /// </summary>
        [MaybeNull]
        [Display(Name = "Разъемы DVI")]
        public int DviCount { get; set; }

        /// <summary>
        /// Разъемов HDMI
        /// </summary>
        [MaybeNull]
        [Display(Name = "Разъемов HDMI")]
        public int HdmiCount { get; set; }

        /// <summary>
        /// Разъемов Display Port
        /// </summary>
        [MaybeNull]
        [Display(Name = "Разъемов Display Port")]
        public int DisplayPortCount { get; set; }

        /// <summary>
        /// Версия разъема HDMI
        /// </summary>
        [MaybeNull]
        [Display(Name = "Версия разъема HDMI")]
        public string HdmiVer { get; set; }

        /// <summary>
        /// Версия разъема Display Port
        /// </summary>
        [MaybeNull]
        [Display(Name = "Версия разъема Display Port")]
        public string DisplayPortVer { get; set; }

        /// <summary>
        /// Количество поддерживаемых мониторов
        /// </summary>
        [MaybeNull]
        [Display(Name = "Количество поддерживаемых мониторов")]
        public int MonitorCount { get; set; }

        //Питание -------------------------------------------------

        /// <summary>
        /// Разъемы дополнительного питания
        /// </summary>
        [MaybeNull]
        [Display(Name = "Разъемы дополнительного питания")]
        public string ConnectorType { get; set; }

        /// <summary>
        /// Максимальное энергопотребление (Вт)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Максимальное энергопотребление (Вт)")]
        public int PowerMax { get; set; }

        /// <summary>
        /// Рекомендуемая производителем мощность БП (Вт)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Рекомендуемая производителем мощность БП (Вт)")]
        public int PowerReccomended { get; set; }

        //Размеры --------------------------------------------------------

        /// <summary>
        /// Длина видеокарты (mm)
        /// </summary>
        [Required]
        [Display(Name = "Длина видеокарты (mm)")]
        public int Lenght { get; set; }

        /// <summary>
        /// Толщина видеокарты (mm)
        /// </summary>
        [Required]
        [Display(Name = "Толщина видеокарты (mm)")]
        public int Thickness { get; set; }

        /// <summary>
        /// Высота видеокарты (mm)
        /// </summary>
        [Required]
        [Display(Name = "Высота видеокарты (mm)")]
        public int Height { get; set; }

        /// <summary>
        /// Ширина видеокарты (mm)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Ширина видеокарты (mm)")]
        public string Width { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public GpuCitilink() { }

        public override string ToString()
        {
            return Brand + " " + ChipsetBrand + " " + ChipsetModel;
        }
    }
}
