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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter a Username.";
            }
            else if (txtPassword.Password != repPassword.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
            }
            else
            {
                String name = txtUsername.Text;
                String passWord = txtPassword.Password;
                String repPass = repPassword.Password;

                SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-DROLOIQS;Initial Catalog=LoginDB;Integrated Security=True");
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("Select * from tblUser where username='" + name + "'", sqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    SqlCommand cm = new SqlCommand("Insert into tblUser (UserName,Password) values('" + name + "','" + passWord + "')", sqlCon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();
                    sqlCon.Close();
                    errormessage.Text = "You have Registered successfully.";
                }
                else
                {
                    errormessage.Text = "User name Already Exists.";
                }

            }

        }

    }
}
