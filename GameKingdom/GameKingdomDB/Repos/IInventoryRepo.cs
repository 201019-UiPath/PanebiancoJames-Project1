using GameKingdomDB.Models;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface IInventoryRepo
    {
        void AddToInventory(Inventory inventoryItem);

        void RemoveFromInventory(int locationId, int productId, int quantity);

        void AddToInventory(int locationId, int productId, int quantity);

        Inventory GetInventoryById(int id);

        Inventory GetInventoryByLocationId(int id);

        Inventory GetProductByLocationAndProductId(int locationId, int productId);

        List<Inventory> GetInventoriesById(int id);

        List<Inventory> GetInventoriesByLocationId(int id);
    }
}