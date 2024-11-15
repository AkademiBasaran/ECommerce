using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Cart;

public class ShoppingCart
{
    public AppDbContext _context { get; set; }

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public void AddItemToCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCardId == ShoppingCartId);

        if (shoppingCartItem is null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCardId = ShoppingCartId,
                Movie = movie,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();

    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; ;
        var context = services.GetService<AppDbContext>();

        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };

    }

    public void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = GetShoppingCartItems()
                .FirstOrDefault(x => x.Movie.Id == movie.Id
               && x.ShoppingCardId == ShoppingCartId);

        if (shoppingCartItem is not null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _context.SaveChanges();
    }

    public string ShoppingCartId { get; set; }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
            .Where(n => n.ShoppingCardId == ShoppingCartId)
            .Include(n => n.Movie).ToList());
    }

    public double GetShoppingCartTotal()
    {
        return _context.ShoppingCartItems
                .Where(n => n.ShoppingCardId == ShoppingCartId)
                .Select(m => m.Movie.Price * m.Amount).Sum();
    }


    public async Task ClearShoppingCartAsync()
    {
        var items = await _context.ShoppingCartItems
            .Where(n => n.ShoppingCardId == ShoppingCartId)
            .ToListAsync();
        
        _context.ShoppingCartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }

}
