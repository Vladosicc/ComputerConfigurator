using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ComputerConfigurator.Models.NotDetail
{
    public class RamModel
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public static RamModel GetByDescription(string Description)
        {
            return RamList.FirstOrDefault(s => s.Description.Contains(Description.Trim().Replace(" ", "").ToUpper().Replace("SOCKET", "")));
        }

        private static IReadOnlyCollection<RamModel> _ramList;

        private static IReadOnlyCollection<RamModel> RamList { get { return _ramList == null ? getRam() : _ramList; } }

        private static IReadOnlyCollection<RamModel> getRam()
        {
            List<RamModel> sockets = new List<RamModel>();
            int counter = 0;
            //INTEL
            sockets.Add(new RamModel() { Id = 100 + counter++, Description = "DDR" });
            sockets.Add(new RamModel() { Id = 101 + counter++, Description = "DDR2" });
            sockets.Add(new RamModel() { Id = 102 + counter++, Description = "DDR3" });
            sockets.Add(new RamModel() { Id = 103 + counter++, Description = "DDR4" });
            sockets.Add(new RamModel() { Id = 104 + counter++, Description = "DDR5" });
            sockets.Add(new RamModel() { Id = 105 + counter++, Description = "DDR6" });
            _ramList = sockets.AsReadOnly();
            return _ramList;
        }
    }
}
