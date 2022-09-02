using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.ViewModel;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public static ObservableCollection<PatientList>? _patientList = new ObservableCollection<PatientList>();
        public static ObservableCollection<DataPrice> _saveData = new ObservableCollection<DataPrice>();

        public ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();
        public ObservableCollection<DataPrice> forSaveCollect = new ObservableCollection<DataPrice>();

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
        public static ObservableCollection<PatientList>? PatientLists
        {
            get { return _patientList; }
            set
            {
                _patientList = value;
            }
        }
        public Dashboard()
        {
            InitializeComponent();
            SaveData.Clear();
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

                //var listOf = new ListOfPatients();
                //PatientData pd = new PatientData();


                //var i = 0;
                //_patientList.Add( new PatientList
                //{
                //    FCs = PatientData.DataTest[i].FCs,
                //    birthDate = DateTime.Now,
                //    phoneNumber = PatientData.DataTest[i].phoneNumber,
                //    dataPrice = SaveData
                //});
                //listOf.AllPatientsList.ItemsSource = PatientLists;
                //var historyPatient = new PateintHistory();
                //historyPatient.SaveGrid.ItemsSource = SaveData;
                PatientLists.Add(new PatientList
                {
                    FCs = PatientData.DataTest[0].FCs,
                    birthDate = PatientData.DataTest[0].birthDate,
                    phoneNumber = PatientData.DataTest[0].phoneNumber,
                    dataPrice = forSaveCollect
                });
                
                MessageBox.Show("Данные о клиенте сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нечего сохранять");
            }
        }

        private void Button_PrintClick(object sender, RoutedEventArgs e)
        {
            long sum = 0;
            var forPrint = new ForPrint();
            var printDialog = new PrintDialog();
            foreach (var p in forSaveCollect)
            {
                sum += p.SelectedFees;
            }

            forPrint.dgTreatPlan.ItemsSource = forSaveCollect;
            forPrint.textOfSum.Text = sum.ToString();
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Add(new DataPrice() { 
                problemName = SaveData[currentRowIndex].problemName,
                SelectedTreats = SaveData[currentRowIndex].TreatFirst,
                SelectedFees = SaveData[currentRowIndex].FeesFirst,
                SelectedTime = SaveData[currentRowIndex].TimeFirst
            });
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Remove(SaveData[currentRowIndex]);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Add(new DataPrice()
            {
                problemName = SaveData[currentRowIndex].problemName,
                SelectedTreats = SaveData[currentRowIndex].TreatSecond,
                SelectedFees = SaveData[currentRowIndex].FeesSecond,
                SelectedTime = SaveData[currentRowIndex].TimeSecond
            });
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Remove(SaveData[currentRowIndex]);
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Add(new DataPrice()
            {
                problemName = SaveData[currentRowIndex].problemName,
                SelectedTreats = SaveData[currentRowIndex].TreatThird,
                SelectedFees = SaveData[currentRowIndex].FeesThird,
                SelectedTime = SaveData[currentRowIndex].TimeThird
            });
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            forSaveCollect.Remove(SaveData[currentRowIndex]);
        }
    }
}
