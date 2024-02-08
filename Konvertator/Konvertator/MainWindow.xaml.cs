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

namespace Konvertator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            img.Source=new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "images/j.png", UriKind.Absolute));
            
        }

        private void Mira_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            var arr = Mira.Items[Mira.SelectedIndex].ToString().Split(" ".ToCharArray());
            if (string.Compare(arr[1], "Довжина")==0)
            {
                odinici_in.Items.Clear();
                odinici_in.Items.Add("см");
                odinici_in.Items.Add("м");
                odinici_in.Items.Add("км");

                odinici_out.Items.Clear();
                odinici_out.Items.Add("см");
                odinici_out.Items.Add("м");
                odinici_out.Items.Add("км");
            }
            else if(string.Compare(arr[1], "Маса") == 0)
            {
                odinici_in.Items.Clear();
                odinici_in.Items.Add("г");
                odinici_in.Items.Add("кг");
                odinici_in.Items.Add("т");

                odinici_out.Items.Clear();
                odinici_out.Items.Add("г");
                odinici_out.Items.Add("кг");
                odinici_out.Items.Add("т");
            }
            else if (string.Compare(arr[1], "Тиск") == 0)
            {
                odinici_in.Items.Clear();
                odinici_in.Items.Add("Па");
                odinici_in.Items.Add("КПа");
                odinici_in.Items.Add("мПа");

                odinici_out.Items.Clear();
                odinici_out.Items.Add("Па");
                odinici_out.Items.Add("КПа");
                odinici_out.Items.Add("мПа");
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string tmp = odinici_in.Text;
                if (string.Compare(odinici_in.Text, odinici_out.Text) == 0)
                    value_out.Text = value_in.Text;
                else if (string.Compare(Mira.Text, "Довжина") == 0)
                {

                    if (string.Compare(tmp, "см") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "м") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 100).ToString();
                        else if (string.Compare(odinici_out.Text, "км") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 100000).ToString();
                    }
                    else if (string.Compare(tmp, "м") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "км") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "см") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 100).ToString();
                    }
                    else if (string.Compare(tmp, "км") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "см") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 100000).ToString();
                        else if (string.Compare(odinici_out.Text, "м") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000).ToString();
                    }
                }
                else if(string.Compare(Mira.Text, "Маса") == 0)
                {
                    if (string.Compare(tmp, "кг") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "г") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) *1000).ToString();
                        else if (string.Compare(odinici_out.Text, "т") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000).ToString();
                    }
                    else if (string.Compare(tmp, "г") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "кг") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "т") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000000).ToString();
                    }
                    else if (string.Compare(tmp, "т") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "кг") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "г") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000000).ToString();
                    }
                }
                else if (string.Compare(Mira.Text, "Тиск") == 0)
                {
                    if (string.Compare(tmp, "Па") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "КПа") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "мПа") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000).ToString();
                    }
                    else if (string.Compare(tmp, "КПа") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "Па") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "мПа") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) * 1000000).ToString();
                    }
                    else if (string.Compare(tmp, "мПа") == 0)
                    {
                        if (string.Compare(odinici_out.Text, "Па") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000).ToString();
                        else if (string.Compare(odinici_out.Text, "КПа") == 0)
                            value_out.Text = (Convert.ToSingle(value_in.Text) / 1000000).ToString();
                    }
                }


            }
            catch(Exception exc)
            {

            }
        }
    }
}
