using FirebirdSql.Data.FirebirdClient;
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

namespace NCarRental.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string name = loginName.Text;
            string pass = loginPass.Text;

            if ( string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass) )
            {
                MessageBox.Show("Something is Empty!");
                return;
            }

            using (FbConnection conn = new FbConnection(@"Server=localhost;User=SYSDBA;Password=admin;Database=C:\Users\Norbert\Documents\Visual Studio 2015\Projects\NCarRental\NCarRental\_Resources\DB.FDB"))
            using (FbCommand cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = "select name from users where name=@name and pass=@pass";
                cmd.Parameters.Add("name", name);
                cmd.Parameters.Add("pass", pass);

                var result = cmd.ExecuteScalar();
                Console.WriteLine(result);

                if (result == null)
                {
                    MessageBox.Show("The username or the password is wrong");
                    return;
                }

                MessageBox.Show("Done!");
                loginName.Text = "";
                loginPass.Text = "";
            }


        }

        private void Signin(object sender, RoutedEventArgs e)
        {
            string name = signinName.Text;
            string pass1 = signinPass.Text;
            string pass2 = signinPass2.Text;

            if ( string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(pass2) )
            {
                MessageBox.Show("Something is Empty!");
                return;
            }

            if ( pass1 != pass2 )
            {
                MessageBox.Show("The re-password does not match!");
                return;
            }

            using (FbConnection conn = new FbConnection(@"Server=localhost;User=SYSDBA;Password=admin;Database=C:\Users\Norbert\Documents\Visual Studio 2015\Projects\NCarRental\NCarRental\_Resources\DB.FDB"))
            using (FbCommand cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = "select name from users where name=@name";
                cmd.Parameters.Add("name", name);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    MessageBox.Show("The username is already taken!");
                    return;
                }

                cmd.CommandText = "insert into users(name, pass, balance) values (@name, @pass, @balance)";
                cmd.Parameters.Add("pass", pass1);
                cmd.Parameters.Add("balance", 20000);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Done!");
                signinName.Text = "";
                signinPass.Text = "";
                signinPass2.Text = "";
            }
            
        }
    }
}
