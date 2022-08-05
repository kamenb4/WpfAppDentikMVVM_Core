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
        
        public static ObservableCollection<Price>? _saveData;
        public BindingList<DataPrice>? _priceData;
        //public ObservableCollection<DataPrice>? _treat;

        //public ObservableCollection<DataPrice>? Treat
        //{
        //    get { return _treat = new ObservableCollection<DataPrice>()
        //    {
        //       new DataPrice() {TreatOption = "Восстановление культи зуба", Fees = 100},
        //       new DataPrice() {TreatOption = "Штифт анкерный титановый", Fees = 200},
        //       new DataPrice() {TreatOption = "Штифт стекловолокновый", Fees = 300},
        //       new DataPrice() {TreatOption = "Вкладка культевая стальная разборная", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка культевая стальная", Fees = 200},
        //       new DataPrice() {TreatOption = "Удаление анкерного штифта", Fees = 200},
        //       new DataPrice() {TreatOption = "Удаление стекловолокнового штифта", Fees = 200},
        //       new DataPrice() {TreatOption = "Удаление культевой вкладки", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка из композитной керамики SHOFU Block HC (Япония)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка керамическая полевошпатная IPS  Empress (Германия)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка керамическая дисиликат лития IPS E-max (Германия)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка керамическая дисиликат лития Celtra Duo (США)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка циркониевая Dental Direkt (Германия)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка циркониевая IPS e.max ZirCAD (Германия)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка циркониевая KATANA Zirconia (Япония)", Fees = 200},
        //       new DataPrice() {TreatOption = "Вкладка циркониевая Sirona inCoris TZI (США)", Fees = 200},
        //       new DataPrice() {TreatOption = "Винир из композитной керамики SHOFU Block HC (Япония)", Fees = 200}

        //    }; 
        //    }
        //    set
        //    {
        //        _treat = value;
        //    }
        //}


        private void Window_OnLoaded()
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                applicationContext.dataPrices.Load();
                applicationContext.dataPrices.ToList();
                //_treat = new ObservableCollection<DataPrice>(applicationContext.dataPrices.ToList());
            }
           
        }

        public BindingList<DataPrice> AddTestData(BindingList<DataPrice> datas)
        {
            
            return datas = new BindingList<DataPrice>()
            {
                new DataPrice() { ProblemName = "Все плохо", fees = 100, Time = "2ч"},
                 new DataPrice() { ProblemName = "Еще хуже", fees = 500, Time = "1ч"}
            };
        }
        public ObservableCollection<DataPrice> AddContext(ObservableCollection<DataPrice> valuess)
        {
            valuess = new ObservableCollection<DataPrice>()
            {
               new DataPrice() { TreatOption = "Восстановление культи зуба", fees = 100},
               new DataPrice() { TreatOption = "Штифт анкерный титановый", fees = 200},
               new DataPrice() { TreatOption = "Штифт стекловолокновый", fees = 300},
               new DataPrice() { TreatOption = "Вкладка культевая стальная разборная", fees = 200},
               new DataPrice() { TreatOption = "Вкладка культевая стальная", fees = 200},
               new DataPrice() { TreatOption = "Удаление анкерного штифта", fees = 200},
               new DataPrice() { TreatOption = "Удаление стекловолокнового штифта", fees = 200},
               new DataPrice() { TreatOption = "Удаление культевой вкладки", fees = 200},
               new DataPrice() { TreatOption = "Вкладка из композитной керамики SHOFU Block HC (Япония)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка керамическая полевошпатная IPS  Empress (Германия)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка керамическая дисиликат лития IPS E-max (Германия)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка керамическая дисиликат лития Celtra Duo (США)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка циркониевая Dental Direkt (Германия)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка циркониевая IPS e.max ZirCAD (Германия)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка циркониевая KATANA Zirconia (Япония)", fees = 200},
               new DataPrice() { TreatOption = "Вкладка циркониевая Sirona inCoris TZI (США)", fees = 200},
               new DataPrice() { TreatOption = "Винир из композитной керамики SHOFU Block HC (Япония)", fees = 200}

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
            // foreach (var priceModel in _priceData)
            // {
            //     if (priceModel.TreatOption == "Amalgam restoration")
            //     {
            //         priceModel.Fees = 9999;
            //     }
            //     else
            //     {
            //         priceModel.Fees = 1234;
            //     }
            // }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _saveData = new ObservableCollection<Price>((IEnumerable<Price>)_priceData);
            MessageBox.Show("Данные о клиенте сохранены");
            //var historyPatient = new HistoryPatient();
            //this.Content = historyPatient;
        }

        private void ButtonBased_OnClick(object sender, RoutedEventArgs e)
        {
            _saveData = new ObservableCollection<Price>((IEnumerable<Price>)_priceData);
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
