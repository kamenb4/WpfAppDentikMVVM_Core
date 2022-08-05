using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDentikMVVM_Core.Model
{
    internal class Price : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string problemName { get; set; } = "Введите название";
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string treatOption { get; set; }
        public int fees { get; set; } = 1000;
        public string time { get; set; }
        public bool option { get; set; }
        public string ProblemName
        {
            get { return problemName; }
            set
            {
                problemName = value;
            }
        }

        public string TreatOption
        {
            get { return treatOption; }
            set
            {
                treatOption = value;
            }
        }

        public int Fees
        {
            get
            {
                return fees;
            }
            set
            {

                fees = value;
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
            }
        }
        public bool Option
        {
            get { return option; }
            set
            {
                option = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}