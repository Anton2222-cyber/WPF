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
using System.Windows.Threading;

namespace KeyboardTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<char> symbols;
        DispatcherTimer timer;
        DispatcherTimer timer_speed;
        Border border_now;
        int count_symbol_for_second;
        int index;
        string read_txt;
        string write_now;
        int count_fails;
        bool is_small_symbol;
        bool ready;
        public MainWindow()
        {
            InitializeComponent();
            symbols = new List<char>();
            symbols.Add('~');
            symbols.Add('!');
            symbols.Add('@');
            symbols.Add('#');
            symbols.Add('$');
            symbols.Add('%');
            symbols.Add('^');
            symbols.Add('&');
            symbols.Add('*');
            symbols.Add('(');
            symbols.Add(')');
            symbols.Add('_');
            symbols.Add('+');
            symbols.Add('Q');
            symbols.Add('W');
            symbols.Add('E');
            symbols.Add('R');
            symbols.Add('T');
            symbols.Add('Y');
            symbols.Add('U');
            symbols.Add('I');
            symbols.Add('O');
            symbols.Add('P');
            symbols.Add('{');
            symbols.Add('}');
            symbols.Add('|');
            symbols.Add('A');
            symbols.Add('S');
            symbols.Add('D');
            symbols.Add('F');
            symbols.Add('G');
            symbols.Add('H');
            symbols.Add('J');
            symbols.Add('K');
            symbols.Add('L');
            symbols.Add(':');
            symbols.Add('"');
            symbols.Add('Z');
            symbols.Add('X');
            symbols.Add('C');
            symbols.Add('V');
            symbols.Add('B');
            symbols.Add('N');
            symbols.Add('M');
            symbols.Add('<');
            symbols.Add('>');
            symbols.Add('?');
            symbols.Add(' ');
            symbols.Add('q');
            symbols.Add('w');
            symbols.Add('e');
            symbols.Add('r');
            symbols.Add('t');
            symbols.Add('y');
            symbols.Add('u');
            symbols.Add('i');
            symbols.Add('o');
            symbols.Add('p');
            symbols.Add('a');
            symbols.Add('s');
            symbols.Add('d');
            symbols.Add('f');
            symbols.Add('g');
            symbols.Add('h');
            symbols.Add('j');
            symbols.Add('k');
            symbols.Add('l');
            symbols.Add('z');
            symbols.Add('x');
            symbols.Add('c');
            symbols.Add('v');
            symbols.Add('b');
            symbols.Add('n');
            symbols.Add('m');
            index = 0;
            ready = false;
            is_small_symbol = true;
            count_fails = 0;
            count_symbol_for_second = 0;
            write_now = "";
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);

            timer_speed = new DispatcherTimer();
            timer_speed.Tick += new EventHandler(Tick_Speed);
            timer_speed.Interval = new TimeSpan(0, 0,1);
            timer_speed.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            border_now.BorderBrush = Brushes.White;
            timer.Stop();
        }
        private void Tick_Speed(object sender, EventArgs e)
        {
            Speed.Content = (60 * count_symbol_for_second).ToString();
            count_symbol_for_second = 0;
           
        }

        private void scrol_dificult_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scrol_dificult.Value = Math.Round(e.NewValue /*/ 1.0*/) /** 1.0*/;
            dificult.Content = scrol_dificult.Value.ToString();
        }
        bool IsNeIs(string txt, char symbol)
        {
            for(int i=0;i<txt.Length;i++)
            {
                if (txt[i] == symbol)
                    return true;
            }
            return false;
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            //Progress.Width = 6;
            ready = true;
            Random random = new Random();
            scrol_dificult.IsEnabled = false;
            registr.IsEnabled = false;
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            string txt="  ";
            for(int i=0;i<Convert.ToInt32(dificult.Content);i++)
            {
                int k = random.Next(symbols.Count);
                char l = symbols[k];
                if(!IsNeIs(txt,l))
                {
                    txt += l;
                }
            }
            read_txt="";
            for(int i=0;i<50;i++)
            {
                char y = txt[random.Next(txt.Length)];
                read_txt += y;
            }
           
            txt_read.Content = read_txt;
        }
        void Fill_Progress(char y)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == 0)
                {
                    if (y == '|' || y == ':' || y == 'i' || y == 'I' || y == 'l' || y == 'j' || y == '!'  || y == 'r' || y == 'f')
                        Progress.Width += 7;
                    else if(y == '"')
                        Progress.Width += 8;                 
                    else if(y == ' '||y=='_')
                        Progress.Width += 10;
                    else if(y=='L')
                        Progress.Width += 15;
                    else if ( y == '(' || y == ')' || y == '}' || y == '{'||y=='J'|| y == '?')
                        Progress.Width += 9;
                    else if(y=='X'||y=='Y')
                        Progress.Width += 18;
                    else if (y == 'Q' || y == 'w' || y == 'N' || y == 'O' || y == 'H' || y == 'U' || y == '^' || y == 'G' || y == 'D')
                        Progress.Width += 21;
                    else if (y == '@' || y == 'W')
                        Progress.Width += 28;
                    else if (y == 'M' || y == '%' || y == '&' || y == 'm')
                        Progress.Width += 25;                   
                    else if (char.IsUpper(y) || y == '>' || y == '~' || y == '<' || y == '#' || y == 'b' || y == '+'  || y == 'h' || y == 'q' || y == '$' || y == 'g' || y == 'o' || y == 'u' || y == 'p' || y == 'd' || y == 'n')
                        Progress.Width += 17;
                    else
                        Progress.Width += 15;
                }
            }
        }
        void Do_Or_Not_Do(char s)
        {
            try
            {
                if (read_txt[index] == s)
                {
                    if (index == read_txt.Length - 1)
                        Progress.Width = 974;
                    else
                        Fill_Progress(read_txt[index]);
                    write_now += read_txt[index];
                    txt_write.Content = write_now;
                    index++;
                }
                else
                {
                    count_fails++;
                    Fails.Content = count_fails.ToString();
                }
            }
            catch(Exception e)
            {

            }
        }
        void Do_Or_Not_Do_for_letter(char s)
        {
            if (registr.IsChecked == true)
            {
                if (is_small_symbol)
                    Do_Or_Not_Do(char.ToLower(s));
                else
                    Do_Or_Not_Do(char.ToUpper(s));
            }
            else
            {
                if (char.IsUpper(read_txt[index]))
                    Do_Or_Not_Do(char.ToUpper(s));
                else
                    Do_Or_Not_Do(char.ToLower(s));
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Fails.Content = e.Key.ToString();

            if (ready)
            {
                count_symbol_for_second++;
                if (e.Key == Key.OemTilde)
                {
                    tilda.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('~');

                    border_now = tilda;
                    timer.Start();
                }
                else if (e.Key == Key.D1)
                {
                    oklick.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('!');
                    border_now = oklick;
                    timer.Start();
                }
                else if (e.Key == Key.D2)
                {
                    dog.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('@');
                    border_now = dog;
                    timer.Start();
                }
                else if (e.Key == Key.D3)
                {
                    grate.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('#');
                    border_now = grate;
                    timer.Start();
                }
                else if (e.Key == Key.D4)
                {
                    dolar.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('$');
                    border_now = dolar;
                    timer.Start();
                }
                else if (e.Key == Key.D5)
                {
                    persent.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('%');
                    border_now = persent;
                    timer.Start();
                }
                else if (e.Key == Key.D6)
                {
                    pov_my.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('^');
                    border_now = pov_my;
                    timer.Start();
                }
                else if (e.Key == Key.D7)
                {
                    and.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('&');
                    border_now = and;
                    timer.Start();
                }
                else if (e.Key == Key.D8)
                {
                    star.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('*');
                    border_now = star;
                    timer.Start();
                }
                else if (e.Key == Key.D9)
                {
                    left_dyga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('(');
                    border_now = left_dyga;
                    timer.Start();
                }
                else if (e.Key == Key.D0)
                {
                    right_dyga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do(')');
                    border_now = right_dyga;
                    timer.Start();
                }
                else if (e.Key == Key.OemMinus)
                {
                    lower_.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('_');
                    border_now = lower_;
                    timer.Start();
                }
                else if (e.Key == Key.OemPlus)
                {
                    plus.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('+');
                    border_now = plus;
                    timer.Start();
                }
                else if (e.Key == Key.Q)
                {
                    Q.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('Q');
                    border_now = Q;
                    timer.Start();
                }
                else if (e.Key == Key.W)
                {
                    W.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('W');
                    border_now = W;
                    timer.Start();
                }
                else if (e.Key == Key.E)
                {
                    E.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('E');
                    border_now = E;
                    timer.Start();
                }
                else if (e.Key == Key.R)
                {
                    R.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('R');
                    border_now = R;
                    timer.Start();
                }
                else if (e.Key == Key.T)
                {
                    T.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('T');
                    border_now = T;
                    timer.Start();
                }
                else if (e.Key == Key.Y)
                {
                    Y.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('Y');
                    border_now = Y;
                    timer.Start();
                }
                else if (e.Key == Key.U)
                {
                    U.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('U');
                    border_now = U;
                    timer.Start();
                }
                else if (e.Key == Key.I)
                {
                    I.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('I');
                    border_now = I;
                    timer.Start();
                }
                else if (e.Key == Key.O)
                {
                    O.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('O');
                    border_now = O;
                    timer.Start();
                }
                else if (e.Key == Key.P)
                {
                    P.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('P');
                    border_now = P;
                    timer.Start();
                }
                else if (e.Key == Key.OemOpenBrackets)
                {
                    left_figure_dyga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('{');
                    border_now = left_figure_dyga;
                    timer.Start();
                }
                else if (e.Key == Key.OemCloseBrackets)
                {
                    right_figure_dyga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('}');
                    border_now = right_figure_dyga;
                    timer.Start();
                }
                else if (e.Key == Key.Oem5)
                {
                    line.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('|');
                    border_now = line;
                    timer.Start();
                }
                else if (e.Key == Key.CapsLock)
                {
                    capslock.BorderBrush = Brushes.Red;
                    is_small_symbol = !is_small_symbol;
                    border_now = capslock;
                    timer.Start();
                }
                else if (e.Key == Key.A)
                {
                    A.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('A');
                    border_now = A;
                    timer.Start();
                }
                else if (e.Key == Key.S)
                {
                    S.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('S');
                    border_now = S;
                    timer.Start();
                }
                else if (e.Key == Key.D)
                {
                    D.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('D');
                    border_now = D;
                    timer.Start();
                }
                else if (e.Key == Key.F)
                {
                    F.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('F');
                    border_now = F;
                    timer.Start();
                }
                else if (e.Key == Key.G)
                {
                    G.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('G');
                    border_now = G;
                    timer.Start();
                }
                else if (e.Key == Key.H)
                {
                    H.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('H');
                    border_now = H;
                    timer.Start();
                }
                else if (e.Key == Key.J)
                {
                    J.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('J');
                    border_now = J;
                    timer.Start();
                }
                else if (e.Key == Key.K)
                {
                    K.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('K');
                    border_now = K;
                    timer.Start();
                }
                else if (e.Key == Key.L)
                {
                    L.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('L');
                    border_now = L;
                    timer.Start();
                }
                else if (e.Key == Key.Oem1)
                {
                    two_points.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do(':');
                    border_now = two_points;
                    timer.Start();
                }
                else if (e.Key == Key.OemQuotes)
                {
                    lapki.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('"');
                    border_now = lapki;
                    timer.Start();
                }
                else if (e.Key == Key.LeftShift)
                {
                    shift.BorderBrush = Brushes.Red;
                    is_small_symbol = false;
                    border_now = shift;
                    timer.Start();
                }
                else if (e.Key == Key.Z)
                {
                    Z.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('Z');
                    border_now = Z;
                    timer.Start();
                }
                else if (e.Key == Key.X)
                {
                    X.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('X');
                    border_now = X;
                    timer.Start();
                }
                else if (e.Key == Key.C)
                {
                    C.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('C');
                    border_now = C;
                    timer.Start();
                }
                else if (e.Key == Key.V)
                {
                    V.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('V');
                    border_now = V;
                    timer.Start();
                }
                else if (e.Key == Key.B)
                {
                    B.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('B');
                    border_now = B;
                    timer.Start();
                }
                else if (e.Key == Key.N)
                {
                    N.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('N');
                    border_now = N;
                    timer.Start();
                }
                else if (e.Key == Key.M)
                {
                    M.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do_for_letter('M');
                    border_now = M;
                    timer.Start();
                }
                else if (e.Key == Key.OemComma)
                {
                    left_trik_duga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('<');
                    border_now = left_trik_duga;
                    timer.Start();
                }
                else if (e.Key == Key.OemPeriod)
                {
                    right_trik_duga.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('>');
                    border_now = right_trik_duga;
                    timer.Start();
                }
                else if (e.Key == Key.OemQuestion)
                {
                    pitanna.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do('?');
                    border_now = pitanna;
                    timer.Start();
                }
                else if (e.Key == Key.RightShift)
                {
                    shift2.BorderBrush = Brushes.Red;
                    is_small_symbol = false;
                    border_now = shift2;
                    timer.Start();
                }
                else if (e.Key == Key.Space)
                {
                    space.BorderBrush = Brushes.Red;
                    Do_Or_Not_Do(' ');
                    border_now = space;
                    timer.Start();
                }
            }
            //is_small_symbol = true;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            ready = false;
            scrol_dificult.IsEnabled = true;
            registr.IsEnabled = true;
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
            index = 0;            
            is_small_symbol = true;
            count_fails = 0;
            count_symbol_for_second = 0;
            write_now = "";
            txt_read.Content = "";
            txt_write.Content = "";
            Progress.Width = 6;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.LeftShift)           
                is_small_symbol = true;
            else if(e.Key==Key.RightShift)
                is_small_symbol = true;
        }
    }
}
