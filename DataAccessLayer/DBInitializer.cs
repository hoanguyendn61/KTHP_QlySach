using System;
using DataTransferObject;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBInitializer : DropCreateDatabaseAlways<QLSach>
    {
        protected override void Seed(QLSach context)
        {
            context.Books.AddRange(new Book[]
            {
                new Book{B_ID = 101, B_Name = "How To Get Rich", B_PublishDate = Convert.ToDateTime("2021-08-08"), B_Status = true, A_ID = 1  },
                new Book{B_ID = 101, B_Name = "How To Sell Drugs Online", B_PublishDate = Convert.ToDateTime("2021-07-08"), B_Status = true, A_ID = 2  },
                new Book{B_ID = 101, B_Name = "How To Get Away With Murders", B_PublishDate = Convert.ToDateTime("2021-03-08"), B_Status = false, A_ID = 1  },
                new Book{B_ID = 101, B_Name = "How To Be A Rapper", B_PublishDate = Convert.ToDateTime("2021-04-08"), B_Status = true, A_ID = 3},
            });
            context.Authors.AddRange(new Author[]
            {
                new Author{A_ID = 1, A_Name = "Average Joe"},
                new Author{A_ID = 2, A_Name = "John Doe"},
                new Author{A_ID = 3, A_Name = "Jane Doe"},
            });
        }
    }
}
