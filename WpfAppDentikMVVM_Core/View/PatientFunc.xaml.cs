using System;
using System.Collections.Generic;
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

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для PatientFunc.xaml
    /// </summary>
    public partial class PatientFunc : Page
    {
        public PatientFunc()
        {
            InitializeComponent();
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
    }
}
