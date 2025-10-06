using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        Author GetById(int id);
        List<Author> GetAll();
        void Update(Author author);
        void Delete(int id);
        bool IsExist(int id);
    }
}
