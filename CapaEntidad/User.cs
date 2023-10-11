using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class User
    {
        public int IdUser { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool Restored { get; set; }
        public bool Active { get; set; }
    }
}
