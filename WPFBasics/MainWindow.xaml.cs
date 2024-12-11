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

namespace WPFBasics
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You pressed the button");
        }

        private void CheckAll(object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = true;
            Op2.IsChecked = true;
            Op3.IsChecked = true;
            Op4.IsChecked = true;
        }

        private void UncheckAll(object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = false;
            Op2.IsChecked = false;
            Op3.IsChecked = false;
            Op4.IsChecked = false;
        }

        private void CheckedOp(object sender, RoutedEventArgs e)
        {
            if ((Op1.IsChecked == true) && (Op2.IsChecked == true) && (Op3.IsChecked == true) && (Op4.IsChecked == true))
            {
                CheckAllBox.IsChecked = true;
            }
            else
            {
                CheckAllBox.IsChecked = null;
            }
        }
        private void UncheckedOp(object sender, RoutedEventArgs e)
        {
            if ((Op1.IsChecked == false) && (Op2.IsChecked == false) && (Op3.IsChecked == false) && (Op4.IsChecked == false))
            {
                CheckAllBox.IsChecked = false;
            }
            else
            {
                CheckAllBox.IsChecked = null;
            }
        }
    }
}
