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
    public partial class Form1 : Form
    {
        List<BookItem> availableBooks = new List<BookItem>();
        List<BookItem> issuedBooks = new List<BookItem>();
        public Form1()
        {
            InitializeComponent();
  

            availableBooks.Add(new BookItem("Война и мир", "Л.Н. Толстой", 3));
            availableBooks.Add(new BookItem("Преступление и наказание", "Ф.М. Достоевский", 2));
            availableBooks.Add(new BookItem("Мастер и Маргарита", "М.А. Булгаков", 1));
            availableBooks.Add(new BookItem("1984", "Джордж Оруэлл", 5));
            issuedBooks.Add(new BookItem("Евгений Онегин", "А.С. Пушкин", "Иванов И.", DateTime.Now.AddDays(1)));
            issuedBooks.Add(new BookItem("Мёртвые души", "Н.В. Гоголь", "Петрова А.", DateTime.Now.AddDays(10)));

            UpdateLists();
        }

        private void UpdateLists()
        {
            listBoxAvailable.Items.Clear();
            foreach (BookItem book in availableBooks)
            {
                listBoxAvailable.Items.Add(book.GetInfo());
            }

            listBoxIssued.Items.Clear();
            foreach (BookItem book in issuedBooks)
            {
                listBoxIssued.Items.Add(book.GetInfo());
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            int index = listBoxAvailable.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Сначала выберите книгу из списка доступных!");
                return;
            }

            BookItem selectedBook = availableBooks[index];

            if (selectedBook.Count <= 0)
            {
                MessageBox.Show("Этой книги сейчас нет в наличии!");
                return;
            }
            OrderForm orderForm = new OrderForm(selectedBook);
            if (orderForm.ShowDialog() == DialogResult.OK)
            { 
                selectedBook.Count--;
                issuedBooks.Add(orderForm.NewIssuedBook);
                UpdateLists();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            listBoxIssued.Items.Clear();

            foreach (BookItem book in issuedBooks)
            {
                double daysLeft = (book.ReturnDate.Date - DateTime.Now.Date).TotalDays;
                if (daysLeft <= 2)
                {
                    listBoxIssued.Items.Add(book.GetInfo());
                }
            }

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            UpdateLists();
        }

    }
}
