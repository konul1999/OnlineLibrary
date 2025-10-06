using OnlineLibrary.Application.Interfaces.Repositories;
using OnlineLibrary.Application.Interfaces.Services;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Domain.Enums;
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
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;

        public BookService(IBookRepository bookRepo, IAuthorRepository authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public void Create(Book book)
        {
            var author = _authorRepo.GetById(book.AuthorId);
            if (author == null)
                throw new Exception("Author not found!");

            _bookRepo.Add(book);
        }

        public void Delete(int id)
        {
            Book book = _bookRepo.GetById(id);
            if (book == null) throw new Exception("Book not found!");

            if (book.ReservedItems.Any(r => r.Status == Status.Confirmed || r.Status == Status.Started))
                throw new Exception("Book is currently reserved or in use and cannot be deleted.");

            _bookRepo.Delete(id);
        }

       

        public Book? GetById(int id)
        {
            return _bookRepo.GetById(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepo.GetAll();
        }

    }
}

