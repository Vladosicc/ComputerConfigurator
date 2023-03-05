using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ComputerConfigurator.Models.Citilink
{
    public class ProductCitilink : IProduct
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        /// <summary>
        /// Цена р.
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Ссылка на товар
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        [MaybeNull]
        public string PictureUrl { get; set; }
        /// <summary>
        /// Время последнего обновления
        /// </summary>
        [Required]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime LastAccessTime { get; set; } = DateTime.Now;

        public static bool operator ==(ProductCitilink item1, ProductCitilink item2)
        {
            return item1.Id == item2.Id && item1.Price == item2.Price && item1.Url.StartsWith(item2.Url);
        }

        public static bool operator !=(ProductCitilink item1, ProductCitilink item2)
        {
            return item1.Id != item2.Id || item1.Price != item2.Price || !item1.Url.StartsWith(item2.Url);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProductCitilink))
                return false;
            return this == obj as ProductCitilink;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
