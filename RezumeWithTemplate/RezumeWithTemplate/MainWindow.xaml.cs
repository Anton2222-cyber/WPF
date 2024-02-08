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

namespace RezumeWithTemplate
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            WindowTemlate1 windowTemlate1 = new WindowTemlate1();
            windowTemlate1.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            WindowTemplate2 windowTemplate2 = new WindowTemplate2();
            windowTemplate2.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            WindowTemplate3 windowTemplate3 = new WindowTemplate3();
            windowTemplate3.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            WindowTemplate4 windowTemplate4 = new WindowTemplate4();
            windowTemplate4.Show();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            WindowTemplate5 windowTemplate5 = new WindowTemplate5();
            windowTemplate5.Show();
        }
    }
}
