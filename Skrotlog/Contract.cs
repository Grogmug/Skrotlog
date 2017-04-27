using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    enum Currency { DKK, EUR };
    public class Contract
    {

        Customer Customer { get; set; }
        decimal Price { get; set; }
        Material Material { get; set; }
        int ExportAmount { get; set; }
        int DeliverAmount { get; set; }
        int RemainingAmount { get; set; }
        bool Active { get; set; }
        DateTime Date { get; set; }
        Currency Currency { get; set; }
        string Initials { get; set; }

    }
}
