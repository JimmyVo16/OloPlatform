using OloPlatform.Models;

namespace OloPlatform.Repositories
{
    public interface IInventoryRepository
    {
        public InventoryResponseDto CreateInventory(InventoryRequestDto requestDto);
    }
}