using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoryAssignmentExercise1
{
    public class BooksRepository
    {
        private List<Book> books;

        private int nextID;

        public BooksRepository()
        {
            books = new List<Book>();

            Book b1 = new Book(1, "A Classic", 125);
            Book b2 = new Book(2, "B Sequel", 110);
            Book b3 = new Book(3, "A Prequel", 140);
            Book b4 = new Book(4, "A Reboot", 105);
            Book b5 = new Book(5, "A Last Hurrah", 160);

            books.Add(b1);
            books.Add(b2);
            books.Add(b3);
            books.Add(b4);
            books.Add(b5);

            nextID = 6;
        }

        public List<Book> Get(string? filter = null, string? sort = null)
        {
            List<Book> copy = new List<Book>(books);

            if (filter != null)
            {
                copy = copy.Where(book => book.Title != null && book.Title.Contains(filter)).ToList();
            }

            if (sort != null)
            {
                copy = sort.ToLower() switch
                {
                    "title" => copy.OrderBy(book => book.Title).ToList(),
                    "titleasc" => copy.OrderBy(book => book.Title).ToList(),
                    "titledesc" => copy.OrderByDescending(book => book.Title).ToList(),
                    "price" => copy.OrderBy(book => book.Price).ToList(),
                    "priceasc" => copy.OrderBy(book => book.Price).ToList(),
                    "pricedesc" => copy.OrderByDescending(book => book.Price).ToList(),
                    _ => throw new ArgumentException("Invalid sorting method.")
                };
            }

            return copy;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public Book Add(Book book)
        {
            book.ValidateTitle();
            book.ValidatePrice();

            Book newBook = new Book(nextID, book.Title, book.Price);

            books.Add(newBook);
            nextID++;

            return newBook;
        }

        public Book? Delete(int id)
        {
            Book? tbd = GetById(id);

            if (tbd != null)
            {
                books.Remove(tbd);
            }

            return tbd;
        }

        public Book? Update(int id, Book values)
        {
            Book? tbu = GetById(id);

            if (tbu != null)
            {
                foreach (Book b in books)
                {
                    if (b.Id == id)
                    {
                        b.Title = values.Title;
                        b.Price = values.Price;
                        return b;
                    }
                }
            }
            return tbu;
        }

    }
}
