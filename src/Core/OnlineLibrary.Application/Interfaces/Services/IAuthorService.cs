using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        void Create(Author author);
        List<Author> GetAllAuthors();
        Author? GetById(int id);
    }
}
