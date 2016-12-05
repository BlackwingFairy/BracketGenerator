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

        //private StackPanel MyFStackP_Create(TextBox numbox, TextBox namebox)
        //{
        //    StackPanel myStackP = new StackPanel()
        //    {
        //        Orientation = Orientation.Horizontal,
        //        Height = numbox.Height + 2,
        //        Width = numbox.Width + namebox.Width + 2
        //    };
        //    myStackP.Children.Add(numbox);
        //    myStackP.Children.Add(namebox);
        //    return myStackP;
        //}

        //private StackPanel PairStackP_Create(StackPanel stp1, StackPanel stp2)
        //{
        //    StackPanel pStackPanel = new StackPanel()
        //    {
        //        Orientation = Orientation.Vertical,
        //        Height = stp1.Height + stp2.Height + 2,
        //        Width = stp2.Width
        //    };
        //    pStackPanel.Children.Add(stp1);
        //    pStackPanel.Children.Add(stp2);
        //    return pStackPanel;
        //}

        //private StackPanel DuelStackP_Create(StackPanel pair, int duelNum)
        //{
        //    Label dnl = new Label()
        //    {
        //        Content = duelNum + "",
        //        VerticalAlignment = VerticalAlignment.Center,
        //        FontSize = 12,
        //        Width = FontSize * 3
        //    };
        //    StackPanel dStackPanel = new StackPanel()
        //    {
        //        Orientation = Orientation.Horizontal,
        //        Height = pair.Height + 2,
        //        Width = pair.Width + dnl.Width + 2,
        //    };
        //    dStackPanel.Children.Add(dnl);
        //    dStackPanel.Children.Add(pair);
        //    return dStackPanel;
        //}


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel[] pairs1 = new StackPanel[5];
            TextBox[] numbox = new TextBox[10];
            TextBox[] namebox = new TextBox[10];
            for (int i=0;i<5;i++)
            {
                Thickness myMargin = new Thickness() { Top = 0 };
                numbox[i] = new TextBox()
                {
                    Text = Convert.ToString(i + 1),
                    Height = FontSize*2+4,
                    Width = FontSize * 3,
                    FontSize = 12,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness() { Top = 1, Left = 1, Right = 1, Bottom = 1 },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                numbox[9 - i] = new TextBox()
                {
                    Text = Convert.ToString(10 - i),
                    Height = FontSize*2 + 4,
                    Width = FontSize * 3,
                    FontSize = 12,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness() { Top = 1, Left = 1, Right = 1, Bottom = 1 },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                namebox[i] = new TextBox()
                {
                    Text = "",
                    Height = FontSize*2 + 4,
                    Width = FontSize * 20,
                    FontSize = FontSize,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness() { Top = 1, Left = 1, Right = 1, Bottom = 1 },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Name = "myNTextbox" + i
                };

                namebox[9-i] = new TextBox()
                {
                    Text = "",
                    Height = FontSize*2 + 4,
                    Width = FontSize * 20,
                    FontSize = FontSize,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness() { Top = 1, Left = 1, Right = 1, Bottom = 1 },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Name = "myNTextbox" + i
                };

                pairs1[i] = DuelStackP_Create(PairStackP_Create(
                    MyFStackP_Create(numbox[i], namebox[i]), MyFStackP_Create(numbox[9 - i], namebox[9 - i])), i+1);
                myMargin.Top = i * (pairs1[i].Height*2);
                pairs1[i].Margin = myMargin;
                grid.Children.Add(pairs1[i]);
            }
            Polyline fork1 = FirstFork_Create(pairs1[0].Height / 3, pairs1[0].Width - 1, pairs1[0].Height / 3);
            grid.Children.Add(fork1);
        }
    }
}
