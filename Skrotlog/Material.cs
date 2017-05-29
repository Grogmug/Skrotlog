using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Designation { get; set; }

        public Material(string type, string designation)
        {
            
            Type = type;
            Designation = designation;
        }

        public Material(int id, string type, string designation)
            :this(type, designation)
        {
            Id = id;
        }
    }
}
