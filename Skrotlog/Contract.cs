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
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
        public Currency Currency { get; set; }
        public string Initials { get; set; }
        public List<ContractLine> ContractLines { get; set; }

        public Contract(Customer c, DateTime date, Currency currency, string initials)
        {
            Customer = c;
            Date = date;
            Initials = initials;
            Currency = currency;
            ContractLines = new List<ContractLine>();
        }
    }
}
