using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class ContractLine
    {
        public decimal Price { get; set; }
        public Material Material { get; set; }
        public int TotalAmount { get; set; }
        public int DeliveredAmount { get; set; }
        public int RemainingAmount
        {
            get { return TotalAmount - DeliveredAmount; }
        }

        public bool Active { get; set; }

        public ContractLine(Material material, decimal price, int amount)
        {
            Material = material;
            Price = price;
            TotalAmount = amount;
        }
        public ContractLine(Material material, decimal price, int amount, int delivered)
            :this(material, price, amount)
        {
            DeliveredAmount = delivered;
        }
    }
}
