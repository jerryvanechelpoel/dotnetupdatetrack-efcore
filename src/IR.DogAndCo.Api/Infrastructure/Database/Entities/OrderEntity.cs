namespace IR.DogAndCo.Api;

public sealed class OrderEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public DateTime OrderDate { get; set; }
    public CustomerEntity Customer { get; set; }
    public ICollection<OrderLineEntity> OrderLines { get; set; }
}
