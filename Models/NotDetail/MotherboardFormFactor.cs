using ComputerConfigurator.Models.NotDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerConfigurator.Models.NotDetail
{
    public class MotherboardFormFactor
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public static MotherboardFormFactor GetByDescription(string Description)
        {
            Description = Description.Trim().ToUpper().Replace("-","");
            if(Description.Contains("MATX"))
            {
                return FormFactors.FirstOrDefault(i => i.Description == "MICROATX");
            }
            return FormFactors.FirstOrDefault(i => i.Description.StartsWith(Description));
        }

        private static IReadOnlyCollection<MotherboardFormFactor> _formfactors;

        public static IReadOnlyCollection<MotherboardFormFactor> FormFactors { get { return _formfactors == null ? getSockets() : _formfactors; } }

        private static IReadOnlyCollection<MotherboardFormFactor> getSockets()
        {
            List<MotherboardFormFactor> formFactors = new List<MotherboardFormFactor>();
            int counter = 0;
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "WTX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "EEATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "EATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "XLATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "ATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "MINIATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "MICROATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "FLEXATX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "MINIITX" });
            formFactors.Add(new MotherboardFormFactor() { Id = 100 + counter++, Description = "MINISTX" });
            _formfactors = formFactors.AsReadOnly();
            return _formfactors;
        }
    }
}
