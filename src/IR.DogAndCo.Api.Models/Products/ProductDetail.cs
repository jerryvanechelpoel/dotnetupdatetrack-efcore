namespace IR.DogAndCo.Api;

public sealed class ProductDetail
{
    public Guid Code { get; set; }
    public string Name { get; set; }
    public Guid TypeCode { get; set; }
    public decimal Price { get; set; }
}