using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SQLiteConnection.CreateFile(@"appdata.db");
            SQLiteConnection connection =new SQLiteConnection("Data Source="+@"appdata.db");
            SQLiteCommand command1 =
            new SQLiteCommand("CREATE TABLE Tournirs (Id INTEGER PRIMARY KEY, Tournir TEXT);", connection);
            SQLiteCommand command2 =
            new SQLiteCommand("CREATE TABLE Competitors (Id INTEGER PRIMARY KEY, RatingNum INTEGER, Name TEXT, Exist TEXT, Tournir TEXT);", connection);
            connection.Open();
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
        }
    }
}
