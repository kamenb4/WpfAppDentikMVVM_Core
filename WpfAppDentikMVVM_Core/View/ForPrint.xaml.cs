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
using System.Windows.Shapes;
using WpfAppDentikMVVM_Core.Model;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Логика взаимодействия для ForPrint.xaml
    /// </summary>
    public partial class ForPrint : Window
    {
        private ObservableCollection<DataPrice>? printData = new ObservableCollection<DataPrice>();
        public ForPrint()
        {
            InitializeComponent();
        }

        private void ForPrint_OnLoaded(object sender, RoutedEventArgs e)
        {
            //printData = MainWindow.SaveData;
            //dgTreatPlan.ItemsSource = printData;
        }
    }
}
