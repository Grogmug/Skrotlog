using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Customer(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public Customer(int id, string name, string country)
            :this(name, country)
        {
            Id = id;
        }
        
    }
}
