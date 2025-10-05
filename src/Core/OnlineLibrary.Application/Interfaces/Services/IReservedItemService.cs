using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Services
{
    public interface IReservedItemService
    {
        void ReserveBook(string finCode, int bookId, DateTime start, DateTime end);
        List<ReservedItem> ReservationList();
        void ChangeReservationStatus(int id, Status newStatus);
        List<ReservedItem> UserReservationsList(string finCode);
    }
}
