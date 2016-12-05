using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

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
                        page1.TName = tNameTextBox.Text;


                        switch (sizeComboBox.SelectedIndex)
                        {
                            case 0:
                                page1.GridSize = listTextBox.LineCount;
                                CompetitorsList newList1 = new CompetitorsList(listTextBox.LineCount);

                                for (int i = 0; i < listTextBox.LineCount; i++)
                                {
                                    newList1.setCompetitor(new Competitor(i, listTextBox.GetLineText(i), true), i);
                                }
                                page1.Relist = newList1;
                                NavigationService.Navigate(page1);
                                break;
                            case 1:
                                
                                page1.GridSize = Convert.ToInt16(sizeTextBox.Text);
                                

                                CompetitorsList newList2 = new CompetitorsList(Convert.ToInt16(sizeTextBox.Text));

                                for (int i = 0; i < Convert.ToInt16(sizeTextBox.Text); i++)
                                {
                                    newList2.setCompetitor(new Competitor(i, "", true), i);
                                }

                                page1.Relist = newList2;


                                NavigationService.Navigate(page1);
                                break;
                            default:
                                errorView();
                                break;
                        }
                        
                        break;
                    case 1:
                        SingleEliminaionPage page2 = new SingleEliminaionPage();
                        switch (sizeComboBox.SelectedIndex)
                        {
                            case 0:
                                page2.GridSize = listTextBox.LineCount;
                                CompetitorsList newList1 = new CompetitorsList(listTextBox.LineCount);

                                for (int i = 0; i < listTextBox.LineCount; i++)
                                {
                                    newList1.setCompetitor(new Competitor(i, listTextBox.GetLineText(i), true), i);
                                }
                                page2.Selist = newList1;
                                NavigationService.Navigate(page2);
                                break;
                            case 1:

                                page2.GridSize = Convert.ToInt16(sizeTextBox.Text);


                                CompetitorsList newList2 = new CompetitorsList(Convert.ToInt16(sizeTextBox.Text));

                                for (int i = 0; i < Convert.ToInt16(sizeTextBox.Text); i++)
                                {
                                    newList2.setCompetitor(new Competitor(i, "", true), i);
                                }

                                page2.Selist = newList2;


                                NavigationService.Navigate(page2);
                                break;
                            default:
                                errorView();
                                break;
                        }
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
            int size = 0;

            try
            {
                size = Convert.ToInt16(sizeTextBox.Text);
            }
            catch (FormatException)
            {
                sizeTextBox.Clear();
            }

        }
    }
}
