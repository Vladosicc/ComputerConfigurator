using ComputerConfigurator.Models.NotDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerConfigurator.Models;
using System.Text.Json.Serialization;

namespace ComputerConfigurator.Models.Citilink
{
    public class CasingCitilink : ProductCitilink, IProduct
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
        /// Типоразмер
        /// </summary>
        [MaybeNull]
        [Display(Name = "Типоразмер")]
        public string Type { get; set; }
        /// <summary>
        /// Форм фактор
        /// </summary>
        [Required]
        public int IdFormFactor { get; set; }
        [ForeignKey(nameof(IdFormFactor))]
        [Display(Name = "Форм фактор")]
        public virtual MotherboardFormFactor FormFactor { get; set; }
        /// <summary>
        /// Отсеки 2,5" внутренние
        /// </summary>
        [Required]
        [Display(Name = "Отсеки 2,5\" внутренние")]
        public int CountSection2_5 { get; set; }
        /// <summary>
        /// Отсеки 3,5" внутренние
        /// </summary>
        [Required]
        [Display(Name = "Отсеки 3,5\" внутренние")]
        public int CountSection3_5 { get; set; }
        /// <summary>
        /// Особенности внутренних отсеков
        /// </summary>
        [MaybeNull]
        [Display(Name = "Особенности внутренних отсеков")]
        public string SpecificationSection { get; set; }
        /// <summary>
        /// Количество слотов расширения
        /// </summary>
        [Required]
        [Display(Name = "Количество слотов расширения")]
        public int CountSlotsExtension { get; set; }
        /// <summary>
        /// Размещение HDD
        /// </summary>
        [MaybeNull]
        [Display(Name = "Размещение HDD")]
        public string LocationHdd { get; set; }
        /// <summary>
        /// Максимальная длина видеокарты
        /// </summary>
        [Required]
        [Display(Name = "Максимальная длина видеокарты")]
        public int GraphicCardMaxLenght { get; set; }
        /// <summary>
        /// Максимальная высота кулера процессора
        /// </summary>
        [Required]
        [Display(Name = "Максимальная высота кулера процессора")]
        public int CoolerHeightMax { get; set; }
        /// <summary>
        /// Максимальная длина блока питания
        /// </summary>
        [Required]
        [Display(Name = "Максимальная длина блока питания")]
        public int PsuLenghtMax { get; set; }
        /// <summary>
        /// Фронтальные разъемы USB 3
        /// </summary>
        [Required]
        [Display(Name = "Фронтальные разъемы USB 3")]
        public int CountUSB3 { get; set; }
        /// <summary>
        /// Фронтальные разъемы USB 3.1 Type-C
        /// </summary>
        [Required]
        [Display(Name = "Фронтальные разъемы USB 3.1 Type-C")]
        public int CountUSB31TypeC { get; set; }
        /// <summary>
        /// Фронтальные разъемы USB 2
        /// </summary>
        [Required]
        [Display(Name = "Фронтальные разъемы USB 2")]
        public int CountUSB2 { get; set; }
        /// <summary>
        /// Фронтальные аудио-разъемы
        /// </summary>
        [Required]
        [Display(Name = "Фронтальные аудио-разъемы")]
        public bool AudioJack { get; set; }
        /// <summary>
        /// Вентиляторы на передней панели
        /// </summary>
        [MaybeNull]
        [Display(Name = "Вентиляторы на передней панели")]
        public string FrontFans { get; set; }
        /// <summary>
        /// Вентиляторы на задней панели
        /// </summary>
        [MaybeNull]
        [Display(Name = "Вентиляторы на задней панели")]
        public string BackFans { get; set; }
        /// <summary>
        /// Возможность установки вентиляторов
        /// </summary>
        [MaybeNull]
        [Display(Name = "Возможность установки вентиляторов")]
        public string AddFans { get; set; }
        /// <summary>
        /// Расположение БП
        /// </summary>
        [MaybeNull]
        [Display(Name = "Расположение БП")]
        public string PsuLocation { get; set; }
        /// <summary>
        /// Мощность БП
        /// </summary>
        [MaybeNull]
        [Display(Name = "Мощность БП")]
        public int PsuPower { get; set; }
        /// <summary>
        /// Сертифицирован в стандарте
        /// </summary>
        [MaybeNull]
        [Display(Name = "Сертифицирован в стандарте")]
        public string PsuCertificate { get; set; }
        /// <summary>
        /// Боковая панель
        /// </summary>
        [MaybeNull]
        [Display(Name = "Боковая панель")]
        public string SidePanel { get; set; }
        /// <summary>
        /// Материал прозрачной боковой панели
        /// </summary>
        [MaybeNull]
        [Display(Name = "Материал прозрачной боковой панели")]
        public string SidePanelMaterial { get; set; }
        /// <summary>
        /// Возможность установки СВО
        /// </summary>
        [Required]
        [Display(Name = "Возможность установки СВО")]
        public bool CanWater { get; set; }
        /// <summary>
        /// Цвет корпуса
        /// </summary>
        [MaybeNull]
        [Display(Name = "Цвет корпуса")]
        public string Color { get; set; }

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
