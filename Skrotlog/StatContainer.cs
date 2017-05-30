using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class StatContainer
    {
        private string country;
        private Material material;
        private int amount;

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public Material Material
        {
            get
            {
                return material;
            }

            set
            {
                material = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public StatContainer()
        {
            country =  "";
            amount = 0;
            Material = new Material("", "");
        }

        public StatContainer(string country, Material material, int amount)
        {
            this.country = country;
            this.material = material;
            this.amount = amount;
        }
    }
}
