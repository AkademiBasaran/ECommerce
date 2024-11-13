using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class ShoppingCartItem : IEntityBase
{
    [Key]
    public int Id { get; set; }

    public Movie Movie { get; set; }

    public int Amount { get; set; }

    public string ShoppingCardId { get; set; }
}
