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
    /// Логика взаимодействия для LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Page
    {
        public LoadPage()
        {
            InitializeComponent();
        }

        private void TournirLabel_Click(object sender, MouseButtonEventArgs e)
        {
            Label Tournir = sender as Label;
            InputPage page = new InputPage();
            string iname = Tournir.Content.ToString();
            CompetitorsList competitors = DataWorker.Load_Competitors(iname);
            foreach (Competitor c in competitors.List)
            {
                page.listTextBox.AppendText(c.name);             
            }
            
            page.sizeComboBox.SelectedIndex = 0;
            page.tNameTextBox.Text = Tournir.Content.ToString();
            page.button.IsEnabled = true;
            NavigationService.Navigate(page);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> tournirs = DataWorker.Get_Tournirs();
            foreach (string t in tournirs)
            {
                Label Tournir = new Label()
                {
                    Content = t,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 20,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                };
                Tournir.MouseDoubleClick += new MouseButtonEventHandler(TournirLabel_Click);
                TournStPanel.Children.Add(Tournir);
            }
        }
    }
}
