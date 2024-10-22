using BussinessObject.DataAccess;
using DataAccess.DAOs;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Book Create(Book book)
        => BookDAO.SaveBook(book);

        public void Delete(Book book)
       => BookDAO.DeleteBook(book);

        public List<Book> GetAll()
      => BookDAO.GetBooks();

        public Book GetById(int id)
       => BookDAO.FindBookById(id);
        public Book Update(Book book)
      => BookDAO.UpdateBook(book);
    }
}
