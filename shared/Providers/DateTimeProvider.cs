namespace shared.Providers;
public class DateTimeProvider : IDateTimeProvider {
    public DateTimeOffset UtcNow() => DateTimeOffset.UtcNow;
}
