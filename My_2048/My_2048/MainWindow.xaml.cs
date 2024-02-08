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

namespace My_2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] pole;
        bool youloose;
        public MainWindow()
        {
            InitializeComponent();
            pole = new Button[4, 4];
            pole[0, 0] = btn_11;
            pole[0, 1] = btn_12;
            pole[0, 2] = btn_13;
            pole[0, 3] = btn_14;

            pole[1, 0] = btn_21;
            pole[1, 1] = btn_22;
            pole[1, 2] = btn_23;
            pole[1, 3] = btn_24;

            pole[2, 0] = btn_31;
            pole[2, 1] = btn_32;
            pole[2, 2] = btn_33;
            pole[2, 3] = btn_34;

            pole[3, 0] = btn_41;
            pole[3, 1] = btn_42;
            pole[3, 2] = btn_43;
            pole[3, 3] = btn_44;


           
            
            Restart();
            
           
        }
        bool IF_You_Win()
        {
            for(int i=0;i<pole.GetLength(0);i++)
            {
                for(int j=0;j<pole.GetLength(0);j++)
                {
                    if(string.Compare((string)pole[i,j].Content,"2048")==0)
                    {
                        MessageBox.Show("Ви виграли:)");
                        return true;
                    }
                }
            }
            return false;
        }
        void GenerateSquare()
        {
            bool b = false;
            for(int i=0;i<pole.GetLength(0);i++)
            {
                for(int j=0;j<pole.GetLength(0); j++)
                {
                    if(string.Compare((string)pole[i,j].Content,"")==0)
                    {
                        b = true;
                        break;
                    }
                }
            }
            if(b)
            {
                Random r = new Random();
                int k = r.Next(1, 11);
                int x, y;
                if (k > 9)
                    k = 4;
                else
                    k = 2;            
                while(true)
                {        

                    x = r.Next(4);
                    y = r.Next(4);
                    
                    if (string.Compare((string)pole[x,y].Content,"")==0)
                    {
                        if(k==2)
                        pole[x,y].Style= (Style)this.Resources["style_2"];
                        else
                            pole[x, y].Style = (Style)this.Resources["style_4"];
                        break;
                    }
                }
            }
        }

        void Restart()
        {
            Update_Score();
            FileStream fs = new FileStream("score.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            high_score.Content = streamReader.ReadToEnd();
            streamReader.Dispose();
            fs.Close();
            youloose = false;
            now_score.Content = "0";
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(0); j++)
                {
                    pole[i, j].Style = (Style)this.Resources["style_0"];
                }
            }
            GenerateSquare();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Restart();
            //pole[0, 0].Style = (Style)this.Resources["style_2048"];
        }

        
        void MoveLeft()
        {
            for(int i=0;i<pole.GetLength(0);i++)
            {
                
                for(int k=0;k<pole.GetLength(0);k++)
                {
                    for(int j=k+1;j<pole.GetLength(0);j++)
                    {
                        if(string.Compare((string)pole[i,k].Content,"")==0&& string.Compare((string)pole[i, j].Content, "") != 0)
                        {
                            pole[i,k].Style= (Style)this.Resources["style_"+pole[i,j].Content];
                            pole[i, j].Style = (Style)this.Resources["style_0"];
                            
                            //break;
                        }
                        if(string.Compare((string)pole[i, k].Content, (string)pole[i, j].Content) == 0&& string.Compare((string)pole[i, k].Content,"")!=0)
                        {
                            bool connect = false;
                            if (k == j + 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k+1; l < j; l++)
                                {
                                    if(string.Compare((string)pole[i, l].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                            {
                                pole[i, k].Style = (Style)this.Resources["style_" + (Convert.ToInt32(pole[i, k].Content) + Convert.ToInt32(pole[i, j].Content)).ToString()];
                                pole[i, j].Style = (Style)this.Resources["style_0"];
                                now_score.Content = (Convert.ToInt32(now_score.Content) + Convert.ToInt32(pole[i, k].Content)).ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
        void MoveRight()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = pole.GetLength(0)-1; k >=0 ; k--)
                {
                    for (int j = k -1; j >=0; j--)
                    {
                        if (string.Compare((string)pole[i, k].Content, "") == 0 && string.Compare((string)pole[i, j].Content, "") != 0)
                        {
                            pole[i, k].Style = (Style)this.Resources["style_" + pole[i, j].Content];
                            pole[i, j].Style = (Style)this.Resources["style_0"];
                            //break;
                        }
                        if (string.Compare((string)pole[i, k].Content, (string)pole[i, j].Content) == 0 && string.Compare((string)pole[i, k].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j - 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k - 1; l > j; l--)
                                {
                                    if (string.Compare((string)pole[i, l].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                            {
                                pole[i, k].Style = (Style)this.Resources["style_" + (Convert.ToInt32(pole[i, k].Content) + Convert.ToInt32(pole[i, j].Content)).ToString()];
                                pole[i, j].Style = (Style)this.Resources["style_0"];
                                now_score.Content = (Convert.ToInt32(now_score.Content) + Convert.ToInt32(pole[i, k].Content)).ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
        void MoveUp()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = 0; k < pole.GetLength(0); k++)
                {
                    for (int j = k + 1; j < pole.GetLength(0); j++)
                    {
                        if (string.Compare((string)pole[k, i].Content, "") == 0 && string.Compare((string)pole[j, i].Content, "") != 0)
                        {
                            pole[k, i].Style = (Style)this.Resources["style_" + pole[j, i].Content];
                            pole[j, i].Style = (Style)this.Resources["style_0"];
                            //break;
                        }
                        if (string.Compare((string)pole[k, i].Content, (string)pole[j, i].Content) == 0 && string.Compare((string)pole[k, i].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j + 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k + 1; l < j; l++)
                                {
                                    if (string.Compare((string)pole[l, i].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                            {
                                pole[k, i].Style = (Style)this.Resources["style_" + (Convert.ToInt32(pole[k, i].Content) + Convert.ToInt32(pole[j, i].Content)).ToString()];
                                pole[j, i].Style = (Style)this.Resources["style_0"];
                                now_score.Content = (Convert.ToInt32(now_score.Content) + Convert.ToInt32(pole[k, i].Content)).ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
        void MoveDown()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = pole.GetLength(0) - 1; k >= 0; k--)
                {
                    for (int j = k - 1; j >= 0; j--)
                    {
                        if (string.Compare((string)pole[k, i].Content, "") == 0 && string.Compare((string)pole[j, i].Content, "") != 0)
                        {
                            pole[k, i].Style = (Style)this.Resources["style_" + pole[j, i].Content];
                            pole[j, i].Style = (Style)this.Resources["style_0"];
                            //break;
                        }
                        if (string.Compare((string)pole[k, i].Content, (string)pole[j, i].Content) == 0 && string.Compare((string)pole[k, i].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j - 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k - 1; l > j; l--)
                                {
                                    if (string.Compare((string)pole[l, i].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                            {
                                pole[k, i].Style = (Style)this.Resources["style_" + (Convert.ToInt32(pole[k, i].Content) + Convert.ToInt32(pole[j, i].Content)).ToString()];
                                pole[j, i].Style = (Style)this.Resources["style_0"];
                                now_score.Content = (Convert.ToInt32(now_score.Content) + Convert.ToInt32(pole[k, i].Content)).ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
        bool IF_You_Loose()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = 0; k < pole.GetLength(0); k++)
                {
                    for (int j = k + 1; j < pole.GetLength(0); j++)
                    {
                        if (string.Compare((string)pole[i, k].Content, "") == 0 && string.Compare((string)pole[i, j].Content, "") != 0)
                            return false;
                        if (string.Compare((string)pole[i, k].Content, (string)pole[i, j].Content) == 0 && string.Compare((string)pole[i, k].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j + 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k + 1; l < j; l++)
                                {
                                    if (string.Compare((string)pole[i, l].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                                return false;

                        }
                    }
                }
            }

            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = pole.GetLength(0) - 1; k >= 0; k--)
                {
                    for (int j = k - 1; j >= 0; j--)
                    {
                        if (string.Compare((string)pole[i, k].Content, "") == 0 && string.Compare((string)pole[i, j].Content, "") != 0)
                            return false;
                        if (string.Compare((string)pole[i, k].Content, (string)pole[i, j].Content) == 0 && string.Compare((string)pole[i, k].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j - 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k - 1; l > j; l--)
                                {
                                    if (string.Compare((string)pole[i, l].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                                return false;
                        }
                    }
                }
            }

            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = 0; k < pole.GetLength(0); k++)
                {
                    for (int j = k + 1; j < pole.GetLength(0); j++)
                    {
                        if (string.Compare((string)pole[k, i].Content, "") == 0 && string.Compare((string)pole[j, i].Content, "") != 0)
                            return false;
                        if (string.Compare((string)pole[k, i].Content, (string)pole[j, i].Content) == 0 && string.Compare((string)pole[k, i].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j + 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k + 1; l < j; l++)
                                {
                                    if (string.Compare((string)pole[l, i].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                                return false;
                        }
                    }
                }
            }

            for (int i = 0; i < pole.GetLength(0); i++)
            {

                for (int k = pole.GetLength(0) - 1; k >= 0; k--)
                {
                    for (int j = k - 1; j >= 0; j--)
                    {
                        if (string.Compare((string)pole[k, i].Content, "") == 0 && string.Compare((string)pole[j, i].Content, "") != 0)
                            return false;
                        if (string.Compare((string)pole[k, i].Content, (string)pole[j, i].Content) == 0 && string.Compare((string)pole[k, i].Content, "") != 0)
                        {
                            bool connect = false;
                            if (k == j - 1)
                                connect = true;
                            else
                            {
                                connect = true;
                                for (int l = k - 1; l > j; l--)
                                {
                                    if (string.Compare((string)pole[l, i].Content, "") != 0)
                                    {
                                        connect = false;
                                        break;
                                    }
                                }
                            }
                            if (connect)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        void Update_Score()
        {
            FileStream fs = new FileStream("score.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            if (Convert.ToInt32(now_score.Content) > Convert.ToInt32(streamReader.ReadToEnd()))
            {
                high_score.Content = now_score.Content;
                streamReader.Dispose();
                fs.Close();
                fs = new FileStream("score.txt", FileMode.Create, FileAccess.Write, FileShare.Write);

                StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);
                streamWriter.WriteLine(high_score.Content);
                streamWriter.Dispose();
                fs.Close();
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Title = e.Key.ToString();
            if (!youloose)
            {
                if (e.Key == Key.Left||e.Key==Key.A)
                {
                    MoveLeft();
                    GenerateSquare();
                }
                else if (e.Key == Key.Right || e.Key == Key.D)
                {
                    MoveRight();
                    GenerateSquare();
                }
                else if (e.Key == Key.Up || e.Key == Key.W)
                {
                    MoveUp();
                    GenerateSquare();
                }
                else if (e.Key == Key.Down || e.Key == Key.S)
                {
                    MoveDown();
                    GenerateSquare();
                }
                if(IF_You_Win())
                {
                    youloose = true;
                    Update_Score();
                }
                if (IF_You_Loose())
                {
                    youloose = true;
                    Update_Score();

                    MessageBox.Show("Ви програли:(");

                }
            }
        }
    }
}
