using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.ViewModel;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public static ObservableCollection<DataPrice> _saveData = new ObservableCollection<DataPrice>();

        public ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();
        public static ObservableCollection<DataPrice> _printData = new ObservableCollection<DataPrice>();



        public ObservableCollection<Dtum> Treat
        {

            get { return DataManageVM.AddContext(_treat); }
            set
            {
                _treat = value;
            }
        }
        public static ObservableCollection<DataPrice> PrintData
        {
            get { return _printData; }
            set
            {
                _printData = value;
            }
        }

        public static ObservableCollection<DataPrice> SaveData
        {
            get { return _saveData; }
            set
            {
                _saveData = value;
            }
        }
        public Dashboard()
        {
            InitializeComponent();
            DgTreatPlan.ItemsSource = SaveData;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            var p = (ComboBox)sender;

            var con = Convert.ToInt32(p.SelectedIndex);
            SaveData[currentRowIndex].FeesFirst = Treat[con].Fees;
            SaveData[currentRowIndex].TimeFirst = "1ч";
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Данные о клиенте сохранены");
                var historyPatient = new PateintHistory();
                historyPatient.SaveGrid.ItemsSource = SaveData;
                this.Content = historyPatient;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нечего сохранять");
            }
        }

        private void Button_PrintClick(object sender, RoutedEventArgs e)
        {
            var forPrint = new ForPrint();
            var printDialog = new PrintDialog();
            forPrint.dgTreatPlan.ItemsSource = SaveData;
            forPrint.Show();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(forPrint.GridMain, "Печать");
            }
        }

        private void Box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            var p = (ComboBox)sender;


            var con = Convert.ToInt32(p.SelectedIndex);
            SaveData[currentRowIndex].FeesSecond = Treat[con].Fees;
            SaveData[currentRowIndex].TimeSecond = "1ч";

        }

        private void Box3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            var p = (ComboBox)sender;
            var con = Convert.ToInt32(p.SelectedIndex);
            SaveData[currentRowIndex].FeesThird = Treat[con].Fees;
            SaveData[currentRowIndex].TimeThird = "1ч";
        }

    }
}
