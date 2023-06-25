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

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    maximizeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                    break;
                case WindowState.Minimized:
                    break;
                case WindowState.Maximized:
                    maximizeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void GridHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            }
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;
                case WindowState.Minimized:
                    break;
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;
                default:
                    break;
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ListMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //switch (ListMenu.SelectedIndex)
            //{
            //    case 0:
            //        GridPrincipal.Children.Clear();
            //        _ = GridPrincipal.Children.Add(homeUserControl);
            //        txbWindowName.Text = "Bibliotech";
            //        break;
            //    case 1:
            //        GridPrincipal.Children.Clear();

            //        newLoanUserControl ??= new NewLoanUserControl(_online);
            //        _ = GridPrincipal.Children.Add(newLoanUserControl);

            //        txbWindowName.Text = "Bibliotech - Empréstimo";
            //        break;
            //}
        }
    }
}
