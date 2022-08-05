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
        [Key]
        public int id { get; set; }
        public string problemName { get; set; } 
        public DateTime DateTime { get; set; }
        public string treatOption { get; set; }
        public int fees { get; set; } 
        public string time { get; set; }
        //public ObservableCollection<DataPrice>? _treat;

        //public ObservableCollection<DataPrice>? Treat
        //{
        //    get { return _treat; }
        //    set
        //    {
        //        _treat = value;
        //    }
        //}
        public int Id
        {
            get
            {
                return id;

            }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string ProblemName
        {
            get
            {
                return problemName;

            }
            set
            {
                problemName = value;
                NotifyPropertyChanged("ProblemName");
            }
        }
        public string TreatOption
        {
            get
            {
                return treatOption;

            }
            set
            {
                treatOption = value;
                NotifyPropertyChanged("TreatOption");
            }
        }
        public int FeesFirst
        {
            get
            {
                return fees + 111;

            }
            set
            {
                fees = value;
                NotifyPropertyChanged("Fees");
            }
        }
        public int FeesSecond
        {
            get
            {
                return fees + 222;

            }
            set
            {
                fees = value;
                NotifyPropertyChanged("Fees");
            }
        }
        public int FeesThird
        {
            get
            {
                return fees + 333;

            }
            set
            {
                fees = value;
                NotifyPropertyChanged("Fees");
            }
        }
        public string Time
        {
            get
            {
                return time;

            }
            set
            {
                time = value;
                NotifyPropertyChanged("Time");
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
