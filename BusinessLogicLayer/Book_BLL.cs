using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;
namespace BusinessLayerLogic
{
    public class Book_BLL
    {
        public delegate bool MyCompare(Book b1, Book b2);
        private static Book_BLL _instance = null;
        public static Book_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Book_BLL();
                }
                return _instance;
            }
        }
        private Book_BLL()
        {
        }
        public List<Book> GetListOfBooks_BLL()
        {
            return Book_DAL.Instance.GetListOfBooks_DAL();
        }
        public List<Book> GetListOfBooks_BLL(int a_id)
        {
            return Book_DAL.Instance.GetListOfBooks_DAL(a_id);
        }
        public bool SaveBook_BLL(Book b)
        {
            return Book_DAL.Instance.SaveBook_DAL(b);
        }
        public bool DeleteBook_BLL(int id)
        {
            return Book_DAL.Instance.DeleteBook_DAL(id);
        }
        public Book GetBookByID_BLL(int b_id)
        {
            return Book_DAL.Instance.GetBookByID_DAL(b_id);
        }
        public List<Book> SearchForBook_BLL(List<Book> blist, string str)
        {
            // Search theo tất cả các thuộc tính hiển thị trên DataGridView và Search theo dữ liệu của DataGridView hiện tại
            var type = blist.GetType().GetGenericArguments()[0];
            var properties = type.GetProperties();
            var result = blist.Where(x => properties
                        .Any(p =>
                        {
                            var value = p.GetValue(x);
                            return value != null && value.ToString().Contains(str);
                        })).ToList();
            return result;
        }
        public List<Book> SortBookList_BLL(List<Book> blist, MyCompare cmp)
        {
            for (int i = 0; i < blist.Count - 1; ++i)
            {
                for (int j = i + 1; j < blist.Count; ++j)
                {
                    if (cmp(blist[i], blist[j]))
                    {
                        Book temp = blist[i];
                        blist[i] = blist[j];
                        blist[j] = temp;
                    }
                }
            }
            return blist;
        }
    }
}
