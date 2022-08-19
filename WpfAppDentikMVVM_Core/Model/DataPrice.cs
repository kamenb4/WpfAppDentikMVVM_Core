using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    public class DataPrice : INotifyPropertyChanged
    {

        
        public string? problemName { get; set; }
        public DateTime? DateTime { get; set; }
        public string? treatOption { get; set; }
        public int fees { get; set; } 
        public string? time { get; set; }
        public bool? option { get; set; }
        Dtum dtum = new Dtum();
        
        public long FeesFirst
        {
            get
            {
                return dtum.Fees;

            }
            set
            {
                dtum.Fees = value;
                NotifyPropertyChanged("FeesFirst");
            }
        }
        public long FeesSecond
        {
            get
            {
                return dtum.Fees;

            }
            set
            {
                dtum.Fees = value;
                NotifyPropertyChanged("FeesSecond");
            }
        }
        public long FeesThird
        {
            get
            {
                return dtum.Fees;

            }
            set
            {
                dtum.Fees = value;
                NotifyPropertyChanged("FeesThird");
            }
        }
        public string TimeFirst
        {
            get
            {
                return time;

            }
            set
            {
                time = value;
                NotifyPropertyChanged("TimeFirst");
            }
        }
        public string TimeSecond
        {
            get
            {
                return time;

            }
            set
            {
                time = value;
                NotifyPropertyChanged("TimeSecond");
            }
        }
        public long? Sum
        {
            get
            {
                return FeesFirst;
            }
        }
        public string TimeThird
        {
            get
            {
                return time;

            }
            set
            {
                time = value;
                NotifyPropertyChanged("TimeThird");
            }
        }
        ////добавить взаимодействие свойств с бд
        ////настроить изменение данных в ячейке при изменении значения комбобокса1
        public bool OptionFirst
        {
            get
            {
                
                    return false;
                
                
            }
            set
            {
                option = value;
                NotifyPropertyChanged("OptionFirst");
            }
        }
        public bool OptionSecond
        {
            get
            {
                return false;
            }
            set
            {
                option = value;
                NotifyPropertyChanged("OptionSecond");
            }
        }

        public bool OptionThird
        {

            get
            { 
                return false; 
            }
            
            set
            {
                option = value;
                NotifyPropertyChanged("OptionThird");
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

}
}
