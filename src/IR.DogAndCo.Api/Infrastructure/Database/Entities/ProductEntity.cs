namespace IR.DogAndCo.Api;

public sealed class ProductEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Name { get; set; }
    public ProductTypeEntity ProductType { get; set; }
    public decimal Price { get; set; }
    public ICollection<PromotionEntity> Promotions { get; set; }
}
