using Tutorial9.Model;

namespace Tutorial9.Services;

public interface IWarehouseService
{
    Task<Boolean> ProductExistsAsync(int idProduct);
    Task<Boolean> WarehouseExistsAsync(int idWarehouse);
    Task<Order?> GetOrderAsync(int idProduct, int amount, DateTime createdAt);
    Task<Boolean> WasRealizedAsync(int idOrder);
    Task<Int32> UpdateOrderAsync(int IdWarehouse, int IdProduct, int IdOrder, int Amount);
}