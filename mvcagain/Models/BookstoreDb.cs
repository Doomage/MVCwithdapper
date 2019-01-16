using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace mvcagain.Models
{
    public class BookstoreDb : IBookstoreDb
    {
        private string _connectionString = Properties.Settings.Default.connectionString;



        public IEnumerable<Publisher> GetPublishers()
        {
            using (var dbcon = new SqlConnection(_connectionString))
            {
                //dbcon.Open();

                return dbcon.Query<Publisher>("select * from publishers");
            }
        }
        public IEnumerable<Book> GetBooks()
        {
            using (var dbcon = new SqlConnection(_connectionString))
            {
                //dbcon.Open();

                return dbcon.Query<Book>("select * from Books");
            }
        }

        public void Create(Book x)
        {
            SqlConnection dbCon = new SqlConnection(_connectionString);
            using (dbCon)
            {
                dbCon.Query("INSERT INTO Books (Title, Author, Price, PublicationYear, PublisherId) VALUES (@Title,@Author, @Price,@PublicationYear,@PublisherId);",
                    new { Title = x.Title, Author = x.Author, Price = x.Price, PublicationYear = x.PublicationYear, PublisherId = x.PublisherId });
            };
        }

        public void Create(Publisher x)
        {
            string publisherCreation = "INSERT INTO Publishers (Name) VALUES (@Name);";

            SqlConnection dbcon = new SqlConnection(_connectionString);

            using (dbcon)
            {
                var createPublisher = dbcon.Query(publisherCreation, new { Name = x.Name });
            }
        }


        public void Update(Book book)
        {
            SqlConnection dbCon = new SqlConnection(_connectionString);
            using (dbCon)
            { 
                dbCon.Query("UPDATE Books SET Title = @Title, Author=@Author, Price=@Price, PublicationYear = @PublicationYear, PublisherId = @PublisherId WHERE Id = @Id", new
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear,
                    PublisherId = book.PublisherId
                });
            };
        }


        public void Update(Publisher publisher)
        {
            
            SqlConnection dbCon = new SqlConnection(_connectionString);
            using (dbCon)
            {
                dbCon.Query("UPDATE Publishers SET Name = @Name WHERE Id = @Id",
                    new { Name = publisher.Name,
                          Id= publisher.Id});
            };

        }


        public void DeleteBook(int x)
        {
            string deletion = "DELETE FROM Books WHERE Id=@id";
            SqlConnection dbcon = new SqlConnection(_connectionString);

            using (dbcon)
            {
                var bookDeletion = dbcon.Query(deletion, new { id = x });
            }
        }


        public void DeletePublisher(int x)
        {
            string deletion = "DELETE FROM Publishers WHERE Id=@id";
            SqlConnection dbcon = new SqlConnection(_connectionString);

            using (dbcon)
            {
                var publisherDeletion = dbcon.Query(deletion, new { id = x });
            }
        }



    }
}