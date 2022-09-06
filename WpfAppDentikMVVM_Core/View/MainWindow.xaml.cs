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

        
        private ObservableCollection<DoctorList> doctors = new ObservableCollection<DoctorList>();
        public static string doctorInPrint = "";
        public ObservableCollection<DoctorList> Doctors
        {
            get
            {

                return DataManageVM.AddData(doctors);
            }
            set
            {

            }
        }

        public string DoctorsInPrint
        {
            get
            {
                return doctorInPrint;
            }
            set
            {
                doctorInPrint = value;
            }
        }



        //public static ObservableCollection<string> doctors = new ObservableCollection<string>()
        //{
        //    string Name = ""
        //};

        //public ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();
        //public static ObservableCollection<DataPrice> _printData = new ObservableCollection<DataPrice>();



        //public ObservableCollection<Dtum> Treat
        //{

        //    get { return DataManageVM.AddContext(_treat); }
        //    set
        //    {
        //        _treat = value;
        //    }
        //}
        //public static ObservableCollection<DataPrice> PrintData
        //{
        //    get { return _printData; }
        //    set
        //    {
        //        _printData = value;
        //    }
        //}

        //public static ObservableCollection<DataPrice> SaveData
        //{
        //    get { return _saveData; }
        //    set
        //    {
        //        _saveData = value;
        //    }
        //}
        public MainWindow()
        {
            InitializeComponent();

            //DgTreatPlan.ItemsSource = SaveData;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = (ComboBox)sender;
            var con = Convert.ToInt32(p.SelectedIndex);
            DoctorsInPrint = Doctors[con].Name;
            addNewButton.Visibility = Visibility.Visible;
            getHistoryButton.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.SaveData.Clear();
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "PatientData", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "ListOfPatients", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }

        //private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
        //    var p = (ComboBox)sender;

        //    var con = Convert.ToInt32(p.SelectedIndex);
        //    SaveData[currentRowIndex].FeesFirst = Treat[con].Fees;
        //    SaveData[currentRowIndex].TimeFirst = "1ч";
        //}

        //private void Button_SaveClick(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        MessageBox.Show("Данные о клиенте сохранены");
        //        var historyPatient = new PateintHistory();
        //        historyPatient.SaveGrid.ItemsSource = SaveData;
        //        this.Content = historyPatient;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Нечего сохранять");
        //    }
        //}

        //private void Button_PrintClick(object sender, RoutedEventArgs e)
        //{
        //    var forPrint = new ForPrint();
        //    var printDialog = new PrintDialog();
        //    forPrint.dgTreatPlan.ItemsSource = SaveData;
        //    forPrint.Show();
        //    if (printDialog.ShowDialog() == true)
        //    {
        //        printDialog.PrintVisual(forPrint.GridMain, "Печать");
        //    }
        //}

        //private void Box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
        //    var p = (ComboBox)sender;


        //    var con = Convert.ToInt32(p.SelectedIndex);
        //    SaveData[currentRowIndex].FeesSecond = Treat[con].Fees;
        //    SaveData[currentRowIndex].TimeSecond = "1ч";

        //}

        //private void Box3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
        //    var p = (ComboBox)sender;
        //    var con = Convert.ToInt32(p.SelectedIndex);
        //    SaveData[currentRowIndex].FeesThird = Treat[con].Fees;
        //    SaveData[currentRowIndex].TimeThird = "1ч";
        //}


    }
}
