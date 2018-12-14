using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository.DatabaseContext;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        DbContextFactory _dbContextFactory;
        public BookRepository()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            using (DbContext dbContext = new DbContextFactory().Context)
            {
                SqlCommand _sqlCommand = dbContext.Connection.CreateCommand();
                _sqlCommand.CommandType = System.Data.CommandType.Text;
                _sqlCommand.CommandText = "select * from dbo.Book";
                
                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Book book = new Book();
                        book.BookID = (Guid)dataReader["BookID"];
                        book.BookName = (string)dataReader["BookName"];
                        book.Description = (string)dataReader["Description"];
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public Book GetByID()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

    }
}
