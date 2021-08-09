using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;
namespace BusinessLayerLogic
{
    public class Author_BLL
    {
        private static Author_BLL _instance = null;
        public static Author_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Author_BLL();
                }
                return _instance;
            }
        }
        private Author_BLL()
        {
        }
        public List<Author> GetListOfAuthors_BLL()
        {
            return Author_DAL.Instance.GetListOfAuthors_DAL();
        }
    }
}
