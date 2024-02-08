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
using System.IO;

namespace Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> cars_lst;
        public MainWindow()
        {
            InitializeComponent();
            cars_lst = new List<Car>();
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listbox.ItemsSource = null;
            cars_lst = new List<Car>();
            FileStream fs = new FileStream("my_cars.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            for (int i = 0; i < 4; i++)
            {
                Car car = new Car();
                car.Mark = streamReader.ReadLine();
                car.Model = streamReader.ReadLine();
                car.Cost = Convert.ToSingle(streamReader.ReadLine());
                car.Description = streamReader.ReadLine();
                cars_lst.Add(car);
            }

            streamReader.Dispose();
            fs.Close();
            listbox.ItemsSource = cars_lst;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                car_mark.Text = cars_lst[listbox.SelectedIndex].Mark;
                car_model.Text = cars_lst[listbox.SelectedIndex].Model;
                car_cost.Text = cars_lst[listbox.SelectedIndex].Cost.ToString();
                car_description.Text = cars_lst[listbox.SelectedIndex].Description;
            }
            catch(Exception exc)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            cars_lst.RemoveAt(listbox.SelectedIndex);
            listbox.ItemsSource = null;
            listbox.ItemsSource = cars_lst;
            car_mark.Text = "";
            car_model.Text = "";
            car_cost.Text = "";
            car_description.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                bool b = true;
                for (int i = 0; i < cars_lst.Count; i++)
                {
                    if (string.Compare(car_mark.Text, cars_lst[i].Mark) == 0 && string.Compare(car_model.Text, cars_lst[i].Model) == 0 && Convert.ToSingle(car_cost.Text) == cars_lst[i].Cost)
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    Car car = new Car();
                    car.Mark = car_mark.Text;
                    car.Model = car_model.Text;
                    car.Cost = Convert.ToSingle(car_cost.Text);
                    car.Description = car_description.Text;
                    cars_lst.Add(car);
                    listbox.ItemsSource = null;
                    listbox.ItemsSource = cars_lst;
                }
            }
            catch(Exception exc)
            {

            }
        }
    }
    class Car
    {
        public string Mark { set; get; }
        public string Model { set; get; }
        public float Cost { set; get; }
        public string Description { set; get; }

        public override string ToString()
        {
            return Mark + " " + Model;
        }
    }
}
