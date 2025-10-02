using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetById(int id);
        List<Book> GetAll();
        void Update(Book book);
        void Delete(int id);


    }
}
