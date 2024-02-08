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

namespace Login2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people;
        public MainWindow()
        {
            InitializeComponent();
           

            FileStream fs = new FileStream("people.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            people = new List<Person>(Convert.ToInt32(streamReader.ReadLine()));

            for (int i = 0; i < people.Capacity;i++)           
                people.Add(new Person { Username = streamReader.ReadLine(), Password = streamReader.ReadLine()});
            
            streamReader.Dispose();
            fs.Close();
            fs = new FileStream("remember_people.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            streamReader = new StreamReader(fs, Encoding.UTF8);
            string tmp = streamReader.ReadLine();
            if(string.Compare(tmp,"0")!=0)
            {
                text_username.Text = tmp;
                text_password.Text = streamReader.ReadLine();
            }
            streamReader.Dispose();
            fs.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            for(int i=0;i<people.Count;i++)
            {
                if(string.Compare(text_password.Text,people[i].Password)==0&&string.Compare(text_username.Text,people[i].Username)==0)
                {
                    b = true;
                    if (remember_me.IsChecked==true)
                    {
                        
                        FileStream fs = new FileStream("remember_people.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
                        StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);
                        streamWriter.WriteLine(text_username.Text);
                        streamWriter.WriteLine(text_password.Text);
                        streamWriter.Dispose();
                        fs.Close();
                    }
                    MessageBox.Show("Авторизація пройшла успішно!");
                    Mywindow.Close();
                }
            }
            if(!b)
            MessageBox.Show("Немає такого користувача");
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Mywindow.Close();
        }
    }
    class Person
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
