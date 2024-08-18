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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        
        public AddBook()
        {
            InitializeComponent();
            
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true");
                    con.Open();
                    string add_data = "INSERT INTO [dbo].[Books] (ISBN,BookTitle, Price,AuthorName,DOP,StaffId) VALUES (@ISBN,@BookTitle, @Price,@AuthorName,@DOP,@StaffId)";
                    SqlCommand cmd = new SqlCommand(add_data, con);
                    string user = Application.Current.Properties["LoggedInUser"] as string;

                    cmd.Parameters.AddWithValue("@ISBN", isbnTxb.Text);
                    cmd.Parameters.AddWithValue("@BookTitle", titleTxb.Text);
                    cmd.Parameters.AddWithValue("@Price", priceTxb.Text);
                    cmd.Parameters.AddWithValue("@AuthorName", authorTxb.Text);
                    cmd.Parameters.AddWithValue("@DOP", dopTxb.Text);
                    cmd.Parameters.AddWithValue("@StaffId", user);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Successfully added a book", "Add Book Check");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This ISBN is already used, please try again.");
                }
            }
            
           
        }
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";


            // Validate the ISBN value type
            errorMessage += IsValidValue(isbnTxb.Text, "ISBN");
            errorMessage += IsValidNumber(isbnTxb.Text, 13, "ISBN");

            // Validate the Title value type 
            errorMessage += IsValidValue(titleTxb.Text, "BookTitle");
            errorMessage += IsName(titleTxb.Text, "BookTitle");

            // Validate the Price of Credit value type
            errorMessage += IsValidValue(priceTxb.Text, "Price");
            errorMessage += IsValidPrice(priceTxb.Text, "Price");

            // Validate the AuthorName value type 
            errorMessage += IsValidValue(authorTxb.Text, "Author Name");
            errorMessage += IsName(authorTxb.Text, "Author Name");


            // Validate the DOP value type
            errorMessage += IsValidValue(dopTxb.Text, "Start Date");
            errorMessage += IsDateTime(dopTxb.Text, "Start Date");


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

        public string IsValidPrice(string value,string name)
        {
            string msg = "";
            try
            {
                int price;
                if (int.TryParse(value,out price))
                {
                    if(price > 300)
                    {
                        msg = name + " should be no more than 300.\n";
                    }else if(price < 0)
                    {
                        msg = name + " should be no less than 0.\n";
                    }

                }
                else
                {
                    msg = name + " should be between 0 to 300.\n";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return msg;
        }

        public string IsValidNumber(string value, int number, string name)
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

        public string IsName(string value, string name)
        {
            string msg = "";
            try
            {
                string pattern = @"^[\s\S]+$";
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

        public string IsDateTime(string value, string name)
        {
            string msg = "";
            DateTime dateTime;
            if (DateTime.TryParse(value, out dateTime))
            {
                if (dateTime < new DateTime(1, 1, 1) || dateTime > new DateTime(9999, 12, 31))
                {

                    msg = name + " should be between 01/01/0001 to 12/31/9999";
                }
            }
            else
            {
                msg = name + " should be a datetime value with format \"MM/DD/YYYY\"";
            }
            return msg;
        }

      
    }

}
