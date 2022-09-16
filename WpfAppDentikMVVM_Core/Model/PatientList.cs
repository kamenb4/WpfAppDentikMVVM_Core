using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    public class PatientList : INotifyPropertyChanged
    {
        public string FCs { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public ObservableCollection<DataPrice> dataPrice { get; set; }
        public ObservableCollection<DataPrice> saveDataEdit { get; set; }

        public ObservableCollection<DataPrice> SaveDataEdit
        {
            get { return saveDataEdit; }
            set
            {
                saveDataEdit = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static implicit operator ObservableCollection<object>(PatientList v)
        {
            throw new NotImplementedException();
        }
        //public DateTime BirthDate
        //{
        //    get
        //    {
        //       return string.Format("");
        //    }
        //} 
    }
}
