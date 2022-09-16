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

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для ListOfPatients.xaml
    /// </summary>
    public partial class ListOfPatients : Page
    {
        public static ObservableCollection<DataPrice> patientHist = new ObservableCollection<DataPrice>();

        public static ObservableCollection<PatientList> patientEdit = new ObservableCollection<PatientList>();
        public static ObservableCollection<DataPrice> patientEditSaveData = new ObservableCollection<DataPrice>();
       
        //public static int p = 0;

        
        public static ObservableCollection<PatientList> PatientLists
        {
            get
            {
                
                return Dashboard.PatientLists;
            }
            set
            {

            }
        }

        //public static int GetPatientIndex
        //{
        //    get
        //    {
        //        //int c = AllPatientsList.SelectedIndex;
        //        //return PatientLists[c].dataPrice;
        //    }
        //}
        
        public ListOfPatients()
        {
            
            InitializeComponent();
            
            AllPatientsList.ItemsSource = PatientLists;
            //PatientData.DataTest.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            patientEdit.Clear();
            patientEditSaveData.Clear();
            PatientData.DataTest.Clear();
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
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "SearchPatient", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }

        private void AllPatientsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //p = AllPatientsList.SelectedIndex;
            //MessageBox.Show(p.ToString());
            //PateintHistory history = new PateintHistory();
            //var currentRowIndex = AllPatientsList.Items.CurrentPosition;
            //MessageBox.Show(AllPatientsList.Items.Count.ToString());
            //MessageBox.Show(currentRowIndex.ToString());
            //MessageBox.Show(AllPatientsList.SelectedIndex.ToString());
            ////MessageBox.Show(PatientLists[AllPatientsList.SelectedIndex].dataPrice.Count.ToString());
            //var p = AllPatientsList.Items.IndexOf(AllPatientsList.SelectedItem);
            //MessageBox.Show(AllPatientsList.SelectedIndex.ToString());
            //if (p == -1) p++;
            //MessageBox.Show(p.ToString());

            var p = PatientLists[AllPatientsList.SelectedIndex].dataPrice;
            
            patientHist = p;
            //var p = new PatientList();
            //p.PatientIndex = AllPatientsList.SelectedIndex;
            
            
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "PateintHistory", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            patientEdit.Clear();
            //PatientLists.Add(new PatientList()
            //{
            //    FCs = PatientData.DataTest[0].FCs,
            //    birthDate = PatientData.DataTest[0].birthDate,
            //    phoneNumber = PatientData.DataTest[0].phoneNumber,
            //    dataPrice = Dashboard.SaveData
            //});
            //AllPatientsList.ItemsSource = PatientLists;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //PatientLists[AllPatientsList.SelectedIndex].dataPrice.Clear();
            patientEdit.Add(PatientLists[AllPatientsList.SelectedIndex]);
            patientEditSaveData = patientEdit[0].SaveDataEdit;
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {

                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "EditingPatient", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PatientLists.RemoveAt(AllPatientsList.SelectedIndex);
        }
    }
}
