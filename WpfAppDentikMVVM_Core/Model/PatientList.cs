using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    public class PatientList
    {
        public string FCs { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public ObservableCollection<DataPrice> dataPrice { get; set; }

        //public DateTime BirthDate
        //{
        //    get
        //    {
        //       return string.Format("");
        //    }
        //} 
    }
}
