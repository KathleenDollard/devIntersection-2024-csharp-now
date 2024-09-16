public class UnderReview
{
    private const int expirationYears = 2;

    public DateTime Expiration()
    {
        var now = DateTime.Now;
        var expires = CalculateExpiration(now);
        return expires;
    }

    public DateTime CalculateExpiration(DateTime startDate)
    {
        var expirationDate = new DateTime(
            startDate.Year + expirationYears, 
            startDate.Month, startDate.Day);
        return expirationDate;
    }
}
