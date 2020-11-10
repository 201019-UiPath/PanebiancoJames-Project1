using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class InventoryService
    {
        private IInventoryRepo repo;

        public InventoryService(IInventoryRepo repo)
        {
            this.repo = repo;
        }

        public void AddToInventory(Inventory newInventoryItem)
        {
            repo.AddToInventory(newInventoryItem);
        }

        public void AddToInventory(int locationId, int productId,int quantity)
        {
            repo.AddToInventory(locationId, productId, quantity);
        }

        public void RemoveFromInventory(int locationId, int productId,int quantity)
        {
            Inventory currentInventory = repo.GetProductByLocationAndProductId(locationId, productId);
            
            if(quantity > currentInventory.Quantity)
            {
                Log.Error($"Not Enough Product. User Requested Amount: {quantity}, Available Amount: {currentInventory.Quantity}");
                throw new Exception("\nNot Enough Product in Inventory");
            }
            repo.RemoveFromInventory(locationId, productId, quantity);
        }

        public Inventory GetInventoryById(int id)
        {
            return repo.GetInventoryById(id);
        }

        public Inventory GetInventoryByLocationId(int id)
        {
            return repo.GetInventoryByLocationId(id);
        }

        public Inventory GetProductByLocationAndProductId(int locationId, int productId)
        {
            return repo.GetProductByLocationAndProductId(locationId, productId);
        }

        public List<Inventory> GetInventoriesById(int id)
        {
            return repo.GetInventoriesById(id);
        }

        public List<Inventory> GetInventoriesByLocationId(int id)
        {
            return repo.GetInventoriesByLocationId(id);
        }
    }
}