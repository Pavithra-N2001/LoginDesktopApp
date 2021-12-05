using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }
        MainWindow welcome = new MainWindow();
        

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string name = txtUsername.Text;
            string password = txtPassword.Password;

            MySqlConnection sqlCon = new MySqlConnection(@"server = localhost; uid = root; pwd = root; database = dhyacams");
            sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from admin where UserName='" + name + "' or UserEmail='" + name + "' and Password='" + password + "'", sqlCon);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Please enter username.";
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                string username = dataSet.Tables[0].Rows[0]["username"].ToString() + " ";
                index n = new index();
                n.TextBlockName.Text = username;//Sending value from one form to another form.  
                this.NavigationService.Navigate(n);
            }
            else
            {
                errormessage.Text = "Sorry! Please enter existing username/password.";
            }
            sqlCon.Close();


        }
    }
}
