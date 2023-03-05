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
    public class AudiocardCitilink : ProductCitilink, IProduct
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
        /// Интерфейс
        /// </summary>
        [Required]
        [Display(Name = "Интерфейс")]
        public string Interface { get; set; }
        /// <summary>
        /// Звуковая схема
        /// </summary>
        [MaybeNull]
        [Display(Name = "Звуковая схема")]
        public string Sound { get; set; }

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
