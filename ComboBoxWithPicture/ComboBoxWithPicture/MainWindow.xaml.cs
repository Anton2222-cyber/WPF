using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ComboBoxWithPicture
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
        Image Get_Image(int i)
        {
            Image dynamicImage = new Image();
            dynamicImage.Width = 30;
            dynamicImage.Height = 30;
            dynamicImage.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "images\\foods_" + i + ".JPG", UriKind.Absolute));
            return dynamicImage;
        }
        Brush Get_Color()
        {
            int k = new Random().Next(1,7);
            switch(k)
            {
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.Yellow;
                case 3:
                    return Brushes.Blue;
                case 4:
                    return Brushes.Green;
                case 5:
                    return Brushes.Coral;
                case 6:
                    return Brushes.Aqua;
            }
            return Brushes.White;
        }
        private void add_item_Click(object sender, RoutedEventArgs e)
        {
            
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                StackPanel stackPanel = new StackPanel();
            Grid grid = new Grid();
            grid.Width = 191;
            grid.Background = Get_Color();          
            stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Children.Add(new CheckBox());
                stackPanel.Children.Add(Get_Image(new Random().Next(1,12)));
                Label l = new Label();
                l.Content = txt_box.Text;
                stackPanel.Children.Add(l);

            grid.Children.Add(stackPanel);
                comboBoxItem.Content = grid;
                MyComboBox.Items.Add(comboBoxItem);
            
        }
        void SearchAndDelete(ref int i)
        {
           
            ComboBoxItem comboBoxItem = (ComboBoxItem)MyComboBox.Items[i];
            Grid grid = (Grid)comboBoxItem.Content;
            StackPanel stackPanel_tmp = (StackPanel)grid.Children[0];
            CheckBox check = (CheckBox)stackPanel_tmp.Children[0];
            if (check.IsChecked == true)
            {
                MyComboBox.Items.RemoveAt(i);
                i = -1;
            }
        }
        private void delete_item_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < MyComboBox.Items.Count; i++)
                {
                    SearchAndDelete(ref i);
                }
                MyComboBox.Items.RemoveAt(MyComboBox.SelectedIndex);      
            }
            catch (Exception exc)
            {

            }
        }
    }
}
