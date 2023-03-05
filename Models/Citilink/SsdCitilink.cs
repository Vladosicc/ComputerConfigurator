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
    public class SsdCitilink : ProductCitilink, IProduct
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
        /// Тип жесткого диска
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип жесткого диска")]
        public string TypeDisk { get; set; }
        /// <summary>
        /// Объем накопителя (Гб)
        /// </summary>
        [Required]
        [Display(Name = "Объем накопителя (Гб)")]
        public int Capacity { get; set; }
        /// <summary>
        /// Форм-фактор
        /// </summary>
        [MaybeNull]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; }
        /// <summary>
        /// Интерфейс
        /// </summary>
        [Required]
        [Display(Name = "Интерфейс")]
        public string Inteface { get; set; }
        /// <summary>
        /// Тип памяти NAND
        /// </summary>
        [MaybeNull]
        [Display(Name = "Тип памяти NAND")]
        public string NandType { get; set; }
        /// <summary>
        /// Поддержка NVMe
        /// </summary>
        [Required]
        [Display(Name = "Поддержка NVMe")]
        public bool Nvme { get; set; }
        /// <summary>
        /// Максимальная скорость чтения (Mb/s)
        /// </summary>
        [Required]
        [Display(Name = "Максимальная скорость чтения (Mb/s)")]
        public int SpeedReadMax { get; set; }
        /// <summary>
        /// Максимальная скорость записи (Mb/s)
        /// </summary>
        [Required]
        [Display(Name = "Максимальная скорость записи (Mb/s)")]
        public int SpeedWriteMax { get; set; }
        /// <summary>
        /// Ресурс TBW (Tb)
        /// </summary>
        [Required]
        [Display(Name = "Ресурс TBW (Tb)")]
        public int Tbw { get; set; }
        /// <summary>
        /// Время наработки на отказ
        /// </summary>
        [Required]
        [Display(Name = "Время наработки на отказ")]
        public int TimeToFail { get; set; }
        /// <summary>
        /// Потребляемая мощность
        /// </summary>
        [Required]
        [Display(Name = "Потребляемая мощность")]
        public double PowerMax { get; set; }

        /// <summary>
        /// Конфикурации, в которых используется
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<ConfigurationCitilink> Configurations { get; set; }

        public override string ToString()
        {
            return Brand + " " + Model + " " + Capacity;
        }
    }
}
