using System;
using System.Windows.Forms;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp
{
    public partial class MainForm : Form
    {
        private readonly BookRepository _repository = new();

        public MainForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _repository.GetAllBooks();
            dataGridViewBooks.DataSource = books;
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            var form = new BookForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repository.AddBook(form.Book);
                LoadBooks();
            }
        }

        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для редагування.");
                return;
            }

            var selectedRow = dataGridViewBooks.SelectedRows[0];
            var book = (Book)selectedRow.DataBoundItem;

            var form = new BookForm(book); // Конструктор BookForm для редагування
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repository.UpdateBook(form.Book);
                LoadBooks();
            }
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для видалення.");
                return;
            }

            var selectedRow = dataGridViewBooks.SelectedRows[0];
            var book = (Book)selectedRow.DataBoundItem;

            var confirmResult = MessageBox.Show(
                $"Ви дійсно хочете видалити книгу '{book.Title}'?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                _repository.DeleteBook(book.Id);
                LoadBooks();
            }
        }
    }
}
