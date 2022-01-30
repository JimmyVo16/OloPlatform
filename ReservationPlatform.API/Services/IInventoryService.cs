using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Services
{
    public interface IInventoryService
    {
        public Task<InventoryResponseDto> CreateInventory(InventoryRequestDto requestDto);
    }
}