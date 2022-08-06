using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfAppDentikMVVM_Core.Data;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.View;

namespace WpfAppDentikMVVM_Core.View_Model
{
    internal class DataManageVM
    {
        internal static int count = 1;
        
        public static ObservableCollection<DataPrice>? _saveData;
        public BindingList<DataPrice>? _priceData;
        

          
       

        public BindingList<DataPrice> AddTestData(BindingList<DataPrice> datas)
        {
            
            return datas = new BindingList<DataPrice>()
            {
                new DataPrice() { problemName = "Все плохо", fees = 100, time = "2ч"},
                 new DataPrice() { problemName = "Еще хуже", fees = 500, time = "1ч"}
            };
        }

        public ObservableCollection<DataPrice> AddListDB(ObservableCollection<DataPrice> DBList)
        {
            using (ApplicationContext appcont = new ApplicationContext())
            {
                DBList = new ObservableCollection<DataPrice>(appcont.dataPrices.ToList());
            }
            return DBList;
        }

        public ObservableCollection<DataPrice> AddContext(ObservableCollection<DataPrice> valuess)
        {
            valuess = new ObservableCollection<DataPrice>()
            {
               new DataPrice() { treatOption = "Восстановление культи зуба", fees = 100},
               new DataPrice() { treatOption = "Штифт анкерный титановый", fees = 200},
               new DataPrice() { treatOption = "Штифт стекловолокновый", fees = 300},
               new DataPrice() { treatOption = "Вкладка культевая стальная разборная", fees = 200},
               new DataPrice() { treatOption = "Вкладка культевая стальная", fees = 200},
               new DataPrice() { treatOption = "Удаление анкерного штифта", fees = 200},
               new DataPrice() { treatOption = "Удаление стекловолокнового штифта", fees = 200},
               new DataPrice() { treatOption = "Удаление культевой вкладки", fees = 200},
               new DataPrice() { treatOption = "Вкладка из композитной керамики SHOFU Block HC (Япония)", fees = 200},
               new DataPrice() { treatOption = "Вкладка керамическая полевошпатная IPS  Empress (Германия)", fees = 200},
               new DataPrice() { treatOption = "Вкладка керамическая дисиликат лития IPS E-max (Германия)", fees = 200},
               new DataPrice() { treatOption = "Вкладка керамическая дисиликат лития Celtra Duo (США)", fees = 200},
               new DataPrice() { treatOption = "Вкладка циркониевая Dental Direkt (Германия)", fees = 200},
               new DataPrice() { treatOption = "Вкладка циркониевая IPS e.max ZirCAD (Германия)", fees = 200},
               new DataPrice() { treatOption = "Вкладка циркониевая KATANA Zirconia (Япония)", fees = 200},
               new DataPrice() { treatOption = "Вкладка циркониевая Sirona inCoris TZI (США)", fees = 200},
               new DataPrice() { treatOption = "Винир из композитной керамики SHOFU Block HC (Япония)", fees = 200}

    };
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _saveData = new ObservableCollection<DataPrice>(_priceData);
            MessageBox.Show("Данные о клиенте сохранены");
            //var historyPatient = new HistoryPatient();
            //this.Content = historyPatient;
        }

        private void ButtonBased_OnClick(object sender, RoutedEventArgs e)
        {
            _saveData = new ObservableCollection<DataPrice>(_priceData);
            var forPrint = new ForPrint();

            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(forPrint.GridMain, "Печать");
            }
        }

        private void Box3_OnSourceUpdated(object? sender, DataTransferEventArgs e)
        {


        }

        private void Button_ClickUpdate(object sender, RoutedEventArgs e)
        {

        }
    }
}
