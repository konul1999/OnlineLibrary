using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Interfaces.Repositories;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Persistence.Implementations.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public void Add(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();          
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.ReservedItems).FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAll()
        {
           return  _context.Books.Include(b => b.Author).Include(b => b.ReservedItems).ToList();
        }

        public void Update(Book book) 
        { 
           _context.Books.Update(book); 
           _context.SaveChanges(); 
        }
        public void Delete(int id) 
        { 
            Book? book1 = GetById( id);
            if (book1 != null)
            {
                _context.Books.Remove(book1);
                _context.SaveChanges();
            }
        }


    }
}
