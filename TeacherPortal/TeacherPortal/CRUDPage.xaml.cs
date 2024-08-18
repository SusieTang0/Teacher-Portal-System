using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
using System.Xml.Linq;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for CRUDPage.xaml
    /// </summary>
    public partial class CRUDPage : Window
    {
        public List<Book> books = new List<Book>();
        public List<Subject> subjects = new List<Subject>();
        public string User { get; set; } 
        public CRUDPage()
        {
            InitializeComponent();
            DataContext = this;
            Reload();        
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
            Reload();
        }

        private void editBookBtn_Click(object sender, RoutedEventArgs e)
        {
            EditBook editBook = new EditBook();
            bool findIt = false;
            for (int i = 0; i < bookListView.Items.Count; i++)
            {
                ListViewItem listViewItem =
                    (ListViewItem)bookListView.ItemContainerGenerator.ContainerFromIndex(i);
                if (listViewItem != null && listViewItem.IsSelected)
                {
                    findIt = true;
                    editBook.ISBN = books[i].ISBN;
                    editBook.BookTitle = books[i].BookTitle;
                    editBook.Price = books[i].Price;
                    editBook.AuthorName = books[i].AuthorName;
                    editBook.DOP = books[i].DOP;
                    editBook.StaffId = books[i].StaffId;
                    break;
                }
            }
            if (findIt)
            {
                editBook.ShowDialog();
                Reload();
            }
            else{
                MessageBox.Show("Please select on book item to edit", "Selected Info");
            }
            
        }

        private void addSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
            Reload();
        }

        private void editSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            EditSubject editSubject = new EditSubject();
            bool findIt = false;
            for (int i = 0; i < subjectListView.Items.Count; i++)
            {
                ListViewItem listViewItem =
                    (ListViewItem)subjectListView.ItemContainerGenerator.ContainerFromIndex(i);
                if (listViewItem != null && listViewItem.IsSelected)
                {
                    findIt = true;
                    editSubject.SubjectCode = subjects[i].SubjectCode;
                    editSubject.SubjectName = subjects[i].SubjectName;
                    editSubject.StartDate = subjects[i].StartDate;
                    editSubject.NumberOfCredit = subjects[i].NumberOfCredit;
                    editSubject.StaffId = subjects[i].StaffId;
                    break;
                }
            }
            if (!findIt)
            {
                editSubject.ShowDialog();
                Reload();
            }
            else
            {
                MessageBox.Show("Please select on subject item to edit", "Selected Info");
            }
        }


        private void Reload()
        {
            LoadBooks();
            LoadSubjects();
        }


        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true"))
                {
                    con.Open();
                    string book_data = "SELECT * FROM [dbo].[Books]";

                    using (SqlCommand cmd_book = new SqlCommand(book_data, con))
                    {
                        using (SqlDataReader book_reader = cmd_book.ExecuteReader())
                        {
                            bookListView.Items.Clear();
                            books.Clear(); 
                            while (book_reader.Read())
                            {
                                string StaffId = book_reader["StaffId"].ToString();
                               
                                if (User != null && StaffId != null && User.Equals(StaffId))
                                {
                                    try
                                    {
                                        string isbn = book_reader["ISBN"].ToString();
                                        string BookTitle = book_reader["BookTitle"].ToString();
                                        string Price = Convert.ToDecimal(book_reader["Price"]).ToString();
                                        string AuthorName = book_reader["AuthorName"].ToString();
                                        string DOP = Convert.ToDateTime(book_reader["DOP"]).ToString("MM/dd/yyyy");
                                        Book newBook = new Book() { ISBN = isbn, BookTitle = BookTitle, Price = Price, AuthorName = AuthorName, DOP = DOP, StaffId = StaffId };
                                        books.Add(newBook);
                                        bookListView.Items.Add(newBook);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred: {ex.Message}");
                                    }
                                }
 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true"))
                {
                    con.Open();
                    string subject_data = "SELECT * FROM [dbo].[Subjects]";

                    using (SqlCommand cmd_subject = new SqlCommand(subject_data, con))
                    {
                        using (SqlDataReader subject_reader = cmd_subject.ExecuteReader())
                        {
                            subjectListView.Items.Clear();
                            subjects.Clear(); // Clear the subjects list before adding new items
                            while (subject_reader.Read())
                            {
                                string StaffId = subject_reader["StaffId"].ToString();
                                if (User != null && StaffId != null && User.Equals(StaffId))
                                {
                                    try
                                    {
                                        string SubjectCode = subject_reader["SubjectCode"].ToString();
                                        string SubjectName = subject_reader["SubjectName"].ToString();
                                        string StartDate = Convert.ToDateTime(subject_reader["StartDate"]).ToString("MM/dd/yyyy");
                                        string NumberOfCredit = Convert.ToInt16(subject_reader["NumberOfCredit"]).ToString();

                                        Subject newSubject = new Subject() { SubjectCode = SubjectCode, SubjectName = SubjectName, StartDate = StartDate, NumberOfCredit = NumberOfCredit};
                                        subjects.Add(newSubject);
                                        subjectListView.Items.Add(newSubject);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred: {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string id = "";
                int index = -1;
                for (int i = 0; i < books.Count; i++)
                {
                    ListViewItem listViewItem = (ListViewItem)bookListView.ItemContainerGenerator.ContainerFromIndex(i);
                    if (listViewItem != null && listViewItem.IsSelected)
                    {
                        id = books[i].ISBN;
                        index = i;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(id) && index != -1)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Do you want to remove Book {id}", "Remove Comfirm",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            DeleteData(id,"ISBN","Books");
                            bookListView.Items.Remove(index);
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Ok , stop removing", "Remove Stop", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Please select one item to remove.");
                }

                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = "";
                int index = -1;
                for (int i = 0; i < subjects.Count; i++)
                {
                    ListViewItem listViewItem = (ListViewItem)subjectListView.ItemContainerGenerator.ContainerFromIndex(i);
                    if (listViewItem != null && listViewItem.IsSelected)
                    {
                        id = subjects[i].SubjectCode;
                        index = i;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(id) && index != -1)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Do you want to remove Subject {id}", "Remove Comfirm",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            DeleteData(id, "SubjectCode", "Subjects");
                            bookListView.Items.Remove(index);
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Ok , stop removing", "Remove Stop", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Please select one item to remove.");
                }

                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteData(string id,string idName, string tableName)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TPS;Integrated Security=true");

            con.Open();
            string delete_data = "DELETE FROM [dbo].["+ tableName + "] WHERE " + idName + "=@"+ idName + "";
            SqlCommand cmd = new SqlCommand(delete_data, con);


            cmd.Parameters.AddWithValue("@"+ idName + "", id);

            int rowsAffected = cmd.ExecuteNonQuery();


            if (rowsAffected > 0)
            {
                if (idName.Equals("ISBN"))
                {
                    MessageBox.Show("The book with ISBN " + id + " was removed successfully!");
                }
                else
                {
                    MessageBox.Show("The subject with code" + id + " was removed successfully!");
                }
               

            }
            else
            {
                MessageBox.Show("ID does not exist");
            }
            con.Close();
        }


        
    }

    public class Book
    {
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string Price { get; set; }
        public string AuthorName { get; set; }
        public string DOP { get; set; }
        public string StaffId { get; set; }
    }

    public class Subject
    {
        public string SubjectCode { get; set; }
        public string SubjectName{ get; set; }
        
        public string StartDate { get; set; }
        public string NumberOfCredit { get; set; }
        public string StaffId { get; set; }

    }
}
