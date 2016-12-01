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
        int gridSize;

        public void setGridSize(int value)
        {
            gridSize = value;
        }

        private void Vlabel_Create(int number, Thickness BorderThickness)
        {
            Label[] myVLabel = new Label[number];
            Thickness myVLabelThickness = new Thickness() { Left = 20 };

            for (int i = 0; i < myVLabel.Length; i++)
            {
                myVLabelThickness.Top = 27 + 26 * i;
                myVLabel[i] = new Label()
                {
                    Content = Convert.ToString(i + 1),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = myVLabelThickness,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 27,
                    Width = 50,
                    FontSize = 12,
                    BorderBrush = Brushes.Black,
                    BorderThickness = BorderThickness
                };

                grid.Children.Add(myVLabel[i]);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Label[] myHLabel = new Label[gridSize];
            TextBox[] nameTextBox = new TextBox[gridSize];
            
            Thickness myHLabelThickness = new Thickness() { Left = 20 };
            Thickness myBorderThickness = new Thickness() { Left = 1, Right=1, Bottom = 1, Top = 1 };

            Vlabel_Create(gridSize, myBorderThickness);

        }
    }
}
