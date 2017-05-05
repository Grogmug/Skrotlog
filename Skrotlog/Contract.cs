using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public enum Currency { DKK, EUR };
    public class Contract
    {

        public Customer Customer { get; set; }
        public decimal Price { get; set; }
        public List<Material> Material { get; set; }
        public int TotalAmount { get; set; }
        public int DeliveredAmount { get; set; }
        public int RemainingAmount { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
        public Currency Currency { get; set; }
        public string Initials { get; set; }

        public Contract(Customer c, decimal price, List<Material> material, int totalAmount, DateTime date, Currency currency, string initials)
        {
            Customer = c;
            Price = price;
            Material = material;
            TotalAmount = totalAmount;
            Date = date;
            Initials = initials;
        }
    }
}
