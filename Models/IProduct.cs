using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerConfigurator.Models
{
    public interface IProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }

        public DateTime LastAccessTime { get; set; }
    }
}
