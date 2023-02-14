using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW6_Databases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database1.accdb");
        }

        private string ReadFromDB(string field, string table)
        {
            string query = "select " + field + " from " + table;
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            cn.Close();
            return data;
        }

        private void SeeAssetsButton_Click(object sender, RoutedEventArgs e)
        {
            Output_Left.Text = ReadFromDB("EmployeeID", "Assets");
            Output_Midd.Text = ReadFromDB("AssetID", "Assets");
            Output_Right.Text = ReadFromDB("Description", "Assets");
        }

        private void SeeEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            Output_Left.Text = ReadFromDB("EmployeeID", "Employees");
            Output_Midd.Text = ReadFromDB("LastName", "Employees");
            Output_Right.Text = ReadFromDB("FirstName", "Employees");
        }
    }
}
