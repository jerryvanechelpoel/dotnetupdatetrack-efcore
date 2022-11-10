namespace IR.DogAndCo.Api;

public sealed class CustomerEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
}
