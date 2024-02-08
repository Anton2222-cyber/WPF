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

namespace Book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int k = 1;
        public MainWindow()
        {
            InitializeComponent();
        }
        void Info()
        {
            switch (k)
            {
                case 1:
                    txt.Text = "Росли́ни (Plantae), або зелені рослини (Viridiplantae) — царство живих організмів. Назва Viridiplantae була запропонована у 1981[1] році, щоб відрізнити представників царства від попереднього визначення рослин, які до того не утворювали монофілетичну групу. Також царство відоме під назвою Chlorobionta[2] або група Chlorophyta/Embryophyta.[3] Більшість членів царства були включені до царства Рослини (Plantae) в 1866 Ернстом Геккелем. Представники царства — автотрофні організми, для яких є характерною здатність до фотосинтезу та наявність щільної клітинної оболонки, яка утворена здебільшого целюлозою.";
                    break;
                case 2:
                    txt.Text = "Вони є джерелом більш як десяти тисяч біологічно активних речовин, які діють на організм людини та тварин, зокрема при вживанні у їжу.Вивченням рослин займається ботаніка.";
                    break;
                case 3:
                    txt.Text = "Царство рослин налічує понад 500 тисяч видів. Усі рослини поділяються на 2 відділи: справжні зелені водорості (Chlorophyta), до яких відносять більшість зелених водоростей, і вищі рослини (Streptophyta), до якого відносять деякі складніші зелені водорості та всі наземні рослини.Раніше до нижчих рослин відносили також слизовики, гриби, усі водорості(діатомові, бурі, червоні, евгленові тощо), але на початку XXI сторіччя перші дві групи класифіковано до окремого царства — Гриби(Fungi), а систематика решти залишалася невизначеною(incertae sedis), іноді їх включали до царства Найпростіші.";
                    break;
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(k<3)
            k++;
            Info();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if(k>1)
            k--;
            Info();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            txt.HorizontalAlignment = HorizontalAlignment.Right;
            txt.Width = 300;
            txt.Height = 300;

            Next.Content = "-->Next other page and window";
            Prev.Content = "<--Prev other page and window";
            Next.Width = 450;
            Prev.Width = 450;
            Cancel.Width = 450;
            button.Width = 450;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Width = 531;
            txt.Height = 228;
            txt.Margin = new Thickness(253, 50, 0, 0);
            Next.Width = 187;
            Prev.Width = 187;
            Cancel.Width = 187;
            button.Width = 238;
            Next.Content = ">Next";
            Prev.Content = "Prev<";
        }
    }
}
