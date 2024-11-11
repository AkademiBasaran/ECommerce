using ECommerce.Models;

namespace ECommerce.Data.Cart;

public class ShoppingCart
{
    public AppDbContext _context { get; set; }
    
    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public int ShoppingCartId { get; set; }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

}
