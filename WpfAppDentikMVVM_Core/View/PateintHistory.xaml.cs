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
using WpfAppDentikMVVM_Core.Model;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для PateintHistory.xaml
    /// </summary>
    public partial class PateintHistory : Page
    {
        
       
        public PateintHistory()
        {

            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {

                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/", "ListOfPatients", ".xaml"), UriKind.RelativeOrAbsolute));
                }

            }


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            PatientListOne.ItemsSource = ListOfPatients.patientHist;
        }
    }
}
