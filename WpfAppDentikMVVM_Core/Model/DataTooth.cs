using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    public class DataTooth
    {
        public int numberTooth { get; set; }
        public string diagnostics { get; set; }

        public string Diagnostics
        {
            get
            {
                return diagnostics;
            }
            set
            {
                diagnostics = value;
            }
        }
        public int NumberTooth
        {
            get
            {
                return numberTooth;
            }
            set
            {
                numberTooth = value;
            }
        }
    }
}
