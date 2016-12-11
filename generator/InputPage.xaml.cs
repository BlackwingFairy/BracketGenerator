using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Data.Entity;
using System.Data.SQLite;

namespace generator
{
    /// <summary>
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public Competitor Competitor { get; private set; }
        public string Tournir { get; private set; }
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

        private int TrueSingleElimSize(int InputSize)
        {
            int n = 0;
            while (Math.Pow(2, n) < InputSize)
            {
                n++;
            }
            return n;
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
                                    Competitor comp = new Competitor(i, listTextBox.GetLineText(i), true, tNameTextBox.Text);
                                    newList1.setCompetitor(comp, i);
                                }
                                page1.Relist = newList1;
                                NavigationService.Navigate(page1);
                                break;
                            case 1:
                                
                                page1.GridSize = Convert.ToInt16(sizeTextBox.Text);
                                

                                CompetitorsList newList2 = new CompetitorsList(Convert.ToInt16(sizeTextBox.Text));

                                for (int i = 0; i < Convert.ToInt16(sizeTextBox.Text); i++)
                                {
                                    newList2.setCompetitor(new Competitor(i, "", true, tNameTextBox.Text), i);
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
                                page2.Steps = TrueSingleElimSize(listTextBox.LineCount);
                                page2.GridSize = (int)Math.Pow(2,page2.Steps);
                                
                                CompetitorsList newList1 = new CompetitorsList(page2.GridSize);

                                for (int i = 0; i < page2.GridSize; i++)
                                {
                                    if (i < listTextBox.LineCount)
                                    {
                                        newList1.setCompetitor(new Competitor(i+1, listTextBox.GetLineText(i), true, tNameTextBox.Text), i);
                                    }
                                    else
                                    {
                                        newList1.setCompetitor(new Competitor(i+1, "", false, tNameTextBox.Text), i);
                                    }
                                    
                                }
                                page2.Selist = newList1;
                                NavigationService.Navigate(page2);
                                break;
                            case 1:

                                page2.GridSize =(int)Math.Pow(2,TrueSingleElimSize(Convert.ToInt16(sizeTextBox.Text)));


                                CompetitorsList newList2 = new CompetitorsList(page2.GridSize);

                                for (int i = 0; i < page2.GridSize; i++)
                                {
                                    if (i< Convert.ToInt16(sizeTextBox.Text))
                                    {
                                        newList2.setCompetitor(new Competitor(i+1, "", true, tNameTextBox.Text), i);
                                    }
                                    else
                                    {
                                        newList2.setCompetitor(new Competitor(i+1, "", false, tNameTextBox.Text), i);
                                    }
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
                button.IsEnabled = true;
            }
            catch (FormatException)
            {
                sizeTextBox.Clear();
            }

        }

        private void listTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
        }
    }
}
