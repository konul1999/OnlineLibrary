﻿using Microsoft.EntityFrameworkCore;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        public Author GetById(int id)
        {
           return  _context.Authors.Include(a => a.Books).ThenInclude(b => b.ReservedItems).FirstOrDefault(a => a.Id == id);
        }

        public List<Author> GetAll()
        {
            return _context.Authors.Include(a => a.Books).ToList();
        }
        public void Update(Author author) 
        { 
            _context.Authors.Update(author); 
            _context.SaveChanges(); 
        }

        public void Delete(int id) 
        {
            Author author = GetById(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}


