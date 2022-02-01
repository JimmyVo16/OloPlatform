using System.Collections.Generic;
using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Services
{
    public interface IInventoryService
    {
        public Task<IEnumerable<int>> CreateReservations(InventoryRequestDto requestDto);
    }
}