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
        public DateTime? Datetime { get; set; } = DateTime.Now;
        public string treatOption { get; set; }
        public int fees { get; set; } 
        public string? time { get; set; }
        public bool optionFirst { get; set; }
        public bool optionSecond { get; set; }
        public bool optionThird { get; set; }
        Dtum dtumFirst = new Dtum();
        Dtum dtumSecond = new Dtum();
        Dtum dtumThird = new Dtum();

        public string TreatFirst
        {
            get
            {
                return dtumFirst.Treats;
            }
            set
            {
                dtumFirst.Treats = value;
                NotifyPropertyChanged("TreatFirst");
            }
        }
        public string TreatSecond {
            get
            {
                return dtumSecond.Treats;
            }
            set
            {
                dtumSecond.Treats = value;
                NotifyPropertyChanged("TreatSecond");
            }
        }
        public string TreatThird {
            get
            {
                return dtumThird.Treats;
            }
            set
            {
                dtumThird.Treats = value;
                NotifyPropertyChanged("TreatThird");
            }
        }

        public long FeesFirst
        {
            get
            {
                return dtumFirst.Fees;

            }
            set
            {
                dtumFirst.Fees = value;
                NotifyPropertyChanged("FeesFirst");
            }
        }
        public long FeesSecond
        {
            get
            {
                return dtumSecond.Fees;

            }
            set
            {
                dtumSecond.Fees = value;
                NotifyPropertyChanged("FeesSecond");
            }
        }
        public long FeesThird
        {
            get
            {
                return dtumThird.Fees;

            }
            set
            {
                dtumThird.Fees = value;
                NotifyPropertyChanged("FeesThird");
            }
        }
        public string SelectedTreats
        {
            get
            {
                if (OptionFirst == true)
                {
                    return TreatFirst;
                }
                else if (OptionSecond == true)
                {
                    return TreatSecond;
                }
                else if (OptionThird == true)
                {
                    return TreatThird;
                }
                else return "syka";
               

            }
            set
            {
                
            }
        }
        public long SelectedFees
        {
            get
            {
                if (OptionFirst == true)
                {
                    return FeesFirst;
                } else if (OptionSecond == true)
                {
                    return FeesSecond;
                } else if (OptionThird == true) 
                { 
                    return FeesThird;
                }
                return 0;
            }
            set
            {
                
            }
        }
        public string SelectedTime
        {
            get
            {
                if (OptionFirst == true)
                {
                    return TimeFirst;
                }
                else if (OptionSecond == true)
                {
                    return TimeSecond;
                }
                else if (OptionThird == true)
                {
                    return TimeThird;
                }
                return "prikol";
            }
            set
            {
                
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
                return FeesFirst + FeesSecond + FeesThird;
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
                
                    return optionFirst;
                
                
            }
            set
            {
                optionFirst = value;
                NotifyPropertyChanged("OptionFirst");
            }
        }
        public bool OptionSecond
        {
            get
            {
                return optionSecond;
            }
            set
            {
                optionSecond = value;
                NotifyPropertyChanged("OptionSecond");
            }
        }

        public bool OptionThird
        {

            get
            { 
                return optionThird; 
            }
            
            set
            {
                optionThird = value;
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
