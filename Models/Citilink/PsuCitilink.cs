using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerConfigurator.Models;

namespace ComputerConfigurator.Models.Citilink
{
    public class PsuCitilink : ProductCitilink, IProduct
    {
        /// <summary>
        /// Брэнд
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
        /// Форм-фактор
        /// </summary>
        [MaybeNull]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; }
        /// <summary>
        /// Версия ATX
        /// </summary>
        [MaybeNull]
        [Display(Name = "Версия ATX")]
        public string AtxVersion { get; set; }
        /// <summary>
        /// Мощность
        /// </summary>
        [Required]
        [Display(Name = "Мощность")]
        public int Power { get; set; }
        /// <summary>
        /// Отсоединяющиеся кабели
        /// </summary>
        [Required]
        [Display(Name = "Отсоединяющиеся кабели")]
        public bool IsModular { get; set; }
        /// <summary>
        /// Сертифицирован в стандарте
        /// </summary>
        [MaybeNull]
        [Display(Name = "Сертифицирован в стандарте")]
        public string Certificate { get; set; }
        /// <summary>
        /// Активный PFC
        /// </summary>
        [MaybeNull]
        [Display(Name = "Активный PFC")]
        public bool Pfc { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        [MaybeNull]
        [Display(Name = "Цвет")]
        public string Color { get; set; }
        /// <summary>
        /// Питание материнской платы и процессора
        /// </summary>
        [MaybeNull]
        [Display(Name = "Питание материнской платы и процессора")]
        public string MotherboardConnector { get; set; }
        /// <summary>
        /// Питание видеокарты
        /// </summary>
        [MaybeNull]
        [Display(Name = "Питание видеокарты")]
        public string GraphicCardConnector { get; set; }
        /// <summary>
        /// Разъемы SATA
        /// </summary>
        [Required]
        [Display(Name = "Разъемы SATA")]
        public int SataCount { get; set; }
        /// <summary>
        /// Разъемы Peripheral (Molex)
        /// </summary>
        [Required]
        [Display(Name = "Разъемы Peripheral (Molex)")]
        public int MolexCount { get; set; }
        /// <summary>
        /// Разъемы для FDD
        /// </summary>
        [Required]
        [Display(Name = "Разъемы для FDD")]
        public int FddCount { get; set; }
        /// <summary>
        /// Размер вентилятора(ов)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Размер вентилятора(ов)")]
        public string FanSize { get; set; }
        /// <summary>
        /// Количество вентиляторов
        /// </summary>
        [MaybeNull]
        [Display(Name = "Количество вентиляторов")]
        public string FanCount { get; set; }
        /// <summary>
        /// Терморегулятор оборотов
        /// </summary>
        [Required]
        [Display(Name = "Терморегулятор оборотов")]
        public bool ThermalRegulator { get; set; }
        /// <summary>
        /// Размеры (ШхВхГ)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Размеры (ШхВхГ)")]
        public string Size { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public override string ToString()
        {
            return Brand + " " + Model + " " + Power + "W";
        }
    }
}
