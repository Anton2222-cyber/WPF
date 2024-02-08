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
using System.Windows.Shapes;
using System.IO;
namespace RezumeWithTemplate
{
    /// <summary>
    /// Interaction logic for WindowTemplate5.xaml
    /// </summary>
    public partial class WindowTemplate5 : Window
    {
        public WindowTemplate5()
        {
            InitializeComponent();
        }

        private void pathfoto_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                allinfo.Items.Clear();
                allinfo.Items.Add(lastname.Text);
                allinfo.Items.Add(firstname.Text);
                allinfo.Items.Add(surname.Text);
                var tmp = dateofbirth.SelectedDate.ToString().Split(" ".ToCharArray());
                allinfo.Items.Add("Дата народження: " + tmp[0]);
                allinfo.Items.Add("Шлях до фотографії: " + pathfoto.Text);
                allinfo.Items.Add("Телефон: " + tel.Text);
                allinfo.Items.Add("email: " + email.Text);
                allinfo.Items.Add("Досвід роботи:\n" + dosvid.Text);
                fhoto.Source = new BitmapImage(new Uri(pathfoto.Text, UriKind.Absolute));
            }
            catch (Exception exc)
            {

            }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data2.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < allinfo.Items.Count; i++)
            {
                streamWriter.WriteLine(allinfo.Items[i]);
            }
            streamWriter.Dispose();
            fs.Close();
            MessageBox.Show("Збережено!");
        }
    }
}
