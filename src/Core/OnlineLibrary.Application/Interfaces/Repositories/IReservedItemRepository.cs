using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Repositories
{
    public interface IReservedItemRepository
    {
        void Add(ReservedItem reservedItem);
        ReservedItem GetById(int id);
        List<ReservedItem> GetAll();
        ReservedItem GetByUserId(string finCode);
        void Update(ReservedItem reservedItem);
        void Delete(int id);

    }        
    
}
