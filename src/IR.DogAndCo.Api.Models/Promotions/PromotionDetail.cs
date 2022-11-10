namespace IR.DogAndCo.Api;

public sealed class PromotionDetail
{
    public Guid Code { get; set; }
    public string Description { get; set; }
    public PromotionType Type { get; set; }
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid[] ProductCodes { get; set; }
}