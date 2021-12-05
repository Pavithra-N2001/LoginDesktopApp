using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace LoginDesktopApp
{
    /// <summary>
    /// Interaction logic for index.xaml
    /// </summary>
    public partial class index : Page
    {
        MySqlConnection sqlCon = new MySqlConnection(@"server = localhost; uid = root; pwd = root; database = dhyacams");
       
        public index()
        {
            InitializeComponent();
            sqlCon.Open();

        }

       

        private void staff_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from staffs", sqlCon);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            datagrid.DataContext = dt;
        }

        private void designation_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from designation", sqlCon);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            datagrid.DataContext = dt;
        }
    }
}
