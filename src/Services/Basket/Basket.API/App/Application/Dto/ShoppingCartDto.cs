namespace Basket.API.App.Application.Dto;

public class ShoppingCartDto
{
    public string UserName { get; set; }
    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new();

    public decimal TotalPrice => ShoppingCartItems.Sum(i => i.Price * i.Quantity);
}
