using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class ContractLine
    {
        bool active;

        public int Id { get; set; }
        public decimal Price { get; set; }
        public Material Material { get; set; }
        public int TotalAmount { get; set; }
        public int DeliveredAmount { get; set; }
        public int RemainingAmount
        {
            get { return TotalAmount - DeliveredAmount; }
        }
        public string Comment { get; set; }
        public bool Active
        {
            get
            {
                if(DeliveredAmount >= TotalAmount)
                {
                    active = false;
                }

                return active;
            }
            set
            {
                active = value;
            }
        }

        public ContractLine(Material material, decimal price, int amount)
        {
            Material = material;
            Price = price;
            TotalAmount = amount;
            active = true;
            Comment = "";
        }
        public ContractLine(Material material, decimal price, int amount, int delivered, bool active, string comment)
            :this(material, price, amount)
        {
            DeliveredAmount = delivered;
            Comment = comment;
            Active = active;
        }
        public ContractLine(int id, Material material, decimal price, int amount, int delivered, bool active, string comment)
            :this(material, price, amount, delivered, active, comment)
        {
            Id = id;
        }
    }
}
