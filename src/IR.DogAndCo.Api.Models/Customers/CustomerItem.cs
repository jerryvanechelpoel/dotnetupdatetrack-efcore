namespace IR.DogAndCo.Api;

public sealed class CustomerItem
{
    public Guid Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine1 { get; set; }
    public string PostalCode { get; set; }
}