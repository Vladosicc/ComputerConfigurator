using ComputerConfigurator.Models.NotDetail;

namespace ComputerConfigurator.Models.Citilink
{
    public class SocketCooler
    {
        public int IdCooler { get; set; }
        public virtual CoolerCitilink Cooler { get; set; }
        public int IdSocket { get; set; }
        public virtual SocketModel Socket { get; set; }
    }
}
