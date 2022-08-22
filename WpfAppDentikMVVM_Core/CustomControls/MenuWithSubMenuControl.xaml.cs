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
using WpfAppDentikMVVM_Core.ViewModel;

namespace WpfAppDentikMVVM_Core.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для MenuWithSubMenuControl.xaml
    /// </summary>
    public partial class MenuWithSubMenuControl : UserControl
    {
        public MenuWithSubMenuControl()
        {
            InitializeComponent();
            //Binding ViewModel with the dataContext to read the Menu & SubMenuItemsData
            DataContext = new SiderViewModel();
        }

        public Thickness SubMenuPadding
        {
            get { return (Thickness)GetValue(SubMenuPaddingProperty); }
            set { SetValue(SubMenuPaddingProperty, value); }
        }

        public static readonly DependencyProperty SubMenuPaddingProperty =
            DependencyProperty.Register("SubMenuPadding", typeof(Thickness), typeof(MenuWithSubMenuControl));



        public bool HasIcon
        {
            get { return (bool)GetValue(HasIconProperty); }
            set { SetValue(HasIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasIconProperty =
            DependencyProperty.Register("HasIcon", typeof(bool), typeof(MenuWithSubMenuControl));


    }
}
