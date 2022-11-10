namespace IR.DogAndCo.Api;

public sealed partial class DogAndCoDbContext
{
    private static class QueryStore
    {
        public const string Top10CustomersQuery = @"
            SELECT TOP 10
                Id,
                Code,
                FirstName,
                LastName,
                AddressLine,
                PostalCode,
                City
            FROM
                Customer c
                    INNER JOIN (SELECT
                                    CustomerId,
                                    SUM(ol.Price * ol.Amount) TotalSpent
                                FROM
                                    Order o
                                        INNER JOIN OrderLine ol
                                            ON ol.OrderId = o.id) calc
                        ON c.Id = Calc.CustomerId
            ORDER BY
                calc.TotalSpent DESC";
    }
}
