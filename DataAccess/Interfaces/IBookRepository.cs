using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBookRepository
    {
        Book Create(Book book);
        void Delete(Book book);
        Book Update(Book book);
        List<Book> GetAll();
        Book GetById(int id);
    }
}
