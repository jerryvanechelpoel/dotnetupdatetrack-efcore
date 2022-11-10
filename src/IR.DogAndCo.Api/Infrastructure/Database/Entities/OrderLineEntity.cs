namespace IR.DogAndCo.Api;

public sealed class OrderLineEntity
{
    public int Id { get; set; }
    public OrderEntity Order { get; set; }
    public ProductEntity Product { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}
