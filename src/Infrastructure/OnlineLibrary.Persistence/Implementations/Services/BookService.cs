using OnlineLibrary.Application.Interfaces.Services;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Persistence.Implementations.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepo;
        private readonly AuthorRepository _authorRepo;

        public BookService(AuthorRepository authorRepo, BookRepository bookRepo)
        {
            _authorRepo = authorRepo;
            _bookRepo = bookRepo;
        }

        public void Create(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
