namespace shared.Providers;
public interface IDateTimeProvider {
    public DateTimeOffset UtcNow();
}
