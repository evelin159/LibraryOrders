using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOrders
{
    public class BookItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
        public string ReaderName { get; set; }
        public DateTime ReturnDate { get; set; }


        public BookItem(string title, string author, int count)
        {
            Title = title;
            Author = author;
            Count = count;
        }


        public BookItem(string title, string author, string readerName, DateTime returnDate)
        {
            Title = title;
            Author = author;
            ReaderName = readerName;
            ReturnDate = returnDate;
        }

        public string GetInfo()
        {
            if (string.IsNullOrEmpty(ReaderName))
            {
                return $"{Title} ({Author}) — в наличии: {Count} шт.";
            }
            else
            {
                return $"{Title} — читатель: {ReaderName}, вернуть до: {ReturnDate.ToShortDateString()}";
            }
        }
    }
}
