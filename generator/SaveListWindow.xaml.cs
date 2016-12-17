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
using System.Windows.Shapes;

namespace generator
{
    /// <summary>
    /// Логика взаимодействия для SaveListWindow.xaml
    /// </summary>
    public partial class SaveListWindow : Window
    {
        public string ListName { get; set; }

        public SaveListWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Activated(object sender, EventArgs e)
        {

            label.Content = "List \"" + ListName + "\" was successfully saved.";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window_Activated(this,e);
        }
    }
}
