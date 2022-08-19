using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.ViewModel;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public static ObservableCollection<DataPrice> _saveData = new ObservableCollection<DataPrice>();

        public ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();



        public ObservableCollection<Dtum> Treat
        {

            get { return DataManageVM.AddContext(_treat); }
            set
            {
                _treat = value;
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
        public MainWindow()
        {
            InitializeComponent();
            DgTreatPlan.ItemsSource = SaveData;

        }

        private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
