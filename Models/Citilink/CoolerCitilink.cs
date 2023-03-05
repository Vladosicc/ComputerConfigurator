using ComputerConfigurator.Models.Citilink;
using ComputerConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ComputerConfigurator.Models.NotDetail;

namespace ComputerConfigurator.Models.Citilink
{
    public class CoolerCitilink : ProductCitilink, IProduct
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
        /// Тип охлаждения
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип охлаждения")]
        public string Type { get; set; }
        /// <summary>
        /// Количество вентиляторов
        /// </summary>
        [Required]
        [Display(Name = "Количество вентиляторов")]
        public int FanCount { get; set; }
        /// <summary>
        /// Размер вентилятора (mm)
        /// </summary>
        [Required]
        [Display(Name = "Размер вентилятора (mm)")]
        public int FanSize { get; set; }
        /// <summary>
        /// Направление выдува
        /// </summary>
        [MaybeNull]
        [Display(Name = "Направление выдува")]
        public string BlowDirection { get; set; }
        /// <summary>
        /// Воздушный поток вентилятора (cfm)
        /// </summary>
        [Required]
        [Display(Name = "Воздушный поток вентилятора (cfm)")]
        public double BlowPowerCfm { get; set; }
        /// <summary>
        /// Уровень шума вентилятора
        /// </summary>
        [MaybeNull]
        [Display(Name = "Уровень шума вентилятора")]
        public string NoiseLevel { get; set; }
        /// <summary>
        /// Скорость вращения вентилятора
        /// </summary>
        [MaybeNull]
        [Display(Name = "Скорость вращения вентилятора")]
        public string FanSpeed { get; set; }
        /// <summary>
        /// Тип подшипника
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип подшипника")]
        public string BearingType { get; set; }
        /// <summary>
        /// Максимальное тепловыделение процессора (w)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Максимальное тепловыделение процессора (w)")]
        public int TdpMax { get; set; }

        /// <summary>
        /// Поддерживаемые сокеты
        /// </summary>
        [MaybeNull]
        [Display(Name = "Поддерживаемые сокеты")]
        public virtual List<SocketModel> SocketSupport { get; set; }= new List<SocketModel>();
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<SocketCooler> SocketCoolers { get; set; } = new List<SocketCooler>();

        /// <summary>
        /// Основание кулера
        /// </summary>
        [MaybeNull]
        [Display(Name = "Основание кулера")]
        public string Base { get; set; }
        /// <summary>
        /// Использование тепловых трубок
        /// </summary>
        [Required]
        [Display(Name = "Использование тепловых трубок")]
        public bool UsePipes { get; set; }

        /// <summary>
        /// Питание вентилятора от материнской платы
        /// </summary>
        [MaybeNull]
        [Display(Name = "Питание вентилятора от материнской платы")]
        public string Connector { get; set; }
        /// <summary>
        /// Потребляемая мощность вентилятора
        /// </summary>
        [Required]
        [Display(Name = "Потребляемая мощность вентилятора")]
        public double PowerMax { get; set; }
        /// <summary>
        /// Подсветка
        /// </summary>
        [Required]
        [Display(Name = "Подсветка")]
        public bool Lighting { get; set; }
        /// <summary>
        /// Длина кулера
        /// </summary>
        [Required]
        [Display(Name = "Длина кулера")]
        public int Lenght { get; set; }
        /// <summary>
        /// Ширина кулера
        /// </summary>
        [Required]
        [Display(Name = "Ширина кулера")]
        public int Width { get; set; }
        /// <summary>
        /// Высота кулера
        /// </summary>
        [Required]
        [Display(Name = "Высота кулера")]
        public int Height { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public override string ToString()
        {
            return Brand + " " + Model;
        }
    }
}
