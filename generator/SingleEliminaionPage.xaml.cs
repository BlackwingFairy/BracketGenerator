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

        private Polyline Fork_Create(double top, double left, double height)
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

        private TextBox Numbox_Create(int content)
        {
            return new TextBox()
            {
                Text = content+"",
                Height = 28,
                Width = 36,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness() { Top = 1, Bottom = 1 },
                IsEnabled = false
            };
        }

        private TextBox Namebox_Create(bool exist, string name)
        {
            return new TextBox()
            {
                Text = name,
                Height = 28,
                Width = 36 * 5,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness() { Top = 1, Bottom = 1 },
                IsEnabled = exist
            };
        }

        private WrapPanel Duel_Create(double top, double left, int num, Duel duel)
        {
            WrapPanel NewPanel = new WrapPanel()
            {
                Name = "WrapPanel" + num,
                Height = 60,
                Width = 36*6,
                Margin = new Thickness() { Top = top, Left = left },
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            NewPanel.Children.Add(Numbox_Create(duel.comp1.ratingNum));
            NewPanel.Children.Add(Namebox_Create(duel.comp1.exist, duel.comp1.name));
            NewPanel.Children.Add(Numbox_Create(duel.comp2.ratingNum));
            NewPanel.Children.Add(Namebox_Create(duel.comp2.exist, duel.comp2.name));
            return NewPanel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DuelList Dlist = DuelMaker.duelDispose(DuelMaker.createDuels(Selist));
            int step = 70;
            for (int i=0;i<Dlist.getSize();i++)
            {
                WrapPanel p1 = Duel_Create(step*i, 0, 1,Dlist.getDuel(i));
                grid.Children.Add(p1);
            }
            //Polyline Fork = Fork_Create(14,36*6,28);



            //Polyline Fork2 = Fork_Create(14+70, 36 * 6, 28);
           
            //grid.Children.Add(Fork);
           
        }
    } 
}
