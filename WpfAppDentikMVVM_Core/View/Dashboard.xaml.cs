using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.ViewModel;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
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
            get { return _saveData; }
            set
            {
                _saveData = value;
            }
        }
        public static ObservableCollection<PatientList> PatientLists
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
            try
            {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
                var p = (ComboBox)sender;

                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesFirst = Treat[con].Fees;
                SaveData[currentRowIndex].TimeFirst = "1ч";
            }
            catch
            {
                MessageBox.Show("Допущена ошибка с первым боксом");
            }
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

        private void Button_PrintClick(object sender, RoutedEventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void Box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
                var p = (ComboBox)sender;


                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesSecond = Treat[con].Fees;
                SaveData[currentRowIndex].TimeSecond = "1ч";
            }
            catch
            {
                MessageBox.Show("Произошла ошибка со вторым боксом");
            }
        }

        private void Box3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
                var p = (ComboBox)sender;
                var con = Convert.ToInt32(p.SelectedIndex);
                SaveData[currentRowIndex].FeesThird = Treat[con].Fees;
                SaveData[currentRowIndex].TimeThird = "1ч";
            }
            catch
            {
                MessageBox.Show("произошла ошибка с третьим боксом");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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
            var p = sender as ComboBox;
                if (Settings.forRed.Count > 0 && p.SelectedIndex <= Settings.forRed.Count - 1)
                {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
                SaveData[currentRowIndex].TreatFirst = Settings.forRed[p.SelectedIndex].TreatFirst;
                    //SaveData[currentRowIndex].FeesFirst = Treat[17].Fees;
                    //SaveData[currentRowIndex].TimeFirst = "1ч";
                    SaveData[currentRowIndex].TreatSecond = Settings.forRed[p.SelectedIndex].TreatSecond;
                    //SaveData[currentRowIndex].FeesSecond = Treat[25].Fees;
                    //SaveData[currentRowIndex].TimeSecond = "1ч";
                    SaveData[currentRowIndex].TreatThird = Settings.forRed[p.SelectedIndex].TreatThird;
                    //SaveData[currentRowIndex].FeesThird = Treat[2].Fees;
                    //SaveData[currentRowIndex].TimeThird = "1ч";
                } else if( p.SelectedIndex > Settings.forRed.Count - 1)
                {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
                SaveData[currentRowIndex].TreatFirst = Treat[3].Treats;
                //SaveData[currentRowIndex].FeesFirst = Treat[17].Fees;
                //SaveData[currentRowIndex].TimeFirst = "1ч";
                SaveData[currentRowIndex].TreatSecond = Treat[13].Treats;
                //SaveData[currentRowIndex].FeesSecond = Treat[25].Fees;
                //SaveData[currentRowIndex].TimeSecond = "1ч";
                SaveData[currentRowIndex].TreatThird = Treat[23].Treats;
                //SaveData[currentRowIndex].FeesThird = Treat[2].Fees;
                //SaveData[currentRowIndex].TimeThird = "1ч";
                } else
            {
                var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
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


        }

        private void DgTreatPlan_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Tab)
                {
                    e.Handled = true;
                    SaveData.Add(new DataPrice());
                    // your code    
                }
            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            SaveData[currentRowIndex].visibilityTreatFirstSecond = Visibility.Visible;
            SaveData[currentRowIndex].visibilityTreatFirstThird = Visibility.Visible;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            SaveData[currentRowIndex].visibilityTreatSecondSecond = Visibility.Visible;
            SaveData[currentRowIndex].visibilityTreatSecondThird = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = DgTreatPlan.Items.IndexOf(DgTreatPlan.CurrentItem);
            SaveData[currentRowIndex].visibilityTreatThirdSecond = Visibility.Visible;
            SaveData[currentRowIndex].visibilityTreatThirdThird = Visibility.Visible;
        }
    }
}
