using System.Collections.Generic;

namespace mvcagain.Models
{
    public interface IBookstoreDb
    {
        void Create(Book x);

        void Create(Publisher x);


        void Update(Book x);


        void Update(Publisher x);


        void DeleteBook(int x);


        void DeletePublisher(int x);

        IEnumerable<Publisher> GetPublishers();
    }
}