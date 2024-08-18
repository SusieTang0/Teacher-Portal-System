using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();

            Random random = new Random();
            int randomId = random.Next(1000, 9999);
            staffIdTxb.Text = randomId.ToString();
        }

        private void RegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true");
                    con.Open();
                    string add_data = "INSERT INTO [dbo].[Teacher] (StaffID,Name, Email,DOB,Cellphone,Password) VALUES (@StaffID,@Name, @Email,@DOB,@Cellphone,@Password)";
                    SqlCommand cmd = new SqlCommand(add_data, con);

                    cmd.Parameters.AddWithValue("@StaffID", staffIdTxb.Text);
                    cmd.Parameters.AddWithValue("@Name", nameTxb.Text);
                    cmd.Parameters.AddWithValue("@Email", emailTxb.Text);
                    cmd.Parameters.AddWithValue("@DOB", dobTxb.Text);
                    cmd.Parameters.AddWithValue("@Cellphone", cellphoneTxb.Text);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(passswordTxb.Password));

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Successfully added a teacher", "Register Check");

                    SignIn signin = new SignIn();

                    this.Close();
                    signin.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
           
        }

        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }



        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";


            // Validate the StaffId value type
            errorMessage += IsValidValue(staffIdTxb.Text, "Staff ID");
            errorMessage += IsValidNumber(staffIdTxb.Text,4, "Staff ID");

            // Validate the Name value type
            errorMessage += IsValidValue(nameTxb.Text, "Name");
            errorMessage += IsName(nameTxb.Text, "Name");

           

            // Validate the Email value type
            errorMessage += IsValidValue(emailTxb.Text, "Email");
            errorMessage += IsEmail(emailTxb.Text);

            // Validate the D.O.B value type
            errorMessage += IsValidValue(dobTxb.Text, "D.O.B");
            errorMessage += IsDateTime(dobTxb.Text, "D.O.B");
            errorMessage += IsValidDate(dobTxb.Text, "D.O.B");


            // Validate the Cellphone value type
            errorMessage += IsValidValue(cellphoneTxb.Text, "Cellphone");
            errorMessage += IsValidNumber(cellphoneTxb.Text,10,"Cellphone");


            // Validate the Password value type
            errorMessage += IsValidValue(passswordTxb.Password, "Password");
            errorMessage += IsValidPassword(passswordTxb.Password, "Password");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }

            return success;
        }

       

        public string IsValidValue(string theString, string name)
        {
            string msg = "";
            if (string.IsNullOrWhiteSpace(theString))
            {
                msg = name + " can not be null or white space.\n";
            }

            return msg;
        }

        public string IsValidNumber(string value,int number,string name)
        {
            string msg = "";
            try
            {
                
                string pattern = $@"^\d{{{number}}}$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(value))
                {
                    msg = name + " should be " + number + " numbers.\n";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return msg;
        }

        public string IsValidPassword(string value, string name)
        {
            string msg = "";
            try
            {
                if (value.Length < 7)
                {
                    msg = name + "'s length should be at least 7.\n";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return msg;
        }

        public string IsName(string value, string name)
        {
            string msg = "";
            try
            {
                string pattern = @"^[a-zA-Z]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(value))
                {
                    msg = "The format of " + name + " is incorrect.\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return msg;
        }


        public string IsEmail(string value)
        {
            string msg = "";
            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(value))
                {
                    msg = "The format of email is incorrect.\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return msg;
        }
        public string IsDateTime(string value, string name)
        {
            string msg = "";
            DateTime dateTime;
            if (!DateTime.TryParse(value, out dateTime))
            {
                msg = name + " should be a datetime value\n";
            }
            return msg;
        }

        public string IsValidDate(string value, string name)
        {
            string msg = "";
            DateTime dateTime;
            if (DateTime.TryParse(value, out dateTime))
            {
                DateTime newBar = DateTime.Now.AddYears(-16);
                if (dateTime.Year > newBar.Year)
                {
                    msg = "The year of " + name + " should be before 2009. \n";
                }
            }
            return msg;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
