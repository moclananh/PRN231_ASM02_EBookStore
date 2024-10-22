using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAuthorRepository
    {
        Author Create(Author author);
        void Delete(Author author);
        Author Update(Author author);
        List<Author> GetAll();
        Author GetById(int id);

    }
}
