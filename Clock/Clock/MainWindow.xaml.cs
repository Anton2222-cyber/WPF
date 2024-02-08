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

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		protected DispatcherTimer timer;
		public MainWindow()
        {
            InitializeComponent();
			for (int i = 1; i <= 12; i++)
			{
				Point point = ToCordinates(GetCoordinates(360.0 / 12 * i, Get_Radius_Clock() * (5.0 / 6)));
				

				Label label = new Label();
				label.Foreground = Brushes.White;
				label.Width = 50;
				label.Height = 50;
				label.Content = i.ToString();
				label.HorizontalContentAlignment = HorizontalAlignment.Center;
				label.VerticalContentAlignment = VerticalAlignment.Center;
				label.FontSize = 35;
				
				label.FontFamily = new FontFamily("Source Sans Pro Black");
				label.Margin = new Thickness(point.X - 25, point.Y - 25, 0, 0);
				

				ClockPlace.Children.Add(label);
			}
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 23);
			timer.Tick += Update;
			timer.Start();
			Update(this, EventArgs.Empty);
		}
		

		protected Point GetCoordinates(double degrees, double lineLength)
		{
			return new Point
			{
				X = Math.Sin(DegreesToRadians(degrees)) * lineLength,
				Y = -Math.Cos(DegreesToRadians(degrees)) * lineLength
			};
		}


		protected void Update(object sender, EventArgs e)
		{
			DateTime time = DateTime.Now;

			SetLine(SecondsLine, time.Second * 6, Get_Radius_Clock());
			SetLine(MinutessLine, time.Minute * 6, (int)(Get_Radius_Clock() * (2.0 / 3)));
			SetLine(HoursLine, time.Hour%12*30+time.Minute*0.5, (int)(Get_Radius_Clock() * (1.0 / 3)));
		}

		protected void SetLine(Line line, double degrees, int lineLength)
		{
			Point point = new Point(0, 0);

			point.X = Math.Sin(DegreesToRadians(degrees)) * lineLength;
			point.Y = -Math.Cos(DegreesToRadians(degrees)) * lineLength;
			point = ToCordinates(point);

			line.X2 = point.X;
			line.Y2 = point.Y;
		}

		protected double DegreesToRadians(double degrees)
		{
			return degrees * (Math.PI / 180);
		}

		protected Point ToCordinates(Point point)
		{
			return new Point(point.X + Get_Radius_Clock(), point.Y + Get_Radius_Clock());
		}

		protected int Get_Radius_Clock()
		{
			return (int)(Ellipse_Clock.Width / 2);
		}
	}
}

