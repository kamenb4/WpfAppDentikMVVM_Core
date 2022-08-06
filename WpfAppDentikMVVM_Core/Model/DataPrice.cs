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
        public bool option { get; set; }
        //public ObservableCollection<DataPrice>? _treat;

        //public ObservableCollection<DataPrice>? Treat
        //{
        //    get { return _treat; }
        //    set
        //    {
        //        _treat = value;
        //    }
        //}
        //public int Id
        //{
        //    get
        //    {
        //        return id;

        //    }
        //    set
        //    {
        //        id = value;
        //        NotifyPropertyChanged("Id");
        //    }
        //}
        //public string ProblemName
        //{
        //    get
        //    {
        //        return problemName;

        //    }
        //    set
        //    {
        //        problemName = value;
        //        NotifyPropertyChanged("ProblemName");
        //    }
        //}
        //public string TreatOptionFirst
        //{
        //    get
        //    {
        //        return treatOption;

        //    }
        //    set
        //    {
        //        treatOption = value;
        //        NotifyPropertyChanged("TreatOptionFirst");
        //    }
        //}
        //public string TreatOptionSecond
        //{
        //    get
        //    {
        //        return treatOption;

        //    }
        //    set
        //    {
        //        treatOption = value;
        //        NotifyPropertyChanged("TreatOptionSecond");
        //    }
        //}
        //public string TreatOptionThird
        //{
        //    get
        //    {
        //        return treatOption;

        //    }
        //    set
        //    {
        //        treatOption = value;
        //        NotifyPropertyChanged("TreatOptionThird");
        //    }
        //}
        //public int FeesFirst
        //{
        //    get
        //    {
        //        return fees + 111;

        //    }
        //    set
        //    {
        //        fees = value;
        //        NotifyPropertyChanged("FeesFirst");
        //    }
        //}
        //public int FeesSecond
        //{
        //    get
        //    {
        //        return fees + 222;

        //    }
        //    set
        //    {
        //        fees = value;
        //        NotifyPropertyChanged("FeesSecond");
        //    }
        //}
        //public int FeesThird
        //{
        //    get
        //    {
        //        return fees + 333;

        //    }
        //    set
        //    {
        //        fees = value;
        //        NotifyPropertyChanged("FeesThird");
        //    }
        //}
        //public string Time
        //{
        //    get
        //    {
        //        return time;

        //    }
        //    set
        //    {
        //        time = value;
        //        NotifyPropertyChanged("Time");
        //    }
        //}
        ////добавить взаимодействие свойств с бд
        ////настроить изменение данных в ячейке при изменении значения комбобокса1
        //public bool OptionFirst
        //{
        //    get
        //    {
        //        if (FeesFirst == 211)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    set
        //    {
        //        option = value;
        //        NotifyPropertyChanged("OptionFirst");
        //    }
        //}
        //public bool OptionSecond
        //{
        //    get
        //    {
        //        if (FeesSecond == 211)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    set
        //    {
        //        option = value;
        //        NotifyPropertyChanged("OptionSecond");
        //    }
        //}

        //    public bool OptionThird
        //{
        //    get
        //    {
        //        if (FeesThird == 211)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    set
        //    {
        //        option = value;
        //        NotifyPropertyChanged("OptionThird");
        //    }
        //}
   



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
