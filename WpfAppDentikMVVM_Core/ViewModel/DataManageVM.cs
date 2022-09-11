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
            
            valuess.Add(
                new DataPrice { NumberTooth = "11", Diagnostics = "Кариес" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "12", Diagnostics = "Пульпит" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "13", Diagnostics = "Периодонтит" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "14", Diagnostics = "Периостит" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "15", Diagnostics = "Гранулема" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "16", Diagnostics = "Киста" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "17", Diagnostics = "Адентия" }
                );
            valuess.Add(
                new DataPrice { NumberTooth = "18", Diagnostics = "Гипоплазия" }
                );
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
