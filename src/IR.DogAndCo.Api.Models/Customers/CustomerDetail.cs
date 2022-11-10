namespace IR.DogAndCo.Api;

public sealed class CustomerDetail
{
    public Guid Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public Guid[] OrderHistory { get; set; }
}
