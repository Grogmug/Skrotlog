using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class Material
    {
        public string Type { get; set; }
        public string Designation { get; set; }

        public Material(string type, string designation)
        {
            Type = type;
            Designation = designation;
        }
    }
}
