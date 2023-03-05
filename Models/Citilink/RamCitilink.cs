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
    public class RamCitilink : ProductCitilink, IProduct
    {
        /// <summary>
        /// Брэнд
        /// </summary>
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        [MaybeNull]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        /// <summary>
        /// Форм-фактор
        /// </summary>
        [Required]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; }
        /// <summary>
        /// Тип памяти
        /// </summary>
        [Required]
        [Display(Name = "Тип памяти")]
        public string Type { get; set; }
        /// <summary>
        /// Объем модуля (Gb)
        /// </summary>
        [Required]
        [Display(Name = "Объем модуля (Gb)")]
        public int Capacity { get; set; }
        /// <summary>
        /// Количество контактов
        /// </summary>
        [MaybeNull]
        [Display(Name = "Количество контактов")]
        public string PinCount { get; set; }
        /// <summary>
        /// Количество модулей
        /// </summary>
        [Required]
        [Display(Name = "Количество модулей")]
        public int ModulCount { get; set; }
        /// <summary>
        /// Режим работы
        /// </summary>
        [MaybeNull]
        [Display(Name = "Режим работы")]
        public string ChannelsCount { get; set; }
        /// <summary>
        /// Показатель скорости
        /// </summary>
        [MaybeNull]
        [Display(Name = "Показатель скорости")]
        public string Speed { get; set; }
        /// <summary>
        /// Поддержка ECC
        /// </summary>
        [Required]
        [Display(Name = "Поддержка ECC")]
        public bool IsEcc { get; set; }
        /// <summary>
        /// Скорость (MGz)
        /// </summary>
        [Required]
        [Display(Name = "Скорость (MGz)")]
        public int Frequency { get; set; }
        /// <summary>
        /// Напряжение (V)
        /// </summary>
        [Required]
        [Display(Name = "Напряжение (V)")]
        public double Voltage { get; set; }
        /// <summary>
        /// Задержка
        /// </summary>
        [MaybeNull]
        [Display(Name = "Задержка")]
        public string Delay { get; set; }
        /// <summary>
        /// Латентность
        /// </summary>
        [MaybeNull]
        [Display(Name = "Латентность")]
        public string Latency { get; set; }
        /// <summary>
        /// Скорость (SPD)
        /// </summary>
        [Required]
        [Display(Name = "Скорость (SPD)")]
        public int FrequencyDefault { get; set; }
        /// <summary>
        /// Задержка (SPD)
        /// </summary>
        [MaybeNull]
        [Display(Name = "Задержка (SPD)")]
        public string DelayDefault { get; set; }
        /// <summary>
        /// Напряжение (SPD)
        /// </summary>
        [Required]
        [Display(Name = "Напряжение (SPD)")]
        public double VoltageDefault { get; set; }
        /// <summary>
        /// Количество чипов
        /// </summary>
        [Required]
        [Display(Name = "Количество чипов")]
        public int CountChip { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public RamCitilink()
        {
            ModulCount = 1;
            CountChip = -1;
        }

        public override string ToString()
        {
            return Brand + " " + Type + " " + Capacity;
        }
    }
}
