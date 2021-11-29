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
using System.Windows.Shapes;

namespace LoginDesktopApp
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        MainWindow welcome = new MainWindow();

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string name = txtUsername.Text;
            string password = txtPassword.Password;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-DROLOIQS;Initial Catalog=LoginDB;Integrated Security=True");
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblUser where username='" + name + "' or Email='"+ name +"' and password='" + password + "'", sqlCon);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
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
                welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                welcome.Show();
                Close();
            }
            else
            {
                errormessage.Text = "Sorry! Please enter existing username/password.";
            }
            sqlCon.Close();


        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();

        }
    
}
}
