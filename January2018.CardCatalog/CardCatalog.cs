using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace January2018.CardCatalog
{
    public class CardCatalog
    {
        private string _filename;

        public CardCatalog(string fileName)
        {
            _filename = fileName;
            if (System.IO.File.Exists(_filename))
            {
                using (System.IO.FileStream stream = System.IO.File.OpenRead(_filename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                    books = (List<Book>)serializer.Deserialize(stream);
                }
            }
            else
            {
                books = new List<Book>();
            }
        }

        private List<Book> books = null; //This is the private member variable that contains all of the books

            
        public void ListBooks()
        {
            foreach(var book in books)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", book.Title, book.Author, book.Genre, book.Year);
            }
        }
        public void AddBook(string title, string author, string genre, int year)
        {
            books.Add(new Book
            {
                Author = author,
                Title = title,
                Genre = genre,
                Year = year
            });
        }
        public void Save()
        {
            using (System.IO.FileStream stream = System.IO.File.OpenWrite(_filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);
            }
        }
    }
}
