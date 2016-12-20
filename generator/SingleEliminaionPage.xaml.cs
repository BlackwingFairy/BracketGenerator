using Microsoft.Win32;
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

        int steps;
        public int Steps
        {
            set { steps = value; }
            get { return steps; }
        }

        private Polyline Fork_Create(double top, double left, double height)
        {
            Point myPoint = new Point(left, top);
            Polyline fork = new Polyline()
            {
                Points = new PointCollection()
                {
                    myPoint, new Point(myPoint.X+20,myPoint.Y), new Point(myPoint.X+20,myPoint.Y+height/2),
                    new Point(myPoint.X+35,myPoint.Y+height/2), new Point(myPoint.X+20,myPoint.Y+height/2),
                    new Point(myPoint.X+20,myPoint.Y+height),new Point(myPoint.X,myPoint.Y+height)
                },
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            return fork;
        }

        private TextBox Numbox_Create(int content, int boxNum)
        {
            return new TextBox()
            {
                Name = "numbox" + boxNum,
                Text = content+"",
                Height = 28,
                Width = 36,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness() { Top = 1, Bottom = 1 },
                IsEnabled = false
            };
        }

        private void NameBox_KeyDown(object sender, KeyEventArgs e)    //РАБОТАЕТ)))
        {
            if (e.Key == Key.Return)
            {
                TextBox tbox = sender as TextBox;

                for (int i = 0; i < selist.getSize(); i++)
                {
                    if (selist.getCompetitor(i).ratingNum+"" == Convert.ToString(tbox.Name.Last()))
                    {
                        Competitor comp = new Competitor(i + 1, tbox.Text+"\n", true, TName);
                        selist.setCompetitor(comp, i);
                        tbox.Background = Brushes.Lavender;
                    }

                }
            }
        }

        private TextBox Namebox_Create(bool exist, string name, int boxNum)
        {
            TextBox NameBox = new TextBox()
            {
                Name = "namebox" + boxNum,
                Text = name,
                Height = 28,
                Width = 36 * 5,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness() { Top = 1, Bottom = 1 },
                IsEnabled = exist,
                Background = exist?Brushes.White:Brushes.LightGray                
            };
            NameBox.KeyDown += new KeyEventHandler(NameBox_KeyDown);
            return NameBox;
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
            NewPanel.Children.Add(Numbox_Create(duel.comp1.ratingNum, duel.duelNum+1));
            NewPanel.Children.Add(Namebox_Create(duel.comp1.exist, duel.comp1.name, duel.comp1.ratingNum));
            NewPanel.Children.Add(Numbox_Create(duel.comp2.ratingNum, duel.duelNum + 2));
            NewPanel.Children.Add(Namebox_Create(duel.comp2.exist, duel.comp2.name, duel.comp2.ratingNum));
            return NewPanel;
        }

        private WrapPanel AlonePanel_Create(double top, double left, int num, string Name)
        {
            WrapPanel NewPanel = new WrapPanel()
            {
                //Name = "WrapPanel" + num,
                Height = 30,
                Width = 36 * 6,
                Margin = new Thickness() { Top = top, Left = left },
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            TextBox numbox = Numbox_Create(0, num);
            numbox.Text = "";
            numbox.IsEnabled = true;
            NewPanel.Children.Add(numbox);
            NewPanel.Children.Add(Namebox_Create(true, "",num));
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
                grid.Children.Add(Fork_Create(step * i + 15, 36 * 6, 30));
            }

            
            int top = 15;
            for (int s = steps; s > 0; s--)
            {
                int left = (36 * 6 + 40) * (steps - s + 1);
                int k = (int)Math.Pow(2, s - 1);

                for (int n = 0; n < k; n++)
                {
                    grid.Children.Add(AlonePanel_Create(top + 70 * (int)Math.Pow(2, steps - s) * n, left, n, ""));                   
                }
                
                for (int n = 0;n<k/2;n++)
                {
                    grid.Children.Add(Fork_Create((top + 15) + 70 * (int)Math.Pow(2, steps - s+1)*n, left + 36 * 6, 70*(int)Math.Pow(2,steps-s)));
                }

                top += 35 *(int)Math.Pow(2, steps - s);
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> TList = DataWorker.Get_Tournirs();
            bool flag = true;
            foreach (string T in TList)
            {
                if (T == selist.getCompetitor(0).tournir)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                DataWorker.Add_Tournir(selist.getCompetitor(0).tournir);
                DataWorker.Add_Competitors(selist);
                string message = "List \"" + selist.getCompetitor(0).tournir + "\" was successfully created.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show(message, "", button, MessageBoxImage.Information);
            }
            else
            {
                //DataWorker.Add_Tournir(relist.getCompetitor(0).tournir);
                //DataWorker.Add_Competitors(relist);
                string message = "Choose another tournir name. This name (\"" + selist.getCompetitor(0).tournir + "\") exist in database.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show(message, "", button, MessageBoxImage.Information);
            }
        }

        public static PngBitmapEncoder CaptureScreen(Grid grid)
        {
            Size s = grid.RenderSize;


            RenderTargetBitmap bmp = new RenderTargetBitmap((int)s.Width + 40, (int)s.Height + 80, 0, 0, PixelFormats.Pbgra32);
            bmp.Render(grid);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));


            return encoder;
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
