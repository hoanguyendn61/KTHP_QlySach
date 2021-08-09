using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
namespace DataAccessLayer
{
    public class Book_DAL
    {
        private static Book_DAL _instance = null;
        public static Book_DAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Book_DAL();
                }
                return _instance;
            }
        }
        private Book_DAL()
        {
        }
        QLSach db = new QLSach();
        public List<Book> GetListOfBooks_DAL()
        {
            List<Book> dt = new List<Book>();
            var b = from p in db.Books
                    select p;
            dt = b.ToList();
            return dt;
        }
        public List<Book> GetListOfBooks_DAL(int a_id)
        {
            List<Book> dt = new List<Book>();
            //var b = from p in db.Books
            //        where p.A_ID == a_id
            //        select p;
            var b = db.Books.Select(p => p).Where(p => p.A_ID == a_id);
            dt = b.ToList();
            return dt;
        }
        public Book GetBookByID_DAL(int b_id)
        {
            Book b = db.Books.Find(b_id);
            return b;
        }
        public bool SaveBook_DAL(Book b)
        {
            bool result = false;
            Book _b = db.Books.Where(x => x.B_ID == b.B_ID).Select(x => x).SingleOrDefault();
            if (_b != null)
            {
                // UPDATE
                _b.B_Name = b.B_Name;
                _b.A_ID = b.A_ID;
                _b.B_PublishDate = b.B_PublishDate;
                _b.B_Status = b.B_Status;
            } else
            {
                // ADD
                db.Books.Add(b);
            }
            db.SaveChanges();
            result = true;
            return result;
        }
        public bool DeleteBook_DAL(int b_id)
        {
            bool result = false;
            try
            {
                // REMOVE
                Book _b = db.Books.Where(b => b.B_ID == b_id).Select(b => b).SingleOrDefault();
                db.Books.Remove(_b);
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
