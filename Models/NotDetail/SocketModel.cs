using ComputerConfigurator.Models.Citilink;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ComputerConfigurator.Models.NotDetail
{
    public class SocketModel
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Поддерживаемые куллеры ситилинка
        /// </summary>
        [MaybeNull]
        [System.Text.Json.Serialization.JsonIgnore] 
        public virtual List<CoolerCitilink> CoolerSupport { get; set; } = new List<CoolerCitilink>();
        [System.Text.Json.Serialization.JsonIgnore] 
        public virtual List<SocketCooler> SocketCoolers { get; set; } = new List<SocketCooler>();

        public static SocketModel GetByDescription(string Description)
        {
            return Sockets.FirstOrDefault(s => s.Description.Contains(Description.Trim().Replace(" ", "").ToUpper().Replace("SOCKET", "")));
        }

        private static IReadOnlyCollection<SocketModel> _sockets;

        public static IReadOnlyCollection<SocketModel> Sockets { get { return _sockets == null ? getSockets() : _sockets; } }

        private static IReadOnlyCollection<SocketModel> getSockets()
        {
            List<SocketModel> sockets = new List<SocketModel>();
            int counter = 0;
            //INTEL
            sockets.Add(new SocketModel() { Id = counter++, Description = "SOCKET370" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "SOCKET423" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "SOCKET478" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA775" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1366" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1156" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1155" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA2011" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1150" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA2011-3" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1151" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA2066" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1151V2" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1200" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1700" });
            sockets.Add(new SocketModel() { Id = counter++, Description = "LGA1851" });
            //INTELserver
            counter = 0;
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA1567" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA1366" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA1356" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA1356-3" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA2011-1" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA3647" });
            sockets.Add(new SocketModel() { Id = 100 + counter++, Description = "LGA4189" });
            //AMD
            counter = 0;
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "SOCKET754" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "SOCKET939" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM2" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM2+" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM3" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM3+" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "FM1" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "FM2" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "FM2+" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM1" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM4" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "TR4" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "STRX4" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "SWRX8" });
            sockets.Add(new SocketModel() { Id = 300 + counter++, Description = "AM5" });
            //AMDserver
            counter = 0;
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "SOCKET940" });
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "F" });
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "F+" });
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "C32" });
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "G34" });
            sockets.Add(new SocketModel() { Id = 400 + counter++, Description = "SP3" });
            _sockets = sockets.AsReadOnly();
            return _sockets;
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
