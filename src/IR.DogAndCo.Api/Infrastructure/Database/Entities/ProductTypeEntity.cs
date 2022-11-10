namespace IR.DogAndCo.Api;

public sealed class ProductTypeEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Name { get; set; }
    public ICollection<ProductEntity> Products { get; set; }
}
