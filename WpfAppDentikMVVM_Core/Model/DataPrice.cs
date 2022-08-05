using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    internal class DataPrice
    {
        public int id { get; set; }
        public string problemName { get; set; } 
        public DateTime DateTime { get; set; }
        public string treatOption { get; set; }
        public int fees { get; set; } 
        public string time { get; set; }
    }
}
