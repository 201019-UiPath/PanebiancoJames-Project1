namespace GameKingdomDB.Models
{
    /// <summary>
    /// Inventory Model
    /// </summary>
    public class Inventory
    {
        public int Id {get; set;}

        public int LocationId {get; set;}

        public int ProductId {get; set;}

        public int Quantity {get; set;}
    }
}