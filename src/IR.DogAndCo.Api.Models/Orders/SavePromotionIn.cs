namespace IR.DogAndCo.Api;

public sealed class SaveOrderIn
{
    public Guid CustomerCode { get; set; }
    public OrderLine[] OrderLines { get; set; }
}