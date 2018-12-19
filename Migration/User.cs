using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
    }
}
