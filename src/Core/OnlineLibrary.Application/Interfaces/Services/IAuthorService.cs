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
        void CreateAuthor(Author author);
        Author GetById(int id);
        List<Book> ShowAuthorsBooks(int id);
        List<Author> GetAllBooks();
        void Delete(int id);
    }
}
