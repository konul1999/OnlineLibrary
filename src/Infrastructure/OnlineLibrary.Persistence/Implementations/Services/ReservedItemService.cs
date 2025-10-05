using OnlineLibrary.Application.Interfaces.Repositories;
using OnlineLibrary.Application.Interfaces.Services;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Domain.Enums;
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
        private readonly IReservedItemRepository _repo;
        private readonly IBookRepository _bookRepo;

        public ReservedItemService(IReservedItemRepository repo, IBookRepository bookRepo)
        {
            _repo = repo;
            _bookRepo = bookRepo;
        }

        public void ReserveBook(string finCode, int bookId, DateTime start, DateTime end)
        {
            var book = _bookRepo.GetById(bookId);
            if (book == null)
                throw new Exception("Book not found!");

            if (start >= end)
                throw new Exception("Invalid date range.");

            var activeUserBooks = _repo.GetAll()
                                       .Count(r => r.FinCode == finCode && r.Status == Status.Started);
            if (activeUserBooks >= 3)
                throw new Exception("User already has 3 active books.");

            var reservation = new ReservedItem
            {
                BookId = bookId,
                FinCode = finCode,
                StartDate = start,
                EndDate = end,
                Status = Status.Confirmed
            };

            _repo.Add(reservation);
        }

        public List<ReservedItem> UserReservationsList(string finCode)
        {
            return _repo.GetAll().FindAll(r => r.FinCode == finCode);
        }

        public List<ReservedItem> ReservationList()
        {
            return  _repo.GetAll();
        }

        public void ChangeReservationStatus(int id, Status newStatus)
        {
            var item = _repo.GetById(id);
            if (item == null) throw new Exception("Reservation not found!");

            item.Status = newStatus;
            _repo.Update(item);
        }

    
    }
}
    

