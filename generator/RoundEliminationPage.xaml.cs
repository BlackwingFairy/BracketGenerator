using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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


        private void VGrid_Create(int number, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            TextBox[,] TboxGroup = new TextBox[number, number];
            int height = fontSize * 2 + 4;
            Thickness myThickness = new Thickness() { Left = leftPosition, Top = height - 1 };
            for (int i=0;i<number;i++)
            {
                myThickness.Left = leftPosition;
                for (int j = 0; j < number; j++)
                {
                    TboxGroup[i, j] = new TextBox()
                    {
                        Text = "",
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = myThickness,
                        Height = height,
                        Width = fontSize * 3,
                        FontSize = fontSize,
                        BorderBrush = Brushes.Black,
                        BorderThickness = BorderThickness,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Name = "TboxGroup" + i + j
                    };

                    if (i == j)
                    {
                        TboxGroup[i, j].IsEnabled = false;
                        TboxGroup[i, j].Background = Brushes.Black;
                    }
                    grid.Children.Add(TboxGroup[i, j]);
                    myThickness.Left += fontSize * 3 - 1;
                }
                myThickness.Top += height - 1;
            }
        }

        private void Vlabel_Create(int number, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            Label[] myVLabel = new Label[number];
            Thickness myVLabelThickness = new Thickness() { Left = leftPosition };
            int height = fontSize * 2 + 4;
            myVLabelThickness.Top = height-BorderThickness.Top;

            for (int i = 0; i < myVLabel.Length; i++)
            {
                myVLabelThickness.Top = (height - BorderThickness.Top) * (i + 1);
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
            Thickness myNLabelThickness = new Thickness() { Left = leftPosition };
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


        private void MyNTextbox_KeyDown(object sender, KeyEventArgs e)    //РАБОТАЕТ)))
        {
            if (e.Key == Key.Return)
            {
                TextBox tbox = sender as TextBox;
                
                for (int i = 0; i < relist.getSize(); i++)
                {
                    if (i + "" == Convert.ToString(tbox.Name.Last()))
                    {
                        Competitor comp = new Competitor(i + 1, tbox.Text, true, TName);
                        relist.setCompetitor(comp, i);
                        tbox.Background = Brushes.Lavender;
                    }
                    
                }
            }
        }


        private void NameTextbox_Create(CompetitorsList list, Thickness BorderThickness, int fontSize, int leftPosition, Grid grid)
        {
            TextBox[] myNTextbox = new TextBox[list.getSize()];
            Thickness myNTextboxThickness = new Thickness() { Left = leftPosition };
            int height = fontSize * 2 + 4;
            myNTextboxThickness.Top = height-BorderThickness.Top;

            for (int i = 0; i < list.getSize(); i++)
            {
                myNTextboxThickness.Top =(height - BorderThickness.Top) * (i+1);

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
            Thickness myHLabelThickness = new Thickness() { Left = leftPosition};
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

        public static PngBitmapEncoder CaptureScreen(Grid grid)
        {
            //UserControl control = new UserControl();
            //control.Measure(new Size(300, 300));
            //control.Arrange(new Rect(new Size(300, 300)));
            Size s = grid.RenderSize;
           

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)s.Width+40, (int)s.Height+80, 0, 0, PixelFormats.Pbgra32);
            bmp.Render(grid);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            //System.Drawing.Bitmap BMP = new System.Drawing.Bitmap(System.Windows.Forms.Screen.PrimaryScreen.,
            //                       System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height,
            //                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //System.Drawing.Graphics GFX = System.Drawing.Graphics.FromImage(BMP);
            //GFX.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X,
            //                    System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y,
            //                    0, 0,
            //                    System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size,
            //                    System.Drawing.CopyPixelOperation.SourceCopy);

            return encoder;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness myBorderThickness = new Thickness() { Left = 1, Right=1, Bottom = 1, Top = 1 };

            Vlabel_Create(gridSize, myBorderThickness,12,0,grid);
            NameTextbox_Create(relist, myBorderThickness, 12, 35, grid);
            NameLabel_Create(tName, 23 + 12 * 31, 0, 12, myBorderThickness, grid);
            HLabel_Create(gridSize, myBorderThickness, 12, 22 + 12 * 31, grid);
            VGrid_Create(gridSize, myBorderThickness, 12, 22 + 12 * 31, grid);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataWorker.Add_Tournir(relist.getCompetitor(0).tournir);
            DataWorker.Add_Competitors(relist);
            string message = "List \"" + relist.getCompetitor(0).tournir + "\" was successfully created.";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(message, "", button, MessageBoxImage.Information);
        }

        private void ScreenButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.Visibility = Visibility.Hidden;
            ScreenButton.Visibility = Visibility.Hidden;

            PngBitmapEncoder screen = CaptureScreen(grid);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        screen.Save(fs);
                        break;

                    case 2:
                        screen.Save(fs);
                        break;

                    case 3:
                        screen.Save(fs);
                        break;
                }

                fs.Close();
            }
            SaveButton.Visibility = Visibility.Visible;
            ScreenButton.Visibility = Visibility.Visible;
        }
    }
}
