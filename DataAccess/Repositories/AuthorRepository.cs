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
    public class AuthorRepository : IAuthorRepository
    {
        public Author Create(Author author)
       => AuthorDAO.SaveAuthor(author);

        public void Delete(Author author)
       => AuthorDAO.DeleteAuthor(author);

        public List<Author> GetAll()
       => AuthorDAO.GetAuthors();

        public Author GetById(int id)
       => AuthorDAO.FindAuthorById(id);

        public Author Update(Author author)
       => AuthorDAO.UpdateAuthor(author);
    }
}
