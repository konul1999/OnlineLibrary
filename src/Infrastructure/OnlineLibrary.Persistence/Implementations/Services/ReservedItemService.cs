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
    public class ReservedItemService : IReservedItemService
    {
        private readonly ReservedItemRepository _itemRepo;
        private readonly BookRepository _bookRepo;  
        public void ChangeReservationStatus()
        {
            throw new NotImplementedException();
        }

        public List<ReservedItem> ReservationList()
        {
            throw new NotImplementedException();
        }

        public void ReserveBook()
        {
            throw new NotImplementedException();
        }

        public List<ReservedItem> UserReservationsList()
        {
            throw new NotImplementedException();
        }
    }
}
