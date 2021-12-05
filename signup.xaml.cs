using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        public signup()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter a Username.";
            }
            else if (!Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
            }
            else if (txtPassword.Password != repPassword.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
            }
            else
            {
                String name = txtUsername.Text;
                String mail = txtemail.Text;
                String passWord = txtPassword.Password;
                //String repPass = repPassword.Password;

                MySqlConnection sqlCon = new MySqlConnection(@"server = localhost; uid = root; pwd = root; database = dhyacams");
                sqlCon.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from admin where UserName='" + name + "'", sqlCon);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    MySqlCommand cm = new MySqlCommand("Insert into admin (UserName,Password,UserEmail) values('" + name + "','" + passWord + "','" + mail + "')", sqlCon);
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

