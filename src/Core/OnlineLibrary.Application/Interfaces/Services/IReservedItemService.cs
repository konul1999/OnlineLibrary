using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Application.Interfaces.Services
{
    public interface IReservedItemService
    {
        void ReserveBook();
        List<ReservedItem> ReservationList();
        void ChangeReservationStatus();
        List<ReservedItem> UserReservationsList();
    }
}
