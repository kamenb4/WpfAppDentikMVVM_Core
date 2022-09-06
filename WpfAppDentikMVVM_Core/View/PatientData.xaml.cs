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
    /// Логика взаимодействия для PatientData.xaml
    /// </summary>
    public partial class PatientData : Page
    {
        public static ObservableCollection<PatientList> DataTest = new ObservableCollection<PatientList>();
        


        public PatientData()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTest.Clear();
                DataTest.Add(new PatientList { FCs = fcs.Text, birthDate = (DateTime)birthday.SelectedDate, phoneNumber = number.Text });
                foreach (Window window in Application.Current.Windows)
                {

                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "Dashboard", ".xaml"), UriKind.RelativeOrAbsolute));
                    }

                }
            }
            catch
            {
                if (fcs.Text == "") fcs.Background = new SolidColorBrush(Colors.PaleVioletRed);
                if (birthday.Text == "") birthday.Background = new SolidColorBrush(Colors.PaleVioletRed);
                if (number.Text == "") number.Background = new SolidColorBrush(Colors.PaleVioletRed);
                MessageBox.Show("Необходимо заполнить все обязательные поля!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "PatientFunc", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }
        }

      

        private void fcs_GotMouseCapture(object sender, MouseEventArgs e)
        {
            fcs.Background = new SolidColorBrush(Colors.White);
        }

        private void birthday_GotMouseCapture(object sender, MouseEventArgs e)
        {
            birthday.Background = new SolidColorBrush(Colors.White);
        }

        private void number_GotMouseCapture(object sender, MouseEventArgs e)
        {
            number.Background = new SolidColorBrush(Colors.White);
        }
    }
}
