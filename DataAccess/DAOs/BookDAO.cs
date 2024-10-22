using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var list = new List<Book>();
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    list = context.Books.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Book FindBookById(int proId)
        {
            Book p = new Book();
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    p = context.Books.SingleOrDefault(x => x.BookId == proId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static Book SaveBook(Book p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    context.Books.Add(p);
                    context.SaveChanges();  // This saves and generates the ID for the new Book (if applicable)
                    return p;  // Return the saved book
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Book UpdateBook(Book p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    context.Entry<Book>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();  // Save the changes
                    return p;  // Return the updated book
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void DeleteBook(Book p)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    var BookRemove = context.Books.SingleOrDefault(prm => prm.BookId == p.BookId);
                    context.Remove(BookRemove);
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
