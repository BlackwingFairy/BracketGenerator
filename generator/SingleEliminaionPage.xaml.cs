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

namespace generator
{
    /// <summary>
    /// Логика взаимодействия для SingleEliminaionPage.xaml
    /// </summary>
    public partial class SingleEliminaionPage : Page
    {
        public SingleEliminaionPage()
        {
            InitializeComponent();
        }

        int gridSize;                       //переменные, участвующие в передаче информации между страницами
        public int GridSize
        {
            set { gridSize = value; }
            get { return gridSize; }
        }
        string tName;
        public string TName
        {
            set { tName = value; }
            get { return tName; }
        }

        CompetitorsList selist;
        public CompetitorsList Selist
        {
            set { selist = value; }
            get { return selist; }
        }

        private Polyline FirstFork_Create(double top, double left, double height)
        {
            Point myPoint = new Point(left, top);
            Polyline fork = new Polyline()
            {
                Points = new PointCollection()
                {
                    myPoint, new Point(myPoint.X+20,myPoint.Y), new Point(myPoint.X+20,myPoint.Y+height/2),
                    new Point(myPoint.X+40,myPoint.Y+height/2), new Point(myPoint.X+20,myPoint.Y+height/2),
                    new Point(myPoint.X+20,myPoint.Y+height),new Point(myPoint.X,myPoint.Y+height)
                },
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            return fork;
        }

        
        private void Step_Create(Duel duel,int leftPos, int topPos, int stepNum, int fontSize, Thickness borderThickness, Grid grid)
        {
            
            TextBox nBox1 = new TextBox()
            {
                Text = duel.comp1.name,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = fontSize * 2,
                Width = fontSize * 20,
                BorderBrush = Brushes.Black,
                BorderThickness = borderThickness
            };
            TextBox nbox2 = new TextBox()
            {
                Text = duel.comp2.name,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = fontSize * 2,
                Width = fontSize * 20,
                BorderBrush = Brushes.Black,
                BorderThickness = borderThickness
            };
            TextBox number1 = new TextBox()
            {
                Text = duel.comp1.ratingNum+"",
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = fontSize * 2,
                Width = fontSize * 3,
                BorderBrush = Brushes.Black,
                BorderThickness = borderThickness
            };
            TextBox number2 = new TextBox()
            {
                Text = duel.comp2.ratingNum + "",
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = fontSize * 2,
                Width = fontSize * 3,
                BorderBrush = Brushes.Black,
                BorderThickness = borderThickness
            };
            WrapPanel panel = new WrapPanel()
            {
                Height = 2 * number1.Height,
                Width = number1.Width + nBox1.Width,
                Margin = new Thickness() { Left=leftPos, Bottom = topPos}
            };
            panel.Children.Add(number1);
            panel.Children.Add(nBox1);
            panel.Children.Add(number2);
            panel.Children.Add(nbox2);
            grid.Children.Add(panel);
        }
        


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness border = new Thickness() { Left = 1, Right = 1, Bottom = 1, Top = 1 };
            DuelList newdlist = DuelMaker.duelDispose(DuelMaker.createDuels(selist));
            int counter = 0;
            foreach (Duel d in newdlist.List)
            {
                Step_Create(d, 0, 120 * counter, 1, 12, border, grid);
                Polyline fork = FirstFork_Create(14+60*counter, 12 * 23, 24);
                grid.Children.Add(fork);
                counter++;
            }
            
        }
    }
}
