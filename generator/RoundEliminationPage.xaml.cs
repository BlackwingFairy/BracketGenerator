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
    /// Логика взаимодействия для RoundEliminationPage.xaml
    /// </summary>
    public partial class RoundEliminationPage : Page
    {
        public RoundEliminationPage()
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

        CompetitorsList relist;
        public CompetitorsList Relist
        {
            set { relist = value; }
            get { return relist; }
        }


        private void Vlabel_Create(int number, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            Label[] myVLabel = new Label[number];
            Thickness myVLabelThickness = new Thickness() { Left = leftPosition };
            int height = fontSize * 2 + 4;
            myVLabelThickness.Top = height;

            for (int i = 0; i < myVLabel.Length; i++)
            {
                myVLabelThickness.Top =height + (height-BorderThickness.Top) * i;
                myVLabel[i] = new Label()
                {
                    Content = Convert.ToString(i + 1),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = myVLabelThickness,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = height,
                    Width = fontSize*3,
                    FontSize = fontSize,
                    BorderBrush = Brushes.Black,
                    BorderThickness = BorderThickness,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                grid.Children.Add(myVLabel[i]);
            }
        }

        private void NameLabel_Create(string name, int width, int leftPosition, int fontSize, Thickness BorderThickness, Grid grid)
        {
            Thickness myNLabelThickness = new Thickness() { Left = leftPosition, Top = 1 };
            Label nameLabel = new Label()
            {
                Content = name,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = myNLabelThickness,
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = fontSize * 2 + 4,
                Width = width,
                FontSize = fontSize,
                BorderBrush = Brushes.Black,
                BorderThickness = BorderThickness,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            grid.Children.Add(nameLabel);
        }


        private void MyNTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TextBox tbox = sender as TextBox;
                for (int i = 0; i < relist.getSize(); i++)
                {
                    Competitor comp = relist.getCompetitor(i);
                    if (Convert.ToInt16(tbox.Name.Last()) == comp.ratingNum)
                    {
                        comp.name = tbox.Text;
                    }
                    relist.setCompetitor(comp, i);
                }
            }
        }


        private void NameTextbox_Create(CompetitorsList list, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            TextBox[] myNTextbox = new TextBox[list.getSize()];
            Thickness myNTextboxThickness = new Thickness() { Left = leftPosition };
            int height = fontSize * 2 + 4;
            myNTextboxThickness.Top = height;

            for (int i = 0; i < list.getSize(); i++)
            {
                myNTextboxThickness.Top = height + (height - BorderThickness.Top) * i;

                myNTextbox[i] = new TextBox()
                {
                    Text = list.getCompetitor(i).name + "",
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = myNTextboxThickness,
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
                myNTextbox[i].KeyDown += new KeyEventHandler(MyNTextbox_KeyDown);
                grid.Children.Add(myNTextbox[i]);
            }
        }


        private void HLabel_Create(int number, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            Label[] myHLabel = new Label[number];
            Thickness myHLabelThickness = new Thickness() { Left = leftPosition, Top=1};
            int height = fontSize * 2 + 4;

            for (int i = 0; i < myHLabel.Length; i++)
            {
                myHLabelThickness.Left = leftPosition + (fontSize*3 - BorderThickness.Top) * i;
                myHLabel[i] = new Label()
                {
                    Content = Convert.ToString(i + 1),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = myHLabelThickness,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = height,
                    Width = fontSize * 3,
                    FontSize = fontSize,
                    BorderBrush = Brushes.Black,
                    BorderThickness = BorderThickness,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                grid.Children.Add(myHLabel[i]);
            }
        }
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness myBorderThickness = new Thickness() { Left = 1, Right=1, Bottom = 1, Top = 1 };

            Vlabel_Create(gridSize, myBorderThickness,12,20,grid);
            NameTextbox_Create(relist, myBorderThickness, 12, 19 + 36, grid);
            NameLabel_Create(tName, 23 + 12 * 31, 20, 12, myBorderThickness, grid);
            HLabel_Create(gridSize, myBorderThickness, 12, 42 + 12 * 31, grid);
        }
    }
}
