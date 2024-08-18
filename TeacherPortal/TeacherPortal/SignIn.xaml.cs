using System;
using System.Collections.Generic;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count;
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true");

                con.Open();
                string add_data = "SELECT COUNT(*) FROM [dbo].[Teacher] WHERE StaffID=@StaffID and Password=@Password";
                SqlCommand cmd = new SqlCommand(add_data, con);


                cmd.Parameters.AddWithValue("@StaffID", staffIdTxb.Text);
                cmd.Parameters.AddWithValue("@Password", HashPassword(passswordTxb.Password));

                cmd.ExecuteNonQuery();
                count = Convert.ToInt32(cmd.ExecuteScalar());

                

                
                if (count > 0)
                {
                    MessageBox.Show("Successfully Login!");
                    CRUDPage crud = new CRUDPage();
                    crud.User = staffIdTxb.Text;
                    Application.Current.Properties["LoggedInUser"] = staffIdTxb.Text;
                    crud.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password or Username is not correct");
                }
                staffIdTxb.Text = "";
                passswordTxb.Password = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
