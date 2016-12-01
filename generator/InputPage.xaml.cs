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
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public InputPage()
        {
            InitializeComponent();
        }

        private void errorView()
        {
            errorLabel.Content = "! Check your input data";
            errorLabel.Foreground = Brushes.Red;
            errorLabel.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (tNameTextBox.Text.Length != 0)
            {
                switch (tTypeComboBox.SelectedIndex)
                {
                    case 0:
                        RoundEliminationPage page1 = new RoundEliminationPage();
                        page1.setGridSize(Convert.ToInt16(sizeTextBox.Text));
                        NavigationService.Navigate(page1);
                        break;
                    case 1:
                        SingleEliminaionPage page2 = new SingleEliminaionPage();
                        NavigationService.Navigate(page2);
                        break;
                    default:
                        errorView();
                        break;
                }
            }
            else
            {
                errorView();
            }
        }

        private void sizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (sizeComboBox.SelectedIndex)
            {
                case 0:
                    listLabel.Visibility = Visibility.Visible;
                    listTextBox.Visibility = Visibility.Visible;
                    sizeStackPanel.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    listLabel.Visibility = Visibility.Collapsed;
                    listTextBox.Visibility = Visibility.Collapsed;
                    sizeStackPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    errorView();
                    break;
            }
        }

        private void sizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int s = Convert.ToInt16(sizeTextBox.Text);
            }
            catch (System.FormatException)
            {
                sizeTextBox.Clear();
            }
        }
    }
}
