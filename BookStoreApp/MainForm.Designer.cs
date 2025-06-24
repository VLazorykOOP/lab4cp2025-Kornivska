namespace BookStoreApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обов’язкова змінна конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Button buttonEditBook;
        private System.Windows.Forms.Button buttonDeleteBook;

        /// <summary>
        /// Звільнення ресурсів
        /// </summary>
        /// <param name="disposing">істинно, якщо слід звільнити керовані ресурси</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, створений конструктором форм Windows

        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.buttonEditBook = new System.Windows.Forms.Button();
            this.buttonDeleteBook = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewBooks.TabIndex = 0;

            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(12, 380);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(120, 30);
            this.buttonAddBook.TabIndex = 1;
            this.buttonAddBook.Text = "Додати книгу";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);

            // 
            // buttonEditBook
            // 
            this.buttonEditBook.Location = new System.Drawing.Point(150, 380);
            this.buttonEditBook.Name = "buttonEditBook";
            this.buttonEditBook.Size = new System.Drawing.Size(120, 30);
            this.buttonEditBook.TabIndex = 2;
            this.buttonEditBook.Text = "Редагувати книгу";
            this.buttonEditBook.UseVisualStyleBackColor = true;
            this.buttonEditBook.Click += new System.EventHandler(this.buttonEditBook_Click);

            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.Location = new System.Drawing.Point(290, 380);
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(120, 30);
            this.buttonDeleteBook.TabIndex = 3;
            this.buttonDeleteBook.Text = "Видалити книгу";
            this.buttonDeleteBook.UseVisualStyleBackColor = true;
            this.buttonDeleteBook.Click += new System.EventHandler(this.buttonDeleteBook_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.buttonDeleteBook);
            this.Controls.Add(this.buttonEditBook);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.dataGridViewBooks);
            this.Name = "MainForm";
            this.Text = "Облік книг";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
