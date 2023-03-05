using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ComputerConfigurator.Models;

namespace ComputerConfigurator.Models.Citilink
{
    public class HddCitilink : ProductCitilink, IProduct
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
        /// Тип жесткого диска
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип жесткого диска")]
        public string TypeHdd { get; set; }
        /// <summary>
        /// Форм-фактор
        /// </summary>
        [MaybeNull]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; }
        /// <summary>
        /// Объем накопителя
        /// </summary>
        [Required]
        [Display(Name = "Объем накопителя")]
        public int Capacity { get; set; }
        /// <summary>
        /// Буферная память
        /// </summary>
        [MaybeNull]
        [Display(Name = "Буферная память")]
        public string BufferCapacity { get; set; }
        /// <summary>
        /// Скорость вращения шпинделя (об/мин)
        /// </summary>
        [Required]
        [Display(Name = "Скорость вращения шпинделя (об/мин)")]
        public int SpeedSpin { get; set; }
        /// <summary>
        /// Интерфейс
        /// </summary>
        [Required]
        [Display(Name = "Интерфейс")]
        public string IntefaceType { get; set; }
        /// <summary>
        /// Максимальная скорость интерфейса
        /// </summary>
        [MaybeNull]
        [Display(Name = "Максимальная скорость интерфейса")]
        public string IntefaceMaxSpeed { get; set; }
        /// <summary>
        /// Средняя латентность (ms)
        /// </summary>
        [Required]
        [Display(Name = "Средняя латентность (ms)")]
        public int Latency { get; set; }
        /// <summary>
        /// Время наработки на отказ (ч)
        /// </summary>
        [Required]
        [Display(Name = "Время наработки на отказ (ч)")]
        public int TimeToFail { get; set; }
        /// <summary>
        /// Потребляемая мощность (Вт)
        /// </summary>
        [Required]
        [Display(Name = "Потребляемая мощность (Вт)")]
        public double PowerMax { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }


        public override string ToString()
        {
            return Brand + " " + TypeHdd + " " + Capacity;
        }
    }
}
