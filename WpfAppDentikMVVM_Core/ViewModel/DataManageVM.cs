using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfAppDentikMVVM_Core.Model;

namespace WpfAppDentikMVVM_Core.ViewModel
{
    internal class DataManageVM
    {
    
        public static ObservableCollection<Dtum> AddContext(ObservableCollection<Dtum> valuess)

        {
            using (var context = new testContext())
            {
                context.Dta.Load();
                valuess = context.Dta.Local.ToObservableCollection();
                return valuess;
            }
        }

        public static ObservableCollection<DataPrice> AddTooth(ObservableCollection<DataPrice> valuess)
        {
            List<int> numbers = new List<int>() 
            {
                11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25,26, 27,28,31,32,33,34,35,36,37,38,41,42,43,44,45,46,47,48
            };
            List<string> diagnosis = new List<string>() { "Кариес", "Пульпит", "Периодонтит" }; 
            valuess.Add(new DataPrice { NumberTooth = numbers, Diagnostics = diagnosis });
            return valuess;
        }
        public static ObservableCollection<DoctorList> AddData(ObservableCollection<DoctorList> valuess)
        {
            valuess.Add(new DoctorList() { Name = "Шастин Евгений Николаевич" });
            return valuess;
        }
        private void PriceDataOnListChanged(object? sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset: break;
                case ListChangedType.ItemAdded: break;
                case ListChangedType.ItemChanged:
                    break;
                case ListChangedType.ItemDeleted: break;
                case ListChangedType.ItemMoved: break;
                case ListChangedType.PropertyDescriptorAdded: break;
                case ListChangedType.PropertyDescriptorChanged: break;
                case ListChangedType.PropertyDescriptorDeleted: break;
            }

        }

    }
}
