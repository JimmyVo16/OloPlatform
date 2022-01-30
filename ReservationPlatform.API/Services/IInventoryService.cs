using OloPlatform.Models;

namespace OloPlatform.Services
{
    public interface IInventoryService
    {
        public InventoryResponseDto CreateInventory(InventoryRequestDto requestDto);
    }
}