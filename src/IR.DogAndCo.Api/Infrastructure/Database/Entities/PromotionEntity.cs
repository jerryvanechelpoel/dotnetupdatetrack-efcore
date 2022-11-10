namespace IR.DogAndCo.Api;

public sealed class PromotionEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Description { get; set; }
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<ProductEntity> Products { get; set; }
}
