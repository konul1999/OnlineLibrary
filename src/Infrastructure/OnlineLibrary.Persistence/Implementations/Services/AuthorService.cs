using OnlineLibrary.Application.Interfaces.Repositories;
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
        private readonly IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo) => _repo = repo;

        public void Create(Author author)
        {
            _repo.Add(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _repo.GetAll();
        }

        public Author? GetById(int id)
        {
            return _repo.GetById(id);
        }

            
    }
}
