using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryOrders
{
    public partial class OrderForm : Form
    {
        private BookItem currentBook;

        public BookItem NewIssuedBook { get; private set; }

        public OrderForm(BookItem book)
        {
            InitializeComponent();
            currentBook = book;
            ShowBookData();
        }

        private void ShowBookData()
        {
            lblBookTitle.Text = $"Книга: {currentBook.Title} ({currentBook.Author})";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReaderName.Text))
            {
                MessageBox.Show("Введите имя читателя!");
                return;
            }

            NewIssuedBook = new BookItem(
                currentBook.Title,
                currentBook.Author,
                txtReaderName.Text,
                dtpReturnDate.Value
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
    
