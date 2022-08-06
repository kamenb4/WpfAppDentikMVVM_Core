using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfAppDentikMVVM_Core.Data;
using WpfAppDentikMVVM_Core.Model;
using WpfAppDentikMVVM_Core.View_Model;

namespace WpfAppDentikMVVM_Core.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManageVM manageVM = new DataManageVM();
        internal static int count = 1;

        public static ObservableCollection<DataPrice>? _saveData;
        public BindingList<DataPrice>? _priceData;
        public ObservableCollection<DataPrice>? _treat;

        public ObservableCollection<DataPrice>? Treat
        {
            get { return manageVM.AddContext(_treat); }
            set
            {
                _treat = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (ApplicationContext applicationContext = new ApplicationContext())
            //{
            //    applicationContext.dataPrices.Load();
            //    applicationContext.dataPrices.ToList();
            //    //_treat = new ObservableCollection<DataPrice>(applicationContext.dataPrices.ToList());
            //}
            
            //оптимизировать метод
       
            DgTreatPlan.ItemsSource = manageVM.AddListDB(_treat);
           
        }
    }
}
