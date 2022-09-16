using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public static ObservableCollection<DataPrice> forRed = new ObservableCollection<DataPrice>();
        private ObservableCollection<DataPrice> forOpts = new ObservableCollection<DataPrice>();
        private ObservableCollection<Dtum> _treat = new ObservableCollection<Dtum>();
        private ObservableCollection<DataPrice> _tooth = new ObservableCollection<DataPrice>();
        private ObservableCollection<DataPrice> ForOpts
        {
            get
            {
                return forOpts;
            }
            set
            {
                forOpts = value;
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
        public ObservableCollection<DataPrice> Tooth
        {
            get
            {
                return DataManageVM.AddTooth(_tooth);
            }
            
        }
        public Settings()
        {
            InitializeComponent();
            DataContext = ForOpts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            forRed.Add(new DataPrice()
            {
                Diagnostics = diagCombo.SelectionBoxItemStringFormat, TreatFirst = firstCombo.SelectionBoxItemStringFormat, TreatSecond = secondCombo.SelectionBoxItemStringFormat, TreatThird = thirdCombo.SelectionBoxItemStringFormat
            });
            MessageBox.Show("Изменения сохранены");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Box3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void diagCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exText.Visibility = Visibility.Visible;
            firstCombo.Visibility = Visibility.Visible;
            economText.Visibility = Visibility.Visible;
            secondCombo.Visibility = Visibility.Visible;
            recomendText.Visibility = Visibility.Visible;
            thirdCombo.Visibility = Visibility.Visible;
        }
    }
}
