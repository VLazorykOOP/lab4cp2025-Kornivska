using System;
using System.Windows.Forms;
using BookStoreApp.Models;

namespace BookStoreApp
{
    public partial class BookForm : Form
    {
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Book Book { get; private set; }

        // Контролі (ініціалізовані як null!, бо ініціалізуються в InitializeComponent)
        private TextBox textBoxAuthor = null!;
        private TextBox textBoxTitle = null!;
        private TextBox textBoxPublisher = null!;
        private TextBox textBoxPageCount = null!;
        private TextBox textBoxGenre = null!;
        private TextBox textBoxPrice = null!;
        private Button buttonSave = null!;

        // Конструктор для додавання нової книги
        public BookForm()
        {
            InitializeComponent();
        }

        // Конструктор для редагування існуючої книги
        public BookForm(Book book) : this()
        {
            Book = book;

            textBoxAuthor.Text = book.Author;
            textBoxTitle.Text = book.Title;
            textBoxPublisher.Text = book.Publisher;
            textBoxPageCount.Text = book.PageCount.ToString();
            textBoxGenre.Text = book.Genre;
            textBoxPrice.Text = book.Price.ToString();
        }

        private void InitializeComponent()
        {
            this.textBoxAuthor = new TextBox() { Left = 120, Top = 10, Width = 200 };
            this.textBoxTitle = new TextBox() { Left = 120, Top = 40, Width = 200 };
            this.textBoxPublisher = new TextBox() { Left = 120, Top = 70, Width = 200 };
            this.textBoxPageCount = new TextBox() { Left = 120, Top = 100, Width = 200 };
            this.textBoxGenre = new TextBox() { Left = 120, Top = 130, Width = 200 };
            this.textBoxPrice = new TextBox() { Left = 120, Top = 160, Width = 200 };
            this.buttonSave = new Button() { Text = "Зберегти", Left = 120, Top = 200, Width = 100 };

            // Підписи
            var labelAuthor = new Label() { Text = "Автор:", Left = 20, Top = 13, Width = 100 };
            var labelTitle = new Label() { Text = "Назва:", Left = 20, Top = 43, Width = 100 };
            var labelPublisher = new Label() { Text = "Видавництво:", Left = 20, Top = 73, Width = 100 };
            var labelPageCount = new Label() { Text = "Сторінок:", Left = 20, Top = 103, Width = 100 };
            var labelGenre = new Label() { Text = "Жанр:", Left = 20, Top = 133, Width = 100 };
            var labelPrice = new Label() { Text = "Ціна:", Left = 20, Top = 163, Width = 100 };

            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(labelAuthor);
            this.Controls.Add(textBoxAuthor);
            this.Controls.Add(labelTitle);
            this.Controls.Add(textBoxTitle);
            this.Controls.Add(labelPublisher);
            this.Controls.Add(textBoxPublisher);
            this.Controls.Add(labelPageCount);
            this.Controls.Add(textBoxPageCount);
            this.Controls.Add(labelGenre);
            this.Controls.Add(textBoxGenre);
            this.Controls.Add(labelPrice);
            this.Controls.Add(textBoxPrice);
            this.Controls.Add(buttonSave);

            this.Text = "Додати книгу";

            this.buttonSave.Click += ButtonSave_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Простенька валідація
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text) ||
                string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxPublisher.Text) ||
                !int.TryParse(textBoxPageCount.Text, out int pageCount) ||
                string.IsNullOrWhiteSpace(textBoxGenre.Text) ||
                !decimal.TryParse(textBoxPrice.Text, out decimal price))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля коректно.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Book == null)
            {
                Book = new Book();
            }

            // Заповнюємо/оновлюємо дані книги
            Book.Author = textBoxAuthor.Text.Trim();
            Book.Title = textBoxTitle.Text.Trim();
            Book.Publisher = textBoxPublisher.Text.Trim();
            Book.PageCount = pageCount;
            Book.Genre = textBoxGenre.Text.Trim();
            Book.Price = price;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
