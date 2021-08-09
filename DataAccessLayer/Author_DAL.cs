using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
namespace DataAccessLayer
{
    public class Author_DAL
    {
        private static Author_DAL _instance = null;
        public static Author_DAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Author_DAL();
                }
                return _instance;
            }
        }
        private Author_DAL()
        {
        }
        QLSach db = new QLSach();
        public List<Author> GetListOfAuthors_DAL()
        {
            List<Author> dt = new List<Author>();
            var b = db.Authors.Select(s => s);
            dt = b.ToList();
            return dt;
        }
    }
}
