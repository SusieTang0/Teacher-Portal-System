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
    /// Interaction logic for EditSubject.xaml
    /// </summary>
   
    public partial class EditSubject : Window
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }

        public string StartDate { get; set; }
        public string NumberOfCredit { get; set; }
        public string StaffId { get; set; }

        public EditSubject()
        {
            InitializeComponent();
            codeTxb.IsReadOnly = true;
            DataContext = this;
        }

        private void editSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true");
                    con.Open();
                    string update_data = "UPDATE [dbo].[Books] SET SubjectCode = @SubjectCode, SubjectName = @SubjectName, StartDate = @StartDate,NumberOfCredit = @NumberOfCredit, StaffId = @StaffId  WHERE SubjectCode = @SubjectCode";
                    SqlCommand cmd = new SqlCommand(update_data, con);
                    

                    cmd.Parameters.AddWithValue("@SubjectCode", codeTxb.Text);
                    cmd.Parameters.AddWithValue("@SubjectName", nameTxb.Text);
                    cmd.Parameters.AddWithValue("@StartDate", startDateTxb.Text);
                    cmd.Parameters.AddWithValue("@NumberOfCredit", numberTxb.Text);
                    cmd.Parameters.AddWithValue("@StaffId", StaffId);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Successfully edited a subject", "Edit Subject Check");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            // Validate the SubjectCode value type
            errorMessage += IsValidValue(codeTxb.Text, "Subject Code");
            errorMessage += IsValidNumber(codeTxb.Text, 6, "Subject Code");

            // Validate the SubjectName value type 
            errorMessage += IsValidValue(nameTxb.Text, "Subject Name");
            errorMessage += IsName(nameTxb.Text, "Subject Namee");

            // Validate the StartDate value type
            errorMessage += IsValidValue(startDateTxb.Text, "Start Date");
            errorMessage += IsDateTime(startDateTxb.Text, "Start Date");
            errorMessage += IsValidDate(startDateTxb.Text, "Start Date");


            // Validate the Number of Credit value type
            errorMessage += IsValidValue(numberTxb.Text, "NumberOfCredit");
            errorMessage += IsValidCredit(numberTxb.Text, "NumberOfCredit");

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

        public string IsValidCredit(string value, string name)
        {
            string msg = "";
            try
            {

                int credit;
                if (int.TryParse(value, out credit))
                {
                    if (credit < 0 && credit > 4)
                    {
                        msg = name + " should be between 0 - 4 .\n";
                    }

                }
                else
                {
                    msg = name + " should be positive integer between 0 - 4.\n";
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
                string pattern =   @"^[\s\S]+$";
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
                DateTime newBar = DateTime.Now;
                if (dateTime < newBar)
                {
                    msg = name + " should be after today. \n";
                }
            }
            else
            {
                msg = name + " should be a datetime value with format \"MM/DD/YYYY\"";
            }
            return msg;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

}
