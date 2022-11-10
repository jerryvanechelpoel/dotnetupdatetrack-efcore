namespace IR.DogAndCo.Api;

public sealed class FindProductsIn
{
    public string NamePattern { get; set; }
    public Guid ProductTypeCode { get; set; }
}
