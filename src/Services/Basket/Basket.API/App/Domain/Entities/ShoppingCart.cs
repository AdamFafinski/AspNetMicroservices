namespace Basket.API.App.Domain.Entities;

public class ShoppingCart
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();
}
