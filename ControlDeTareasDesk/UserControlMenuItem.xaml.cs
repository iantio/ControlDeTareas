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

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MenuPrincipal _context;
        SubItem itemSeleccionado;
        public UserControlMenuItem(ItemMenu itemMenu, MenuPrincipal context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            this.DataContext = itemMenu;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if ((SubItem)ListViewMenu.SelectedItem != null)
            {
                itemSeleccionado = (SubItem)ListViewMenu.SelectedItem;
                _context.SwitchScreen((itemSeleccionado).Screen);
                ListViewMenu.SelectedItem = null;
            }
            //_context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }

        private void ListViewItemMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _context.SwitchScreen(((ItemMenu)(ListViewItemMenu.DataContext)).Screen);
        }
    }
}
