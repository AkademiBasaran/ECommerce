using ECommerce.Models;

namespace ECommerce.Data.Services;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string email);

    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}
