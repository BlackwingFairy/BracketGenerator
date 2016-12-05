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

        private void NamesWrapPanel_Create(DuelList list, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            StackPanel[] panel = new StackPanel[list.getSize()*2];
            TextBox[] myNTextbox = new TextBox[list.getSize()*2];
            TextBox[] numBox = new TextBox[list.getSize() * 2];

            Thickness myWPThickness = new Thickness() { Left = leftPosition };
            int height = fontSize * 2 + 4;
            int j = 0;
            for (int i = 0; i < list.getSize()*2; i++)
            {

                if (i % 2 == 0)
                {
                    myWPThickness.Top = (height - BorderThickness.Top) * (i + 1);

                    myNTextbox[i] = new TextBox()
                    {
                        Text = list.getDuel(i).comp1.name,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = height,
                        Width = fontSize * 30,
                        FontSize = fontSize,
                        BorderBrush = Brushes.Black,
                        BorderThickness = BorderThickness,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Name = "myNTextbox" + i
                    };
                    //myNTextbox[i].KeyDown += new KeyEventHandler(MyNTextbox_KeyDown);
                    numBox[i] = new TextBox()
                    {
                        Text = list.getDuel(i).comp1.ratingNum + "",
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = height,
                        Width = fontSize * 30,
                        FontSize = fontSize,
                        BorderBrush = Brushes.Black,
                        BorderThickness = BorderThickness,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Name = "myNTextbox" + i
                    };
                    panel[i] = new StackPanel()
                    {
                        Margin = myWPThickness,
                        Height = numBox[i].Height,
                        IsEnabled = list.getDuel(i).comp1.exist ? true : false
                    };
                    panel[i].Children.Add(numBox[i]);
                    panel[i].Children.Add(myNTextbox[i]);
                    grid.Children.Add(panel[i]);
                }
                else
                {
                    myWPThickness.Top = (height - BorderThickness.Top) * (i + 1);
                    myWPThickness.Bottom = myWPThickness.Top;
                    myNTextbox[i] = new TextBox()
                    {
                        Text = list.getDuel(j).comp2.name,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = height,
                        Width = fontSize * 30,
                        FontSize = fontSize,
                        BorderBrush = Brushes.Black,
                        BorderThickness = BorderThickness,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Name = "myNTextbox" + i
                    };
                    //myNTextbox[i].KeyDown += new KeyEventHandler(MyNTextbox_KeyDown);
                    numBox[i] = new TextBox()
                    {
                        Text = list.getDuel(j).comp2.ratingNum + "",
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = height,
                        Width = fontSize * 30,
                        FontSize = fontSize,
                        BorderBrush = Brushes.Black,
                        BorderThickness = BorderThickness,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Name = "myNTextbox" + i
                    };
                    panel[i] = new StackPanel()
                    {
                        Margin = myWPThickness,
                        Height = numBox[i].Height,
                        IsEnabled = list.getDuel(i).comp2.exist ? true : false
                    };
                    panel[i].Children.Add(numBox[i]);
                    panel[i].Children.Add(myNTextbox[i]);
                    grid.Children.Add(panel[i]);
                    j++;
                }
                
                
            }
        }

        


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness border = new Thickness() { Left = 1, Right = 1, Bottom = 1, Top = 1 };
            CompetitorsList newList = new CompetitorsList(8);
            for (int i=0; i<8;i++)
            {
                newList.setCompetitor(new Competitor(i, "", true),i);
            }
            DuelList newdlist = DuelMaker.duelDispose(DuelMaker.createDuels(newList));
            NamesWrapPanel_Create(newdlist, border, 12, 0, grid);
        }
    }
}
