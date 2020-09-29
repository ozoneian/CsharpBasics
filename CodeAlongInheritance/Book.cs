using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAlongInheritance
{
    public class Book
    {
        public int Pages;
        public string Author;
        public int Price;

        public Book(int pages, string author, int price)
        {
            Pages = pages;
            Author = author;
            Price = price * 2;
        }

    }
    public class Fact : Book
    {
        public string Subject;
        public Fact(int pages, string author, int price, string subject) : base(pages, author, price)
        {
            Subject = subject.ToUpper();
        }
    }
}
