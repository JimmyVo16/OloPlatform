﻿using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Repositories
{
    public interface IInventoryRepository
    {
        public Task<ReservationTimeSlotDto> CreateReservationTimeSlot(InventoryRequestDto requestDto);
    }
}