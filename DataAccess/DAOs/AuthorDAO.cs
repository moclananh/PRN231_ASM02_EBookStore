using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class AuthorDAO
    {
        public static List<Author> GetAuthors()
        {
            var list = new List<Author>();
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    list = context.Authors.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Author FindAuthorById(int proId)
        {
            Author p = new Author();
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    p = context.Authors.SingleOrDefault(x => x.AuthorId == proId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static Author SaveAuthor(Author p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    context.Authors.Add(p);
                    context.SaveChanges();  // Save the new author and generate ID (if applicable)
                    return p;  // Return the saved author
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Author UpdateAuthor(Author p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    context.Entry<Author>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();  // Save the updated author
                    return p;  // Return the updated author
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void DeleteAuthor(Author p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    var AuthorRemove = context.Authors.SingleOrDefault(prm => prm.AuthorId == p.AuthorId);
                    context.Remove(AuthorRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
