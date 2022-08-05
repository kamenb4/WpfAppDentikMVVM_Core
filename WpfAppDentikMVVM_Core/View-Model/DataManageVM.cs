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
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.View;

namespace WpfAppDentikMVVM_Core.View_Model
{
    internal class DataManageVM
    {
        internal static int count = 1;

        public static ObservableCollection<Price>? _saveData;
        private BindingList<Price>? _priceData;
        private ObservableCollection<Price>? _treat;

        public ObservableCollection<Price>? Treat
        {
            get { return _treat; }
            set
            {
                _treat = value;
            }
        }


        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {


            _treat = new ObservableCollection<Price>()
            {
               new Price() {TreatOption = "Восстановление культи зуба", Fees = 100},
               new Price() {TreatOption = "Штифт анкерный титановый", Fees = 200},
               new Price() {TreatOption = "Штифт стекловолокновый", Fees = 300},
               new Price() {TreatOption = "Вкладка культевая стальная разборная", Fees = 200},
               new Price() {TreatOption = "Вкладка культевая стальная", Fees = 200},
               new Price() {TreatOption = "Удаление анкерного штифта", Fees = 200},
               new Price() {TreatOption = "Удаление стекловолокнового штифта", Fees = 200},
               new Price() {TreatOption = "Удаление культевой вкладки", Fees = 200},
               new Price() {TreatOption = "Вкладка из композитной керамики SHOFU Block HC (Япония)", Fees = 200},
               new Price() {TreatOption = "Вкладка керамическая полевошпатная IPS  Empress (Германия)", Fees = 200},
               new Price() {TreatOption = "Вкладка керамическая дисиликат лития IPS E-max (Германия)", Fees = 200},
               new Price() {TreatOption = "Вкладка керамическая дисиликат лития Celtra Duo (США)", Fees = 200},
               new Price() {TreatOption = "Вкладка циркониевая Dental Direkt (Германия)", Fees = 200},
               new Price() {TreatOption = "Вкладка циркониевая IPS e.max ZirCAD (Германия)", Fees = 200},
               new Price() {TreatOption = "Вкладка циркониевая KATANA Zirconia (Япония)", Fees = 200},
               new Price() {TreatOption = "Вкладка циркониевая Sirona inCoris TZI (США)", Fees = 200},
               new Price() {TreatOption = "Винир из композитной керамики SHOFU Block HC (Япония)", Fees = 200}

            };



            _priceData = new BindingList<Price>()
            {
                new Price() { ProblemName = "Все плохо", TreatOption = _treat[0].TreatOption,Fees = 100_000, Time = "2ч"},
                 new Price() { ProblemName = "Еще хуже", Fees = 50000, Time = "1ч"}
            };



            //DgTreatPlan.ItemsSource = _priceData;
            _priceData.ListChanged += PriceDataOnListChanged;
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
            _saveData = new ObservableCollection<Price>(_priceData);
            MessageBox.Show("Данные о клиенте сохранены");
            //var historyPatient = new HistoryPatient();
            //this.Content = historyPatient;
        }

        private void ButtonBased_OnClick(object sender, RoutedEventArgs e)
        {
            _saveData = new ObservableCollection<Price>(_priceData);
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
