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
    public class AuthorService : IAuthorService
    {
        private readonly AuthorRepository _repo;

        public AuthorService(AuthorRepository repo)
        {
            _repo = repo;
        }

        public void CreateAuthor(Author author)
        {
            string authorName = Console.ReadLine();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> ShowAuthorsBooks(int id)
        {
            throw new NotImplementedException();
        }
    }
}
