using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface IInventoryMapper
    {
        Models.Inventory ParseInventory (Entities.Inventory inventory);

        Entities.Inventory ParseInventory (Models.Inventory inventory);

        List<Models.Inventory> ParseInventory (ICollection<Entities.Inventory> inventory);

        ICollection<Entities.Inventory> ParseInventory (List<Models.Inventory> inventory);
    }
}