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
    /// Логика взаимодействия для EditingPatient.xaml
    /// </summary>
    public partial class EditingPatient : Page
    {
        
        public static ObservableCollection<PatientList> _patientList = new ObservableCollection<PatientList>();
        public static ObservableCollection<DataPrice> _saveData = new ObservableCollection<DataPrice>();

        public ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();
        public ObservableCollection<DataPrice> forSaveCollect = new ObservableCollection<DataPrice>();

        public static ObservableCollection<DataPrice> _printData = new ObservableCollection<DataPrice>();
        private ObservableCollection<DataPrice> test = DataManageVM.AddTooth(_toothDiagnos);
        public static ObservableCollection<DataPrice> _toothDiagnos = new ObservableCollection<DataPrice>();

        public ObservableCollection<DataPrice> ToothDiagnos
        {
            get
            {
                return test;
            }
            set
            {

            }
        }


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
            get { return ListOfPatients.patientEditSaveData; }
            set
            {
                _saveData = value;
            }
        }
        public static ObservableCollection<PatientList> PatientLists
        {
            get { return ListOfPatients.PatientLists; }
            set
            {
                _patientList = value;
            }
        }
        public EditingPatient()
        {
            InitializeComponent();
            DataContext = PatientLists;
            DgEditPlan.ItemsSource = SaveData;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                var p = (ComboBox)sender;

                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesFirst = Treat[con].Fees;
                SaveData[currentRowIndex].TimeFirst = "1ч";

                
            } catch { }
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                PatientLists.Add(new PatientList
                {
                    FCs = PatientData.DataTest[0].FCs,
                    birthDate = PatientData.DataTest[0].birthDate,
                    phoneNumber = PatientData.DataTest[0].phoneNumber,
                    dataPrice = forSaveCollect,
                    SaveDataEdit = SaveData
                }); ;

                MessageBox.Show("Данные о клиенте сохранены");
                foreach (Window window in Application.Current.Windows)
                {

                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "ListOfPatients", ".xaml"), UriKind.RelativeOrAbsolute));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void Box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                var p = (ComboBox)sender;


                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesSecond = Treat[con].Fees;
                SaveData[currentRowIndex].TimeSecond = "1ч";
            }
            catch
            {
                
            }
        }

        private void Box3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                var p = (ComboBox)sender;
                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesThird = Treat[con].Fees;
                SaveData[currentRowIndex].TimeThird = "1ч";
            }
            catch
            {
                
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Add(new DataPrice()
                {
                    problemName = String.Concat(SaveData[currentRowIndex].NumberTooth, " - ", SaveData[currentRowIndex].Diagnostics),
                    SelectedTreats = SaveData[currentRowIndex].TreatFirst,
                    SelectedFees = SaveData[currentRowIndex].FeesFirst,
                    SelectedTime = SaveData[currentRowIndex].TimeFirst
                });
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом");
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Remove(SaveData[currentRowIndex]);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом");
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Add(new DataPrice()
                {
                    problemName = String.Concat(SaveData[currentRowIndex].NumberTooth, " - ", SaveData[currentRowIndex].Diagnostics),
                    SelectedTreats = SaveData[currentRowIndex].TreatSecond,
                    SelectedFees = SaveData[currentRowIndex].FeesSecond,
                    SelectedTime = SaveData[currentRowIndex].TimeSecond
                });
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом2");
            }
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Remove(SaveData[currentRowIndex]);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом2");
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Add(new DataPrice()
                {
                    problemName = String.Concat(SaveData[currentRowIndex].NumberTooth, " - ", SaveData[currentRowIndex].Diagnostics),
                    SelectedTreats = SaveData[currentRowIndex].TreatThird,
                    SelectedFees = SaveData[currentRowIndex].FeesThird,
                    SelectedTime = SaveData[currentRowIndex].TimeThird
                });
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом3");
            }
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                forSaveCollect.Remove(SaveData[currentRowIndex]);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка c чекбоксом3");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Услуга добавлена");
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Settings.forRed.Count > 0)
                {
                    var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                    SaveData[currentRowIndex].TreatFirst = Settings.forRed[0].TreatFirst;
                    //SaveData[currentRowIndex].FeesFirst = Treat[17].Fees;
                    //SaveData[currentRowIndex].TimeFirst = "1ч";
                    SaveData[currentRowIndex].TreatSecond = Settings.forRed[0].TreatSecond;
                    //SaveData[currentRowIndex].FeesSecond = Treat[25].Fees;
                    //SaveData[currentRowIndex].TimeSecond = "1ч";
                    SaveData[currentRowIndex].TreatThird = Settings.forRed[0].TreatThird;
                    //SaveData[currentRowIndex].FeesThird = Treat[2].Fees;
                    //SaveData[currentRowIndex].TimeThird = "1ч";
                }
                else
                {
                    var currentRowIndex = DgEditPlan.Items.IndexOf(DgEditPlan.CurrentItem);
                    SaveData[currentRowIndex].TreatFirst = Treat[3].Treats;
                    //SaveData[currentRowIndex].FeesFirst = Treat[17].Fees;
                    //SaveData[currentRowIndex].TimeFirst = "1ч";
                    SaveData[currentRowIndex].TreatSecond = Treat[13].Treats;
                    //SaveData[currentRowIndex].FeesSecond = Treat[25].Fees;
                    //SaveData[currentRowIndex].TimeSecond = "1ч";
                    SaveData[currentRowIndex].TreatThird = Treat[23].Treats;
                    //SaveData[currentRowIndex].FeesThird = Treat[2].Fees;
                    //SaveData[currentRowIndex].TimeThird = "1ч";
                }
            } catch
            {
                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "ListOfPatients", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }
    }
}
