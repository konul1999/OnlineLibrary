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
    public class ReservedItemRepository : IReservedItemRepository
    {
        private readonly AppDbContext _context;
        public ReservedItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ReservedItem reservedItem)
        {
            _context.Add(reservedItem);
            _context.SaveChanges();
        }

        public ReservedItem GetById(int id)
        {
            return _context.ReservedItems.Include(r => r.Book).ThenInclude(b => b.Author).FirstOrDefault(r => r.Id == id);
        }
        public List<ReservedItem> GetAll()
        {
            return _context.ReservedItems.Include(r => r.Book).ThenInclude(b => b.Author).ToList();
        }
        public List<ReservedItem> GetByUserId(string finCode)
        {
           return  _context.ReservedItems.Include(r => r.Book).Where(r => r.FinCode == finCode).ToList();
        }

        public void Update(ReservedItem reservedItem) 
        { 
          _context.ReservedItems.Update(reservedItem);
          _context.SaveChanges(); 
        }
        public void Delete(int id) 
        { 
            ReservedItem? item = GetById(id);
            if (item != null)
            {
                _context.ReservedItems.Remove(item);
                _context.SaveChanges();
            }
        }

        ReservedItem IReservedItemRepository.GetByUserId(string finCode)
        {
            throw new NotImplementedException();
        }
    }
}
