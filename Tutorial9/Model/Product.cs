using System.ComponentModel.DataAnnotations;

namespace Tutorial9.Model;

public class Product
{
    public int IdProduct { get; set; }
    public int IdWarehouse { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Order
{
    public int IdOrder { get; set; }
    public int IdProduct { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
}