namespace IR.DogAndCo.Api;

public sealed class OrderLine
{
    public Guid ProductCode { get; set; }
    public decimal Amount { get; set; }
}